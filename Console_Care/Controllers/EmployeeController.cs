using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Console_Care.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> user;
        public int idofcust { get; set; }

        public EmployeeController(Appdbcontext appdbcontext, UserManager<Appuser> user)
        {
            this.appdbcontext = appdbcontext;
            this.user = user;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            await appdbcontext.Employee.AddRangeAsync(employee);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("displayEmployee",employee);
        }
        //------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> displayEmployee()
        {
         
            var dataemp = appdbcontext.Employee.ToList();
            

            var group = await appdbcontext.Cash
      .GroupBy(c => c.Nameoftech)
    .Select(g => new
    {
        idofcust = g.Count(),
        Nameoftech = g.Key,
        paid=g.Sum(x=>x.paid)
    })
    .ToListAsync();
            foreach ( var d in group)
            {
                var emp = dataemp.SingleOrDefault(x => x.name == d.Nameoftech);
                if (emp !=null)
                {
                    if (emp.paid != d.paid && emp.countinvoice != d.idofcust)
                    {
                        emp.paid = d.paid;
                        emp.countinvoice = d.idofcust;
                        appdbcontext.Update(emp);
                        await appdbcontext.SaveChangesAsync();
                    }
                }
                
                   
            }
            return View(dataemp);
        }
        //------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            var data = await appdbcontext.Employee.SingleOrDefaultAsync(x => x.id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee)
        {

            appdbcontext.Employee.Update(employee);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("displayEmployee");
        }
        //---------------------------------------------------
        public async Task<IActionResult> deleteEmployee(Employee employee)
        {
            appdbcontext.Employee.Remove(employee);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("displayEmployee");
        }





    }
}
