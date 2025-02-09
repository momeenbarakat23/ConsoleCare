
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Iinvoice
{
    public class Invoices : Iinvoice
    {
        private readonly Appdbcontext appdbcontext;

        public Invoices(Appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public async Task<Invoice> CreateAsync(Invoice invoice)
        {
            var materials = await appdbcontext.materials.ToListAsync();
            var matforemp=await appdbcontext.EmployeeMaterials.Include(x=>x.Employee).Include(x=>x.Materials).Where(x=>x.Employee.name==invoice.nameoftechnecal).ToListAsync();

            for (int i = 0; i < invoice.item.Count; i++)
            {
                foreach (var material in materials)
                {
                    if (material.Name == invoice.item[i])
                    {
                        material.Quantity -= invoice.quantity[i];
                        appdbcontext.Update(material);
                        break;
                    }
                    
                }
            }
            var count = matforemp.Count;
            for (int i = 0; i < invoice.item.Count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (matforemp[j].Materials.Name == invoice.item[i])
                    {
                        var date = await appdbcontext.EmployeeMaterials.Include(x => x.Materials).Where(x => x.Materials.Name == invoice.item[i]).MaxAsync(x => x.Date);
                        var mat = await appdbcontext.EmployeeMaterials.FirstOrDefaultAsync(x => x.Date == date);
                        if (mat != null)
                        {
                            mat.QuantityUsed += invoice.quantity[i];
                            appdbcontext.Update(matforemp[j]);
                        }
                       
                       
                        break;
                    }
                    
                }
            }
           
            invoice.remaining = invoice.Total_Amountafterdisc - invoice.Paid;
            await appdbcontext.Invoices.AddRangeAsync(invoice);
            await appdbcontext.SaveChangesAsync();
            return invoice;
        }

        public async Task<InvoiceViewModel> UpdateAsync(InvoiceViewModel invoiceViewModel)
        {

            var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Include(x => x.CustomerDataBases).FirstOrDefaultAsync(x => x.Invoicesid == invoiceViewModel.id && x.CustomerDataBasesid == invoiceViewModel.custid);
            var materials = await appdbcontext.materials.ToListAsync();
            var matforemp = await appdbcontext.EmployeeMaterials.Include(x => x.Employee).Include(x => x.Materials).Where(x => x.Employee.name == invoiceViewModel.nameoftechnecal).ToListAsync();

            data.Invoicesid = invoiceViewModel.id;
            data.CustomerDataBasesid = invoiceViewModel.custid;


            if (invoiceViewModel.nameofcustomer is not null)
            {
                data.CustomerDataBases.Name = invoiceViewModel.nameofcustomer;
            }
            for (int i = 0; i < invoiceViewModel.quantity.Count(); i++)
            {

                if (data.Invoice.quantity[i] >= invoiceViewModel.quantity[i])
                {
                    var result = data.Invoice.quantity[i] - invoiceViewModel.quantity[i];
                    foreach (var material in materials)
                    {
                        if (material.Name == invoiceViewModel.item[i])
                        {
                            material.Quantity += result;
                            appdbcontext.Update(material);
                            break;
                        }
                    }

                }
                else
                {
                    var result = invoiceViewModel.quantity[i] - data.Invoice.quantity[i];
                    foreach (var material in materials)
                    {
                        if (material.Name == invoiceViewModel.item[i])
                        {
                            material.Quantity -= result;
                            appdbcontext.Update(material);
                            break;
                        }
                    }
                }
            }
            //ده الجزء المسؤول عن حسب الموارد الي مع الفنين الي استعملناها
            var count = matforemp.Count;
            for (int i = 0; i < invoiceViewModel.item.Count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (matforemp[j].Materials.Name == invoiceViewModel.item[i])
                    {
                        var date = await appdbcontext.EmployeeMaterials.Include(x=>x.Materials).Where(x=>x.Materials.Name== invoiceViewModel.item[i]).MaxAsync(x => x.Date);
                        var mat = await appdbcontext.EmployeeMaterials.FirstOrDefaultAsync(x => x.Date == date);
                        if (mat != null)
                        {
                            if (mat.QuantityUsed >= invoiceViewModel.quantity[i])
                            {

                                var result = mat.QuantityUsed - invoiceViewModel.quantity[i];
                                mat.QuantityUsed -= result;
                                appdbcontext.Update(mat);

                                break;
                            }
                            else
                            {
                                var result = invoiceViewModel.quantity[i] - mat.QuantityUsed;
                                mat.QuantityUsed += result;
                                appdbcontext.Update(mat);

                                break;
                            }
                        }
                           
                    }

                }
            }

            if (invoiceViewModel.number is not null)
            {
                data.Invoice.price.RemoveRange(0, data.Invoice.price.Count());
                data.Invoice.quantity.RemoveRange(0, data.Invoice.quantity.Count());
                data.Invoice.item.RemoveRange(0, data.Invoice.item.Count());
                data.Invoice.TotalpriceForitem.RemoveRange(0, data.Invoice.TotalpriceForitem.Count());
                data.Invoice.Discount.RemoveRange(0, data.Invoice.Discount.Count());
                data.Invoice.number.RemoveRange(0, data.Invoice.number.Count());
                data.Invoice.number?.AddRange(invoiceViewModel.number);
                data.Invoice.price.AddRange(invoiceViewModel.price);
                data.Invoice.quantity.AddRange(invoiceViewModel.quantity);
                data.Invoice.item.AddRange(invoiceViewModel.item);
                data.Invoice.TotalpriceForitem.AddRange(invoiceViewModel.TotalpriceForitem);
                data.Invoice.Discount.AddRange(invoiceViewModel.Discount);
                data.Invoice.Total_Amount = invoiceViewModel.Total_Amount;
                data.Invoice.Total_Amountafterdisc = invoiceViewModel.Total_Amountafterdisc;
            }
            else
            {
                data.Invoice.price.RemoveRange(0, data.Invoice.price.Count());
                data.Invoice.quantity.RemoveRange(0, data.Invoice.quantity.Count());
                data.Invoice.item.RemoveRange(0, data.Invoice.item.Count());
                data.Invoice.TotalpriceForitem.RemoveRange(0, data.Invoice.TotalpriceForitem.Count());
                data.Invoice.Discount.RemoveRange(0, data.Invoice.Discount.Count());
                data.Invoice.number.RemoveRange(0, data.Invoice.number.Count());
                data.Invoice.Total_Amount = 0;
                data.Invoice.Total_Amountafterdisc = 0;

            }

            data.Invoice.DateTime = invoiceViewModel.DateTime;
            data.Invoice.specialDiscount = invoiceViewModel.specialDiscount;
            data.Invoice.Discountwarranty = invoiceViewModel.Discountwarranty;
            data.Invoice.nameoftechnecal = invoiceViewModel.nameoftechnecal;
            data.Invoice.Paid = invoiceViewModel.Paid;
            data.Invoice.remaining = data.Invoice.Total_Amountafterdisc - data.Invoice.Paid;
            data.Invoice.typeofcash= invoiceViewModel.typeofcash;
            appdbcontext.UpdateRange(data);
            await appdbcontext.SaveChangesAsync();
            return invoiceViewModel;
        }
    }
}
