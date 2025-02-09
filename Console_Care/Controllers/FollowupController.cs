using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class FollowupController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> user;

        public FollowupController(Appdbcontext appdbcontext, UserManager<Appuser> user)
        {
            this.appdbcontext = appdbcontext;
            this.user = user;
        }
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            var followUps = appdbcontext.followUp.Include(x=>x.Customer).Include(x=>x.Employee).ToList();
            var data = new List<followupViewModel>();
            foreach (var item in followUps)
            {
                var realdata = new followupViewModel();
                var iti = await appdbcontext.itineraries.Where(x => x.Id == item.Customer.ItineraryId).Select(x=>x.FaultStatement).SingleOrDefaultAsync();
                realdata.Id = item.Id;
                realdata.WarrantyTime = item.WarrantyTime;
                realdata.NameofCustomer=item.Customer.Name;
                realdata.NameofEmployee = item.Employee.name;
                realdata.Maintenance_Implementation_Date = item.Maintenance_Implementation_Date;
                realdata.LastFollowUpDate = item.LastFollowUpDate;
                realdata.NextFollowUpDate = item.NextFollowUpDate;
                realdata.FaultStatement = iti;
                realdata.stateOfFolowUp = item.stateOfFolowUp;
                realdata.SuggestionsAndIssues = item.SuggestionsAndIssues;
                realdata.TypeOfCustomer=item.Customer.TypeOfCustomer;
                realdata.IdOfCustomer=item.IdOfCustomer;
                realdata.IdOfEmployee=item.IdOfEmployee;

                data.Add(realdata);

            }
            if (User.Identity.IsAuthenticated == true)
            {
                var datauser = await user.FindByNameAsync(User.Identity.Name);
                ViewBag.name = datauser.name;
            }
            return View(data);
        }

        //----------------EditData-------------
        [HttpGet]
        public async Task< IActionResult> EditData(int id)
        {
            var follow= await appdbcontext.followUp.Include(x=>x.Customer).Include(x=>x.Employee).SingleOrDefaultAsync(x=>x.Id==id);
            var iti = await appdbcontext.itineraries.Where(x=>x.Id==follow.Customer.ItineraryId).Select(x=>x.FaultStatement).SingleOrDefaultAsync();
            follow.TypeOfCustomer = follow.Customer.TypeOfCustomer;
            follow.FaultStatement=iti;
            TempData["followid"] = id;
            ViewBag.emp=await appdbcontext.Employee.ToListAsync();
            return View(follow);
        }
        [HttpPost]
        public async Task<IActionResult> EditData(followUp follow)
        {
            var employee= await appdbcontext.Employee.FirstOrDefaultAsync(x=>x.name==follow.Employee.name);
            follow.Id = (int)TempData["followid"];
            var data = await appdbcontext.followUp.SingleOrDefaultAsync(x=>x.Id==follow.Id);
            data.stateOfFolowUp=follow.stateOfFolowUp;
            data.NextFollowUpDate=follow.NextFollowUpDate;
            data.LastFollowUpDate=follow.LastFollowUpDate;
            data.IdOfEmployee = employee.id;
            data.Maintenance_Implementation_Date=follow.Maintenance_Implementation_Date;
            data.WarrantyTime=follow.WarrantyTime;
            data.SuggestionsAndIssues=follow.SuggestionsAndIssues;
            appdbcontext.followUp.Update(data);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //------------delete-------
        public async Task<IActionResult> Delete(int id)
        {
            var data=await appdbcontext.followUp.SingleOrDefaultAsync(x=>x.Id==id);
             appdbcontext.followUp.Remove(data);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
