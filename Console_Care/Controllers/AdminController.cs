using Console_Care.DeleteAllData;
using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Console_Care.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> user;
        private readonly IDelete delete;

        public int idofcust { get; set; }

        public AdminController(Appdbcontext appdbcontext, UserManager<Appuser> user , IDelete delete)
        {
            this.appdbcontext = appdbcontext;
            this.user = user;
            this.delete = delete;
        }
        [HttpGet]
        public async Task<IActionResult> getdata(int id)
        {
            TempData["idofcust"]=id;
            var customer = await appdbcontext.customer.Include(x=>x.Itinerary).SingleOrDefaultAsync(x=>x.Id==id);
            var employee = await appdbcontext.Employee.Select(x => x.name).ToListAsync();
            var admin = await appdbcontext.AdminCustomers.Include(x=>x.Admin).FirstOrDefaultAsync(x=>x.CustomerId==id);

            ViewBag.nameofemp = employee;
            var data = new adminViewModel();
            
            data.NameCustomer = customer.Name;
            data.Ps4OrPs5 = customer.Ps4OrPs5;
            data.AddressCustomer= customer.Address;
            data.PhoneCustomer= customer.Phone;
            data.cityCustomer=customer.city;
            data.OrderCustomer= customer.Order;
            data.StateOfOrderCustomer= customer.StateOfOrder;
            data.TypeOfCustomer= customer.TypeOfCustomer;
            data.NameOfTechnician= customer.Itinerary.Nameoftech;
            data.NameOfAssistant = customer.Itinerary.NameOfAssistant ;
            data.RemainingTeam = customer.Itinerary.RemainingTeam;
            data.VisitDate = customer.Itinerary.VisitDate ;
            data.VisitClassification = customer.Itinerary.VisitClassification;
            if (admin !=null)
            {
                data.RouteDistributionOfficer = admin.Admin.RouteDistributionOfficer;
                data.NotesToMaintenanceTeam = admin.Admin.NotesToMaintenanceTeam;
                data.VisitStatus = admin.Admin.VisitStatus;
            }
            
            return View(data);
        }
        [HttpPost]
        
        public async Task<IActionResult> AddData(adminViewModel adminView, AdminCustomers? adminCustomers)
        {
            
            adminView.idofCustomer =(int) TempData["idofcust"];
            
            var customer = await appdbcontext.customer.Include(x=>x.Itinerary).SingleOrDefaultAsync(x=>x.Id== adminView.idofCustomer);
            
            
            var datauser = await user.FindByNameAsync(User.Identity.Name);
           
                var admincust = await appdbcontext.AdminCustomers.SingleOrDefaultAsync(x=>x.CustomerId==adminView.idofCustomer);
                if (admincust is null)
                {
                    var admin = new Admin();
                    admin.AdminName = datauser.name;
                    admin.RouteDistributionOfficer = adminView.RouteDistributionOfficer;
                    admin.NotesToMaintenanceTeam = adminView.NotesToMaintenanceTeam;
                    admin.VisitStatus = adminView.VisitStatus;
                    await appdbcontext.Admins.AddAsync(admin);
                    await appdbcontext.SaveChangesAsync();
                    var AdminCustomer = new AdminCustomers();
                    AdminCustomer.CustomerId = customer.Id;
                    AdminCustomer.AdminId = admin.Id;
                    await appdbcontext.AdminCustomers.AddRangeAsync(AdminCustomer);
               
                 }
                else
                {
                var AdminCus = appdbcontext.AdminCustomers.SingleOrDefault(x => x.CustomerId == adminView.idofCustomer);  
                var admin = await appdbcontext.Admins.FirstOrDefaultAsync(x => x.Id == AdminCus.AdminId);
                    admin.AdminName = datauser.name;
                    admin.RouteDistributionOfficer = adminView.RouteDistributionOfficer;
                    admin.NotesToMaintenanceTeam = adminView.NotesToMaintenanceTeam;
                     appdbcontext.Admins.Update(admin);
                    await appdbcontext.SaveChangesAsync();
                }
            
            customer.Itinerary.RemainingTeam= adminView.RemainingTeam;
            customer.Itinerary.NameOfAssistant= adminView.NameOfAssistant;
            customer.Itinerary.Nameoftech = adminView.NameOfTechnician;
            customer.Itinerary.VisitDate=adminView.VisitDate;
            customer.Itinerary.VisitClassification = adminView.VisitClassification;
             appdbcontext.customer.Update(customer);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("index","Order",adminView);
            
        }


        //--------------Trancate All Data-------------
        [HttpGet]
        public IActionResult DeleteAllData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAllDataconferm()
        {
            var customer = "customer";
            var iti = "itineraries";
            var followUp = "followUp";
            var admin = "Admins";
            var AdminCustomers = "AdminCustomers";
            var resultcustomer = await delete.Deleteasync(customer);
            var resultiti = await delete.Deleteasync(iti);
            var resultfollowUp = await delete.Deleteasync(followUp);
            var resultadmin = await delete.Deleteasync(admin);
            var resultAdminCustomers = await appdbcontext.Database.ExecuteSqlRawAsync($"delete from {AdminCustomers}");
            if (resultiti == false || resultcustomer == false || resultfollowUp == false || resultadmin == false)
            {
                return View("DeleteAllData");
            }

            return RedirectToAction("Index","Order");


        }



    }
}
