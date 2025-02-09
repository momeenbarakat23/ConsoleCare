using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class RegisterRoleViewModel
    {
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public string RoleName { get; set; }
    }
}
