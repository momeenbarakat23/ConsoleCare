using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name ="اسم المستخدم")]
        public string UserName { get; set; }
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$",ErrorMessage = "example@example.com")]
        [Display(Name = "البريد الألكتروني" )]
        public string Email { get; set; }

        [RegularExpression("[0-9]{11}",ErrorMessage ="01xxxxxxxxx")]
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        //[RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",ErrorMessage = "كلمة المرور لازم يبقى 8 حروف على الأقل، وفيه حرف كبير، صغير، رقم، ورمز زي @ أو كده ..")]
        public string Password { get; set; }
        [Display(Name = "تأكيد كلمة المرور")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "العنوان")]
        public string Address { get; set; }
        [Display(Name = "المدينه")]
        public string city { get; set; }

        public string? message { get; set; }

    }
}
