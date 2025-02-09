using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
