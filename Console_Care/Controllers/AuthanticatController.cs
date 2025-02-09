using Console_Care.identity;
using Console_Care.Securty;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mail;
using System.Net;


namespace Console_Care.Controllers
{
    public class AuthanticatController : Controller
    {
        private readonly SignInManager<Appuser> signInManager;
        private readonly IAuth auth;
        private readonly UserManager<Appuser> userManager;
   
        public AuthanticatController(SignInManager<Appuser> signInManager , IAuth auth , UserManager<Appuser> _userManager )
        {
            this.signInManager = signInManager;
            this.auth = auth;
            this.userManager = _userManager;

        }
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await auth.LoginAsync(loginViewModel);
                if (result.Email !=null && result.Password!=null )
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("خطأ في تسجيل الدخول :", "الايميل او كلمه المرور غلط");

            return View(loginViewModel);
        
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await auth.RegisterAsync(register);
                    if (result.UserName != null)
                    {
                        return RedirectToAction("Index", "Home");

                    }
                    
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
            }
            
            
            return View(register);


        }



        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }



        


    }
}
