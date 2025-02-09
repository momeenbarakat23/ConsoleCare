using Console_Care.Models;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.CustomerDataBase
{
    public class CustomerDB : ICustomerDataBase
    {
        private readonly Appdbcontext appdbcontext;

        public CustomerDB(Appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public async Task<List<CustomerDataBases>> AddData(string typeofcustomer)
        {
           var result = await appdbcontext.customer.Where(x=>x.TypeOfCustomer==typeofcustomer).ToListAsync();
            var data= await appdbcontext.CustomerDataBases.ToListAsync();
           
                var newdata= new List<CustomerDataBases>();
                foreach (var item in result)
                {
                if ((data.FirstOrDefault(x => x.Phone == item.Phone && x.TypeOfCustomer==typeofcustomer) == null))
                    {
                        var data2 = new CustomerDataBases();
                        data2.id = Guid.NewGuid().ToString();
                        data2.Address = item.Address;
                        data2.TypeOfCustomer = item.TypeOfCustomer;
                        data2.Name = item.Name;
                        data2.Ps4OrPs5 = item.Ps4OrPs5;
                        data2.city = item.city;
                        data2.Phone = item.Phone;
                        newdata.Add(data2);
                        await appdbcontext.CustomerDataBases.AddRangeAsync(newdata);
                        await appdbcontext.SaveChangesAsync();
                    }
               
            }
                
            
            return data;
        }
    }
}
