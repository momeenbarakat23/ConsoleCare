using Console_Care.DeleteAllData;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class BankingController : Controller
    {
        private readonly IDelete delete;
        private readonly Appdbcontext appdbcontext;

        public BankingController(IDelete delete ,Appdbcontext appdbcontext)
        {
            this.delete = delete;
            this.appdbcontext = appdbcontext;
        }
        public async Task< IActionResult> Index()
        {
            var data = new BankingViewModel();
            data.InvoiceValue=await appdbcontext.Purchase_Payments.SumAsync(x => x.InvoiceValue);
            data.PaidValue =await appdbcontext.Purchase_Payments.SumAsync(x => x.PaidValue);
            data.remaining =await appdbcontext.Purchase_Payments.SumAsync(x => x.remaining);

            data.TotalOtherExpenses = await appdbcontext.Other_expenses.SumAsync(x => x.ExpenseValue);
            data.TotalCash = await appdbcontext.Cash.SumAsync(x => x.TotalAmount);
            data.Total_AmountStaticAssets = await appdbcontext.StaticAssets.SumAsync(x => x.Total);

            data.Total_AmountInvoice = await appdbcontext.Invoices.Where(x=>x.type==null).SumAsync(x => x.Total_Amount);
            data.PaidInvoice = await appdbcontext.Invoices.Where(x => x.type == null).SumAsync(x => x.Paid);
            data.remainingInvoice = await appdbcontext.Invoices.Where(x => x.type == null).SumAsync(x => x.remaining);
            

            data.Total_expenses = await appdbcontext.static_expenses.SumAsync(x => x.Total)+ data.TotalOtherExpenses;
            data.Total_Amountpaid = (await appdbcontext.Cash.SumAsync(x => x.Outgoing)) - data.PaidValue - data.Total_AmountStaticAssets -data.Total_expenses;
            data.Total_AmountIn = (await appdbcontext.Cash.SumAsync(x => x.paid)); /*- await appdbcontext.Invoices.Where(x => x.type == null).SumAsync(x=>x.Paid);*/

            ViewBag.totalstatic_expenses = await appdbcontext.static_expenses.SumAsync(x => x.Total);
            return View(data);
        }

        [HttpGet]
        public IActionResult DeleteAllData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAllDataconferm()
        {
            var BuyingMaterials = "BuyingMaterials";
            var Cash = "Cash";
            var Purchase_Payments = "Purchase_Payments";
            var Other_expenses = "Other_expenses";
            var static_expenses = "static_expenses";
            var StaticAssets = "StaticAssets";
            var Closeday = "Closeday";
            var resultBuyingMaterials = await delete.Deleteasync(BuyingMaterials);
            var resultCash = await delete.Deleteasync(Cash);
            var resultPurchase_Payments = await delete.Deleteasync(Purchase_Payments);
            var resultOther_expenses = await delete.Deleteasync(Other_expenses);
            var resultStaticAssets = await delete.Deleteasync(StaticAssets);
            var resultCloseday = await delete.Deleteasync(Closeday);
            if (resultBuyingMaterials == false || resultCash == false || resultPurchase_Payments == false || resultOther_expenses == false || resultStaticAssets == false || resultCloseday == false)
            {
                return View("DeleteAllData");
            }

            return RedirectToAction("Index");


        }
    }
}
