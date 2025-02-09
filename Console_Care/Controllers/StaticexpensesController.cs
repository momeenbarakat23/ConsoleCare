using Console_Care.Migrations;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class StaticexpensesController : Controller
    {
        private readonly Appdbcontext appdbcontext;
         


        public StaticexpensesController(Appdbcontext appdbcontext )
        {
            this.appdbcontext = appdbcontext;
        }
        public IActionResult Index()
        {
            //ViewBag.total = await appdbcontext.static_expenses.SumAsync(x => x.Total);
            return View();
        }
        public async Task<IActionResult> Detials(string NameOfDepartment)
        {
            ViewBag.NameOfDepartment = NameOfDepartment;
            var result = await appdbcontext.static_expenses.Where(x => x.NameOfDepartment == NameOfDepartment).ToListAsync();
            if (result !=null)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i].Total = (decimal)(result[i].January 
                        + result[i].February 
                        + result[i].March
                        + result[i].April 
                        + result[i].May
                        + result[i].June
                        + result[i].July 
                        + result[i].August
                        + result[i].September 
                        + result[i].October 
                        + result[i].November 
                        + result[i].December);
                }
                List<decimal> TotalOFMonth = [];
                TotalOFMonth.Add((decimal)result.Sum(x => x.January));
                TotalOFMonth.Add((decimal)result.Sum(x => x.February));
                TotalOFMonth.Add((decimal)result.Sum(x => x.March));
                TotalOFMonth.Add((decimal)result.Sum(x => x.April));
                TotalOFMonth.Add((decimal)result.Sum(x => x.May));
                TotalOFMonth.Add((decimal)result.Sum(x => x.June));
                TotalOFMonth.Add((decimal)result.Sum(x => x.July));
                TotalOFMonth.Add((decimal)result.Sum(x => x.August));
                TotalOFMonth.Add((decimal)result.Sum(x => x.September));
                TotalOFMonth.Add((decimal)result.Sum(x => x.October));
                TotalOFMonth.Add((decimal)result.Sum(x => x.November));
                TotalOFMonth.Add((decimal)result.Sum(x => x.December));
                ViewBag.totalofsalary=result.Sum(x=>x.salary);
                ViewBag.total=result.Sum(x=>x.Total);
                ViewBag.TotalOFMonth = TotalOFMonth;
            }

            return View(result);

        }
        [HttpGet]
        public IActionResult Add()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(static_expenses static_Expenses)
        {
            try
            {
               
                
                    static_Expenses.Total = (decimal)(static_Expenses.January
                        + static_Expenses.February
                        + static_Expenses.March
                        + static_Expenses.April
                        + static_Expenses.May
                        + static_Expenses.June
                        + static_Expenses.July
                        + static_Expenses.August
                        + static_Expenses.September
                        + static_Expenses.October
                        + static_Expenses.November
                        + static_Expenses.December);
                var cash = new Cash();
                cash.AccountName = static_Expenses.typeofcash;
                cash.Outgoing = static_Expenses.Total;
                cash.MoneyOut = static_Expenses.NameOfDepartment;
                cash.Date = (DateTime)static_Expenses.DateTime;
                cash.Nameoftech = static_Expenses.Employee;
                cash.TotalAmount = -static_Expenses.Total;
                
                appdbcontext.Cash.Add(cash);
                await appdbcontext.static_expenses.AddRangeAsync(static_Expenses);
                    await appdbcontext.SaveChangesAsync();
                   return RedirectToAction("Detials", new { NameOfDepartment =static_Expenses.NameOfDepartment});
                
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(static_Expenses);
        }
        [HttpGet]
        public async Task< IActionResult> Edit(int id)
        {
            var data = await appdbcontext.static_expenses.SingleOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(static_expenses static_Expenses)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    static_Expenses.Total = (decimal)(static_Expenses.January
                        + static_Expenses.February
                        + static_Expenses.March
                        + static_Expenses.April
                        + static_Expenses.May
                        + static_Expenses.June
                        + static_Expenses.July
                        + static_Expenses.August
                        + static_Expenses.September
                        + static_Expenses.October
                        + static_Expenses.November
                        + static_Expenses.December);
                    var cash = await appdbcontext.Cash.FirstOrDefaultAsync(x => x.Date == static_Expenses.DateTime && x.MoneyOut == static_Expenses.NameOfDepartment);
                    cash.AccountName = static_Expenses.typeofcash;
                    cash.Outgoing = static_Expenses.Total;
                    cash.MoneyOut = static_Expenses.NameOfDepartment;
                    cash.Date = (DateTime)static_Expenses.DateTime;
                    cash.Nameoftech = static_Expenses.Employee;
                    cash.TotalAmount = -static_Expenses.Total;
                    appdbcontext.Cash.Update(cash);
                    appdbcontext.static_expenses.Update(static_Expenses);
                    await appdbcontext.SaveChangesAsync();
                   return RedirectToAction("Detials", new { NameOfDepartment =static_Expenses.NameOfDepartment});
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(static_Expenses);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data=await appdbcontext.static_expenses.SingleOrDefaultAsync(x => x.Id==id);
            var cash = await appdbcontext.Cash.FirstOrDefaultAsync(x => x.Date == data.DateTime && x.MoneyOut == data.NameOfDepartment);
            if (cash != null)
            {
                appdbcontext.Cash.Remove(cash);
            }
            appdbcontext.static_expenses.Remove(data);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Detials", new { NameOfDepartment = data.NameOfDepartment });

        }
        [HttpGet]
        public async Task<IActionResult> employeemoney(int id)
        {
            var data = await appdbcontext.static_expenses.FirstOrDefaultAsync(x => x.Id == id);
            var emp = new employeemoneyViewmodel();
            emp.predecessor = data.predecessor;
            emp.incentive= data.incentive;
            emp.salary= data.salary;
            emp.navsalary= data.navsalary;
            emp.discount= data.discount;
            emp.Employee = data.Employee;
            emp.Id= id;
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> employeemoney(employeemoneyViewmodel employeemoney)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data= await appdbcontext.static_expenses.FirstOrDefaultAsync(x => x.Id==employeemoney.Id);
                    data.predecessor=employeemoney.predecessor;
                    data.incentive = employeemoney.incentive;
                    data.salary=employeemoney.salary;
                    data.navsalary = employeemoney.salary+ employeemoney.predecessor- employeemoney.incentive- employeemoney.discount;
                    data.discount = employeemoney.discount;
                    data.Employee= employeemoney.Employee;
                    appdbcontext.static_expenses.Update(data);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Detials", new { NameOfDepartment =data.NameOfDepartment});

                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View(employeemoney);

        }
    }
}
