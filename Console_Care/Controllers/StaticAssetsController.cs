using Console_Care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class StaticAssetsController : Controller
    {
        private readonly Appdbcontext appdbcontext;

        public StaticAssetsController(Appdbcontext appdbcontext)
        {
            this.appdbcontext = appdbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Detials(string typeofStaticAssets)
        {
            var result = await appdbcontext.StaticAssets.Where(x => x.typeOfStaticAssets == typeofStaticAssets).ToListAsync();
            return View(result);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Add(StaticAssets StaticAssets)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StaticAssets.Total = StaticAssets.Number * StaticAssets.Price;
                    var cash = new Cash();
                    cash.AccountName = StaticAssets.typeofcash;
                    cash.Outgoing = StaticAssets.Total;
                    cash.MoneyOut = StaticAssets.Statement;
                    cash.Date = StaticAssets.DateTime;
                    cash.Statement = StaticAssets.Note;
                    cash.TotalAmount = -StaticAssets.Total;
                    appdbcontext.Cash.Add(cash);
                    await appdbcontext.StaticAssets.AddRangeAsync(StaticAssets);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Detials", new { typeofStaticAssets = StaticAssets.typeOfStaticAssets });
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
            var data = await appdbcontext.StaticAssets.SingleOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(StaticAssets StaticAssets)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StaticAssets.Total = StaticAssets.Number * StaticAssets.Price;
                    var cash = await appdbcontext.Cash.FirstOrDefaultAsync(x => x.Date == StaticAssets.DateTime && x.MoneyOut == StaticAssets.Statement);
                    cash.AccountName = StaticAssets.typeofcash;
                    cash.Outgoing = StaticAssets.Total;
                    cash.MoneyOut = StaticAssets.Statement;
                    cash.Date = StaticAssets.DateTime;
                    cash.Statement = StaticAssets.Note;
                    cash.TotalAmount = -StaticAssets.Total;
                    appdbcontext.Cash.Update(cash);
                    appdbcontext.StaticAssets.Update(StaticAssets);
                    await appdbcontext.SaveChangesAsync();
                    return RedirectToAction("Detials", new { typeofStaticAssets = StaticAssets.typeOfStaticAssets });
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }
        //---------------------------------------------------
        public async Task<IActionResult> Delete(int id)
        {
            var StaticAsset = await appdbcontext.StaticAssets.FindAsync(id);
            var cash = await appdbcontext.Cash.FirstOrDefaultAsync(x => x.Date == StaticAsset.DateTime && x.MoneyOut == StaticAsset.Statement);
            if (cash != null)
            {
                appdbcontext.Cash.Remove(cash);
            }
            appdbcontext.StaticAssets.Remove(StaticAsset);
            await appdbcontext.SaveChangesAsync();
            return RedirectToAction("Detials", new { typeofStaticAssets = StaticAsset.typeOfStaticAssets });
        }
    }
}
