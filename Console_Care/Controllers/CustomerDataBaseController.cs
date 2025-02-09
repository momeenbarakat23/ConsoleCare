using Console_Care.CustomerDataBase;
using Console_Care.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class CustomerDataBaseController : Controller
    {
        private readonly ICustomerDataBase customerDataBase;
        private readonly Appdbcontext appdbcontext;

        public CustomerDataBaseController(ICustomerDataBase customerDataBase , Appdbcontext appdbcontext)
        {
            this.customerDataBase = customerDataBase;
            this.appdbcontext = appdbcontext;
        }
        public IActionResult Index()
        {
            return View();
        }
        //-------------------
        [HttpGet]
        public async Task< IActionResult> DetailsPsCafe()
        {
            var list = new List<decimal>();
            var typeofcust = "PsCafe";
             await customerDataBase.AddData(typeofcust);
            
            var result = await appdbcontext.CustomerDataBases.Where(x => x.TypeOfCustomer == typeofcust).ToListAsync();
            foreach (var item in result)
            {
                var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Where(x => x.CustomerDataBasesid == item.id).ToListAsync();
                var sums = data.Sum(x => x.Invoice.Total_Amountafterdisc) - data.Sum(x => x.Invoice.Paid);
                list.Add(sums);

            }
            ViewBag.remaining = list;
            return View(result);
        } 
        [HttpGet]
        public async Task< IActionResult> DetailsPsCafecontect()
        {
            var list = new List<decimal>();
            var typeofcust = "PsCafe(عقد)";
             await customerDataBase.AddData(typeofcust);
            
            var result = await appdbcontext.CustomerDataBases.Where(x => x.TypeOfCustomer == typeofcust).ToListAsync();
            foreach (var item in result)
            {
                var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Where(x => x.CustomerDataBasesid == item.id).ToListAsync();
                var sums = data.Sum(x => x.Invoice.Total_Amountafterdisc) - data.Sum(x => x.Invoice.Paid);
                list.Add(sums);

            }
            ViewBag.remaining = list;
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> DetailsHallEffect()
        {
            var list = new List<decimal>();
            var typeofcust = "Hall Effect";
            await customerDataBase.AddData(typeofcust);
            var result = await appdbcontext.CustomerDataBases.Where(x=>x.TypeOfCustomer== typeofcust).ToListAsync();
            foreach (var item in result)
            {
                var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Where(x => x.CustomerDataBasesid == item.id).ToListAsync();
                var sums = data.Sum(x => x.Invoice.Total_Amountafterdisc) - data.Sum(x => x.Invoice.Paid);
                list.Add(sums);

            }
            ViewBag.remaining = list;
            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> DetailsHome() 
        {
            var list= new List<decimal>();
            var typeofcust = "Home";
            await customerDataBase.AddData(typeofcust);
            var result = await appdbcontext.CustomerDataBases.Where(x => x.TypeOfCustomer == typeofcust).ToListAsync();
            foreach (var item in result)
            {
                var data = await appdbcontext.CustomerDataBasessInvoice.Include(x => x.Invoice).Where(x => x.CustomerDataBasesid == item.id).ToListAsync();
                var sums= data.Sum(x => x.Invoice.Total_Amountafterdisc) - data.Sum(x => x.Invoice.Paid);
                list.Add(sums);

            }
            ViewBag.remaining = list;

            return View(result);
        }
    }
}
