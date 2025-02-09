
using Console_Care.Migrations;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class CashController : Controller
    {
        private readonly Appdbcontext appdbcontext;


        public CashController(Appdbcontext appdbcontext )
        {
            this.appdbcontext = appdbcontext;
        }
        public async  Task< IActionResult> Index()
        {
            try
            {
                var result = new CashViewModel();
                string voda = "VodafoneCash";
                string emp = "عهده";
                string instapay = "Instapay";
                string storage = "الخزنه";
                var groupedData = await  appdbcontext.Cash
                    .GroupBy(c => c.AccountName)
                    .Select(g => new
                    {
                        AccountName = g.Key,
                        Paid = g.Sum(c => c.paid),
                        Outgoing = g.Sum(c => c.Outgoing),
                        TotalAmount = g.Sum(c => c.TotalAmount)
                    })
                    .ToListAsync();

                // تخزين في TempData
                foreach (var item in groupedData)
                {
                    if (item.AccountName == voda)
                    {
                        result.PaidVoda =item.Paid;
                        result.OutgoingVoda = item.Outgoing;
                        result.TotalAmountVoda = (decimal)item.TotalAmount;
                    }
                    else if (item.AccountName == emp)
                    {
                       result.PaidEmp = item.Paid;
                        result.OutgoingEmp = item.Outgoing;
                        result.TotalAmountEmp = (decimal)item.TotalAmount;
                    }
                    else if (item.AccountName == instapay)
                    {
                        result.PaidInstapay = item.Paid;
                        result.OutgoingInstapay = item.Outgoing;
                        result.TotalAmountInstapay = (decimal)item.TotalAmount;
                    }
                    else if (item.AccountName == storage)
                    {
                        result.Paidstorage = item.Paid;
                        result.Outgoingstorage = item.Outgoing;
                        result.TotalAmountstorage = (decimal)item.TotalAmount;
                    }
                }
                return View(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return View();


        }
        //-------------------
        [HttpGet]
        public async Task<IActionResult> Details(string typeofcash)
        {
            var result = await appdbcontext.Cash.Where(x => x.AccountName == typeofcash).ToListAsync();
            if (typeofcash=="عهده")
            {
                ViewBag.num = 1;
            }
            return View(result);
        }
        //-------------------
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cash cash)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cash.TotalAmount = cash.paid - cash.Outgoing;
                    await appdbcontext.Cash.AddRangeAsync(cash);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Details", new { typeofcash = cash.AccountName });
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
        //-------------------
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await appdbcontext.Cash.SingleOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cash cash)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cash.TotalAmount = cash.paid - cash.Outgoing;
                     appdbcontext.Cash.Update(cash);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Details", new { typeofcash = cash.AccountName });
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
        //---------------------------------------------------
        public async Task<IActionResult> Delete (Cash cash , string name)
        {
            appdbcontext.Cash.Remove(cash);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Details", new { typeofcash = name });
        }
        public async Task<IActionResult> ConvertToStorage(int id)
        {
            var cash = await appdbcontext.Cash.SingleOrDefaultAsync(x=>x.Id==id);
            cash.AccountName = "الخزنه";
            appdbcontext.Cash.Update(cash);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Details", new { typeofcash = cash.AccountName });
        }


    }
}
