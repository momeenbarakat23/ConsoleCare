using Console_Care.identity;

using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Console_Care.Controllers
{
    public class itineraryController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> user;


        public itineraryController(Appdbcontext appdbcontext , UserManager<Appuser> user )
        {
            this.appdbcontext = appdbcontext;
            this.user = user;

        }
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var data = new List<ItineraryViewModel>();
            
            var customer = await appdbcontext.customer.ToListAsync();
            
            foreach (var cust in customer)
            {
                var data2 = new ItineraryViewModel();
                var admincust=await appdbcontext.AdminCustomers.FirstOrDefaultAsync(x=> x.CustomerId == cust.Id);
                var itinerary = await appdbcontext.itineraries.SingleOrDefaultAsync(x => x.Id == cust.ItineraryId);
                if (admincust != null)
                {
                    var admin = await appdbcontext.Admins.SingleOrDefaultAsync(x => x.Id == admincust.AdminId);
                    data2.DataEntryName = admin.AdminName;
                    data2.VisitStatus = admin.VisitStatus;
                    data2.RouteDistributionOfficer = admin.RouteDistributionOfficer;
                    data2.NotesToMaintenanceTeam = admin.NotesToMaintenanceTeam;
                }
                
                data2.Id=cust.Id;
                data2.NameOfcustomer = cust.Name;
                data2.StateOfOrderforcustomer = cust.StateOfOrder;
                    data2.AddressOfcustomer = cust.Address;
                data2.Orderforcustomer= cust.Order;
                    data2.cityOfcustomer = cust.city;
                    data2.PhoneOfcustomer=cust.Phone;
                data2.Nameoftech = itinerary?.Nameoftech;
                data2.VisitClassification = itinerary?.VisitClassification;
                data2.VisitDate = itinerary?.VisitDate;
                data2.Note = itinerary?.Note;
                data2.FaultStatement = itinerary?.FaultStatement;
                data2.NameOfAssistant = itinerary?.NameOfAssistant;
                data2.RemainingTeam= itinerary?.RemainingTeam;
                data2.typeofcustomer=cust.TypeOfCustomer;
                
                data.Add(data2);

            }
            if (User.Identity.IsAuthenticated==true)
            {
                var datauser = await user.FindByNameAsync(User.Identity.Name);
                ViewBag.name = datauser.name;
            }


            return View(data);
        }
        //---------edit-data-------------
        [HttpGet]
        public async Task<IActionResult> Editdata(int id)
        {
            var cust = await appdbcontext.customer.SingleOrDefaultAsync(x => x.Id == id);
            var itinerary = await appdbcontext.itineraries.SingleOrDefaultAsync(x => x.Id == cust.ItineraryId);
            var data = new ItineraryViewModel();
            
            
            data.NameOfcustomer = cust?.Name;
            data.StateOfOrderforcustomer = cust?.StateOfOrder;
            data.AddressOfcustomer = cust?.Address;
            data.Orderforcustomer = cust?.Order;
            data.cityOfcustomer = cust?.city;
            data.PhoneOfcustomer = cust?.Phone;
            data.Nameoftech = itinerary?.Nameoftech;
            data.VisitClassification = itinerary?.VisitClassification;
            data.VisitDate = itinerary?.VisitDate;
            data.Note = itinerary?.Note;
            data.NameOfAssistant = itinerary?.NameOfAssistant;
            data.RemainingTeam = itinerary?.RemainingTeam;
            data.FaultStatement = itinerary?.FaultStatement;
            data.typeofcustomer = cust?.TypeOfCustomer;
            return View(data);
        }
       
        [HttpPost]
        public async Task< IActionResult> Editdata(int id,ItineraryViewModel itinerary)
        {
            var data = await appdbcontext.customer.Include(x => x.Itinerary).SingleOrDefaultAsync(x => x.Id == id);
            data.StateOfOrder=itinerary.StatusOfOrder;
            data.Itinerary.Note= itinerary.Note;
            data.Itinerary.FaultStatement = itinerary.FaultStatement;
            appdbcontext.customer.Update(data);
            await appdbcontext.SaveChangesAsync();
            if (itinerary.StatusOfOrder== "تمت الصيانه") 
            {
                var follow = new followUp();
                var cust = await appdbcontext.customer.MaxAsync(x => x.Id);
                var emp = await appdbcontext.Employee.FirstOrDefaultAsync(x=>x.name==data.Itinerary.Nameoftech);
                follow.IdOfCustomer = cust;
                follow.IdOfEmployee = emp.id;
                follow.TypeOfCustomer=data.TypeOfCustomer;
                if (follow.TypeOfCustomer== "Home")
                {
                    follow.Maintenance_Implementation_Date = DateTime.Now;
                    follow.LastFollowUpDate = DateTime.Now.AddDays(3);
                    follow.NextFollowUpDate = DateTime.Now.AddDays(28);
                    follow.WarrantyTime = DateTime.Now.AddDays(28);

                }
                else if (follow.TypeOfCustomer == "Hall Effect")
                {
                    follow.Maintenance_Implementation_Date = DateTime.Now;
                    follow.LastFollowUpDate = DateTime.Now.AddDays(3);
                    follow.NextFollowUpDate = DateTime.Now.AddDays(28);
                    follow.WarrantyTime = DateTime.Now.AddYears(3);

                }
                else if (follow.TypeOfCustomer == "PsCafe")
                {
                    follow.Maintenance_Implementation_Date = DateTime.Now;
                    follow.LastFollowUpDate = DateTime.Now.AddDays(3);
                    follow.NextFollowUpDate = DateTime.Now.AddDays(15);
                    follow.WarrantyTime = DateTime.Now.AddDays(28);

                }


                await appdbcontext.followUp.AddRangeAsync(follow);
                await appdbcontext.SaveChangesAsync();
            }

            return RedirectToAction("GetData");
        }

        
    
    }
}
