using Console_Care.Iinvoice;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Console_Care.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly Iinvoice.Iinvoice invoiceDB;

        public InvoiceController(Appdbcontext appdbcontext , Iinvoice.Iinvoice invoiceDB)
        {
            this.appdbcontext = appdbcontext;
            this.invoiceDB = invoiceDB;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            decimal total = 0;
            decimal paid = 0;
            decimal remaining = 0;
            var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.CustomerDataBases).Include(x=>x.Invoice).Where(x=>x.CustomerDataBasesid==id).ToListAsync();
            if (data.Count==0)
            {
                var user = await appdbcontext.CustomerDataBases.SingleOrDefaultAsync(x => x.id == id);
                ViewBag.name = user.Name;
            }
            else
            {
                ViewBag.name = data.Select(x => x.CustomerDataBases.Name).FirstOrDefault();
            }
            TempData["name"] = ViewBag.name;
            TempData["id"] = id;
            foreach (var item in data)
            {
                total += item.Invoice.Total_Amountafterdisc;
                paid += item.Invoice.Paid;

            }
            remaining = total - paid;
            TempData["total"] = total;
            TempData["paid"] = paid;
            TempData["remaining"] = remaining;

            return View(data);
        }
        //---------------addinvoice-----------
        [HttpGet]
        public async Task< IActionResult> Add() 
        {
            ViewBag.emp = await appdbcontext.Employee.ToListAsync();
            ViewBag.name = TempData["name"];
            

            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult> Add(Invoice invoice)
        {
            
            try
            {
                if (invoice.DateTime == null)
                {
                    invoice.DateTime = DateTime.UtcNow;
                }
                if (ModelState.IsValid)
                {
                    var num = "";
                    var result = await invoiceDB.CreateAsync(invoice);
                    var relation = new CustomerDataBasesInvoice();
                    relation.CustomerDataBasesid = TempData["id"].ToString();
                    relation.Invoicesid = await appdbcontext.Invoices.MaxAsync(x => x.id);
                    
                    await appdbcontext.CustomerDataBasessInvoice.AddAsync(relation);
                    await appdbcontext.SaveChangesAsync();
                    var cust = await appdbcontext.CustomerDataBases.SingleAsync(x => x.id == relation.CustomerDataBasesid);
                    var data = new Cash();
                    if (result.typeofcash== "كاش")
                    {
                        data.AccountName = "عهده";
                    }
                    else if (result.typeofcash== "فودافون-كاش")
                    {
                        data.AccountName = "VodafoneCash";
                    }else if (result.typeofcash== "انستا-باي")
                    {
                        data.AccountName = "Instapay";
                    }

                    data.paid = invoice.Paid;
                    
                    data.Date = (DateTime)invoice.DateTime;
                    num = cust.Phone;
                    data.NoOfaccount = num;
                    data.Nameofcust = cust.Name;
                    data.Outgoing = 0;
                    data.TotalAmount = data.paid;
                    data.NoOfInvoice= relation.Invoicesid.ToString();
                    data.Nameoftech = invoice.nameoftechnecal;
                    await appdbcontext.Cash.AddAsync(data);
                    await appdbcontext.SaveChangesAsync();


                    return RedirectToAction("Index", new { id = relation.CustomerDataBasesid });
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View("Add", invoice);


        }
        //-------------------display---------------
        public async Task<IActionResult> Display(string custid, int invoiceid)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = await InvoiceViewModel(custid, invoiceid);
                    

                    return View(data);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("",ex.Message);
            }
            return RedirectToAction("Index", new { id = custid });
        }
        //-----------------edit---------

        [HttpGet]
        public async Task<IActionResult> Edit(string custid, int invoiceid)
        {
            var data = await InvoiceViewModel(custid, invoiceid);
            ViewBag.emp = await appdbcontext.Employee.ToListAsync();
            ViewBag.item = await appdbcontext.materials.ToListAsync();
            TempData["custid"] = custid;
            TempData["invoiceid"] = invoiceid;
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceViewModel invoiceViewModel)
        {
            invoiceViewModel.custid = TempData["custid"].ToString();
            invoiceViewModel.id =(int) TempData["invoiceid"];
            
            var result = await invoiceDB.UpdateAsync(invoiceViewModel);
            var cust = await appdbcontext.CustomerDataBases.SingleAsync(x => x.id == invoiceViewModel.custid);
            var data = await appdbcontext.Cash.SingleOrDefaultAsync(x=>x.NoOfInvoice== invoiceViewModel.id.ToString());
            if (data != null)
            {
                if (result.typeofcash == "كاش")
                {
                    data.AccountName = "عهده";
                }
                else if (result.typeofcash == "فودافون-كاش")
                {
                    data.AccountName = "VodafoneCash";
                }
                else if (result.typeofcash == "انستا-باي")
                {
                    data.AccountName = "Instapay";
                }

                data.paid = invoiceViewModel.Paid;
                data.TotalAmount = data.paid;
                appdbcontext.Cash.Update(data);
                await appdbcontext.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = invoiceViewModel.custid });


        }
        //---------------delete--------------
        public async Task<IActionResult> Delete(string custid, int invoiceid)
        {
            var data = await appdbcontext.CustomerDataBasessInvoice.FirstOrDefaultAsync(x => x.Invoicesid == invoiceid && x.CustomerDataBasesid == custid);
            var invoice = await appdbcontext.Invoices.FirstOrDefaultAsync(x => x.id == invoiceid);
            var emp = await appdbcontext.Employee.SingleOrDefaultAsync(x => x.name == invoice.nameoftechnecal);
            var cash = await appdbcontext.Cash.SingleOrDefaultAsync(x=>x.Date==invoice.DateTime);

            emp.countinvoice -= 1;
            emp.paid -= invoice.Paid;
            appdbcontext.Update(emp);
            appdbcontext.RemoveRange(data);
            appdbcontext.Remove(invoice);
            appdbcontext.Remove(cash);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Index", new { id = custid });
        }

        //---------------------------------------
        [HttpGet]
        public async Task<IActionResult> StaticInvoice(string types  )
        {
            TempData["type"]=types;
            ViewBag.emp = await appdbcontext.Employee.Select(x=>x.name).ToListAsync();
            ViewBag.item = await appdbcontext.materials.Select(x => x.Name).ToListAsync();
            var data = await appdbcontext.Invoices.FirstOrDefaultAsync(x => x.type == types);
            if (data == null)
            {
                return View();
            }
            else
            {
                return View(data);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> StaticInvoice(Invoice invoice )
        {
            ViewBag.emp = await appdbcontext.Employee.Select(x => x.name).ToListAsync();
            ViewBag.item = await appdbcontext.materials.Select(x => x.Name).ToListAsync();
            string? type = TempData["type"].ToString();
            invoice.typeofcash = "كاش";

            invoice.Paid = 0;

            
            try
            {
                if (invoice.DateTime == null)
                {
                    invoice.DateTime = DateTime.Now;
                }
               
                if (ModelState.IsValid)
                {
                    var data = await appdbcontext.Invoices.FirstOrDefaultAsync(x=>x.type==type);

                    if (data is null)
                    {
                        if (invoice.DateTime == null)
                        {
                            invoice.DateTime = DateTime.UtcNow;
                        }
                        if (ModelState.IsValid)
                        {
                            invoice.type = type;
                            var result = await invoiceDB.CreateAsync(invoice);
                        }
                    }
                    else
                    {
                        var materials = await appdbcontext.materials.ToListAsync();
                        var view = await appdbcontext.Invoices.SingleOrDefaultAsync(x => x.type == type);
                        for (int i = 0; i < invoice.quantity.Count(); i++)
                        {

                            if (view.quantity[i] >= invoice.quantity[i])
                            {
                                var result = view.quantity[i] - invoice.quantity[i];
                                foreach (var material in materials)
                                {
                                    if (material.Name == invoice.item[i])
                                    {
                                        material.Quantity += result;
                                        appdbcontext.Update(material);
                                    }
                                }

                            }
                            else
                            {
                                var result = invoice.quantity[i] - view.quantity[i];
 
                                foreach (var material in materials)
                                {
                                    if (material.Name == invoice.item[i])
                                    {
                                        material.Quantity -= result;
                                        appdbcontext.Update(material);
                                    }
                                }
                            }
                            if (invoice.number is not null)
                                {
                                    view.price.RemoveRange(0, view.price.Count());
                                    view.quantity.RemoveRange(0, view.quantity.Count());
                                    view.item.RemoveRange(0, view.item.Count());
                                    view.TotalpriceForitem.RemoveRange(0, view.TotalpriceForitem.Count());
                                    view.Discount.RemoveRange(0, view.Discount.Count());
                                    view.number.RemoveRange(0, view.number.Count());
                                    view.number?.AddRange(invoice.number);
                                    view.price.AddRange(invoice.price);
                                    view.quantity.AddRange(invoice.quantity);
                                    view.item.AddRange(invoice.item);
                                    view.TotalpriceForitem.AddRange(invoice.TotalpriceForitem);
                                    view.Discount.AddRange(invoice.Discount);
                                    view.Total_Amount = invoice.Total_Amount;
                                    view.Total_Amountafterdisc = invoice.Total_Amountafterdisc;
                                }
                                else
                                {
                                    view.price.RemoveRange(0, view.price.Count());
                                    view.quantity.RemoveRange(0, view.quantity.Count());
                                    view.item.RemoveRange(0, view.item.Count());
                                    view.TotalpriceForitem.RemoveRange(0, view.TotalpriceForitem.Count());
                                    view.Discount.RemoveRange(0, view.Discount.Count());
                                    view.number.RemoveRange(0, view.number.Count());
                                    view.Total_Amount = 0;
                                    view.Total_Amountafterdisc = 0;

                                }

                                view.DateTime = invoice.DateTime;
                                view.specialDiscount = invoice.specialDiscount;
                                view.Discountwarranty = invoice.Discountwarranty;
                                view.nameoftechnecal = invoice.nameoftechnecal;
                                view.Paid = invoice.Paid;
                                view.remaining = view.Total_Amountafterdisc - view.Paid;
                            view.nameofcustomer = invoice.nameofcustomer;
                           
                                appdbcontext.UpdateRange(data);
                                await appdbcontext.SaveChangesAsync();
                          
                            
                        }
                    }
                }


                       

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("StaticInvoice" , new { types= type });
        }


        public async Task<InvoiceViewModel> InvoiceViewModel(string custid, int invoiceid)
        {
            var viewinvoice = new InvoiceViewModel();
            var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Include(x => x.CustomerDataBases).FirstOrDefaultAsync(x => x.Invoicesid == invoiceid && x.CustomerDataBasesid == custid);
            viewinvoice.id = data.Invoicesid;
            viewinvoice.custid = custid;
            viewinvoice.number = data.Invoice.number;
            viewinvoice.nameofcustomer = data.CustomerDataBases.Name;
            viewinvoice.price = data.Invoice.price;
            viewinvoice.quantity = data.Invoice.quantity;
            viewinvoice.typeofcash = data.Invoice.typeofcash;
            viewinvoice.DateTime = data.Invoice.DateTime;
            viewinvoice.TotalpriceForitem= data.Invoice.TotalpriceForitem;
            viewinvoice.specialDiscount = data.Invoice.specialDiscount;
            viewinvoice.Discountwarranty = data.Invoice.Discountwarranty;
            viewinvoice.nameoftechnecal = data.Invoice.nameoftechnecal;
            viewinvoice.item = data.Invoice.item;
            viewinvoice.Total_Amount = data.Invoice.Total_Amount;
            viewinvoice.Total_Amountafterdisc = data.Invoice.Total_Amountafterdisc;
            viewinvoice.Discount = data.Invoice.Discount;
            viewinvoice.Paid=data.Invoice.Paid;
            viewinvoice.typeofinvoice = data.Invoice.typeofinvoice;
            ViewBag.name = data.CustomerDataBases.Name;
            return viewinvoice;
        }
    }
}
