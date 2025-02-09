using Console_Care.identity;
using Console_Care.Models;
using Console_Care.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Console_Care.Securty
{
    public class Auth : IAuth
    {
        private readonly Appdbcontext appdbcontext;
        private readonly UserManager<Appuser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<Appuser> signInManager;

        public Auth(Appdbcontext appdbcontext , UserManager<Appuser> userManager ,RoleManager<IdentityRole> roleManager
            ,SignInManager<Appuser> signInManager)
        {
            this.appdbcontext = appdbcontext;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        public async Task<LoginViewModel> LoginAsync(LoginViewModel Login)
        {
            var result = new LoginViewModel();
            var User = await userManager.FindByEmailAsync(Login.Email);
            if (User != null)
            {
                var checkpass = await userManager.CheckPasswordAsync(User, Login.Password);
                if (checkpass)
                {
                    await signInManager.SignInAsync(User, Login.RememberMe);
                    return Login;
                }

            }
            return result;
        }

        public async Task<RegisterViewModel> RegisterAsync(RegisterViewModel register)
        {
            var result = new RegisterViewModel();
            var checkemail = await userManager.FindByEmailAsync(register.Email);
            if (checkemail !=null)
            {
                result.message = "الايميل متسجل قبل كده";
                return result;
            }
            
            var NewUser = new Appuser();
            NewUser.UserName=Guid.NewGuid().ToString();
            NewUser.Address = register.Address;
            NewUser.Email = register.Email;
            NewUser.name= register.UserName;
            NewUser.city=register.city;
            NewUser.PhoneNumber=register.Phone;
            var create =await userManager.CreateAsync(NewUser,register.Password);
            if (create.Succeeded) 
            {
                await signInManager.SignInAsync(NewUser,false);
                return register;

            }
            return result;

        }

        public Task<RoleViewModel> RoleAsync(RoleViewModel register)
        {
            throw new NotImplementedException();
        }
    }
}
