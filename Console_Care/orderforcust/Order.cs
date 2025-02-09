using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.orderforcust
{
    public class Order : Iorder
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> user;

        public Order(Appdbcontext appdbcontext ,UserManager<Appuser> user )
        {
            this.appdbcontext = appdbcontext;
            this.user = user;
        }
        public async Task<OrderByCustomer> CreateOrder(OrderByCustomer customer)
        {
            
            var data = new Customer();
            var iti = new Itinerary();
            //var follow = new followUp();
            var emp = await appdbcontext.Employee.FirstOrDefaultAsync();
            data.Address = customer.Address;
            data.Order=customer.Order;
            data.Phone = customer.Phone;
            data.Ps4OrPs5 = customer.Ps4OrPs5;
            data.city=customer.city;
            data.Name=customer.Name;
            data.StateOfOrder = "الانتظار";
            data.TypeOfCustomer=customer.TypeOfCustomer;
            iti.StatusOfOrder=data.StateOfOrder;
            await appdbcontext.customer.AddAsync(data);
            await appdbcontext.itineraries.AddAsync(iti);
            await appdbcontext.SaveChangesAsync();
            var iti2 = await appdbcontext.itineraries.MaxAsync(x=>x.Id);
            var cust = await appdbcontext.customer.MaxAsync(x => x.Id);
            //follow.IdOfCustomer = cust;
            data.ItineraryId = iti2;
            appdbcontext.customer.Update(data);
            if (emp is null)
            {
                await appdbcontext.SaveChangesAsync();
                return customer;
            }
            //follow.IdOfEmployee = emp.id;
            //follow.Maintenance_Implementation_Date = DateTime.Now;
            //follow.LastFollowUpDate = DateTime.Now;
            //follow.NextFollowUpDate = DateTime.Now;
            //follow.WarrantyTime= DateTime.Now.AddYears(1);

            //await appdbcontext.followUp.AddRangeAsync(follow);
            await appdbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task< OrderByCustomer> EditOrder(OrderByCustomer customer)
        {
            var data = appdbcontext.customer.SingleOrDefault(x => x.Id == customer.Id);
            data.Address = customer.Address;
            data.Order = customer.Order;
            data.Phone = customer.Phone;
            data.Ps4OrPs5 = customer.Ps4OrPs5;
            data.city = customer.city;
            data.Name = customer.Name;
            data.TypeOfCustomer = customer.TypeOfCustomer;
            appdbcontext.customer.UpdateRange(data);
            await appdbcontext.SaveChangesAsync();
            return customer;
        }
    }
}
