using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Console_Care.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<Appuser> userManager;
        private readonly Appdbcontext appdbcontext;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<Appuser> userManager ,Appdbcontext appdbcontext)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.appdbcontext = appdbcontext;
        }
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                var roleUser = new IdentityRole();
                roleUser.Name = role.NameRole;
                var result = await roleManager.CreateAsync(roleUser);
                if (result.Succeeded)
                {
                    return View();

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();

        }


        [HttpGet]
        public async Task< IActionResult> Register()
        {
            ViewBag.roles=await roleManager.Roles.ToListAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRoleViewModel regirster)
        {
            if (ModelState.IsValid)
            {
                var user = new Appuser();
                user.UserName=Guid.NewGuid().ToString();
                user.name = regirster.Name;
                user.Email = regirster.Email;
                user.PasswordHash = regirster.Password;
                if (await userManager.FindByEmailAsync(user.Email) is not null)
                {
                    ModelState.AddModelError("", "Email Is Already Exist");
                }
                var result = await userManager.CreateAsync(user, regirster.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, regirster.RoleName);
                    return RedirectToAction("Index", "Order");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            ViewBag.roles = await roleManager.Roles.ToListAsync();
            return View(regirster);

        }
    }
}