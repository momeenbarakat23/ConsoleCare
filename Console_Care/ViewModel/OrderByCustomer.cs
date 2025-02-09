using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class OrderByCustomer
    {
        public int Id { get; set; }
        [Display(Name = "الاسم")]
        public string Name { get; set; }
        [RegularExpression("[0-9]{11}")]
        [Display(Name = "رقم الهاتف")]
        public string Phone { get; set; }
        [Display(Name = "نوع الخدمه")]
        public string TypeOfCustomer { get; set; }
        [Display(Name = "نوع الجهاز")]
        public string Ps4OrPs5 { get; set; }
        [Display(Name = "العنوان")]
        public string Address { get; set; }
        [Display(Name = "المدينه")]
        public string city { get; set; }
        [Display(Name="تفاصيل العطل")]
        [Required]
        public string Order { get; set; }
        
    }
}
