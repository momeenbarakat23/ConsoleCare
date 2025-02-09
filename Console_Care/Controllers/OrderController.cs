using Console_Care.DeleteAllData;
using Console_Care.identity;
using Console_Care.Models;
using Console_Care.orderforcust;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace Console_Care.Controllers
{
    public class OrderController : Controller
    {
        private readonly Iorder order;
        private readonly Appdbcontext dbcontext;
        private readonly UserManager<Appuser> user;


        public OrderController(Iorder order , Appdbcontext dbcontext ,UserManager<Appuser> user )
        {
            this.order = order;
            this.dbcontext = dbcontext;
            this.user = user;
        }
        public IActionResult Index()
        {
            var data=dbcontext.customer.ToList();
        return View(data); 
        }
        [HttpGet]
        public async Task< IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                var datauser = await user.FindByNameAsync(User.Identity.Name);
                ViewBag.name = datauser.name;
                ViewBag.city = datauser.city;
                ViewBag.addrees = datauser.Address;
                ViewBag.phone = datauser.PhoneNumber;

            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderByCustomer orderByCustomerorder)
        {
            
                
                try
                {
                    if (ModelState.IsValid)
                    {
                    var result = await order.CreateOrder(orderByCustomerorder);
                    TempData["mes"] = "created";
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                    return RedirectToAction("Create");
                }

            
            return RedirectToAction("Index","Home");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await dbcontext.customer.SingleOrDefaultAsync(x => x.Id == id);
            return View(data);
        }
        
        public async Task< IActionResult> SaveEdit(OrderByCustomer customer)
        {
            
                try
                {
                    if (ModelState.IsValid)
                    {
                    var result = await order.EditOrder(customer);
                    var user= await dbcontext.CustomerDataBases.SingleOrDefaultAsync(x=>x.Phone==customer.Phone);
                    user.TypeOfCustomer= customer.TypeOfCustomer;
                    dbcontext.CustomerDataBases.Update(user);
                   await dbcontext.SaveChangesAsync();
                    return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message.ToString());
                }

            
            return RedirectToAction("Index");

        }

        //----------------deleteallData---------
       

    }
}
