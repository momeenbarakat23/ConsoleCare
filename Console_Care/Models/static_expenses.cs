using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class static_expenses    
    {
        public int Id { get; set; }
        [Display(Name = "القسم")]
        public string NameOfDepartment { get; set; }
        [Display(Name = "نوع الدفع")]
        [MaxLength(50)]
        public string? typeofcash { get; set; }
        [Display(Name = "الموظف")]
        public string? Employee { get; set; }
        [Display(Name = "يناير ")]
        public decimal January { get; set; }  
        [Display(Name = "فبراير")]
        public decimal February { get; set; }  
        [Display(Name = "مارس")]
        public decimal March { get; set; }  
        [Display(Name = "أبريل")]
        public decimal April { get; set; } 
        [Display(Name = "مايو")]
        public decimal May { get; set; }
        [Display(Name = "يونيو")]
        public decimal June { get; set; }
        [Display(Name = "يوليو")]
        public decimal July { get; set; }
        [Display(Name = "أغسطس")]
        public decimal August { get; set; }
        [Display(Name = "سبتمبر")]
        public decimal September { get; set; }
        [Display(Name = "أكتوبر")]
        public decimal October { get; set; }
        [Display(Name = "نوفمبر")]
        public decimal November { get; set; }
        [Display(Name = "ديسمبر")]
        public decimal December { get; set; }


        [Display(Name = "الاجمالي")]
        public decimal Total { get; set; } 
        [Display(Name = "المطلوب قبل نهاية الشهر")]
        public decimal Target { get; set; }    
        [Display(Name = "اصل المرتب")]
        public decimal salary { get; set; }
        
        [Display(Name = "الحوافز")]
        public decimal incentive { get; set; }
        [Display(Name = "السلف")]
        public decimal predecessor { get; set; } 
        [Display(Name = "خصومات")]
        public decimal discount { get; set; } 
        [Display(Name = "الصافي")]
        public decimal navsalary { get; set; } 

        [Display(Name = "تاريخ الشراء")]
        public DateTime? DateTime { get; set; }

    }
}
