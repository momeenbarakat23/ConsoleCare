using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class employeemoneyViewmodel
    {
        public int Id { get; set; }
   
        [Display(Name = "الموظف")]
        public string? Employee { get; set; }

        [Display(Name = "الحوافز")]
        public decimal incentive { get; set; }
        [Display(Name = "السلف")]
        public decimal predecessor { get; set; }
        [Display(Name = "خصومات")]
        public decimal discount { get; set; }
        [Display(Name = "الصافي")]
        public decimal navsalary { get; set; }
        [Display(Name = "اصل المرتب")]
        public decimal salary { get; set; }
    }
}
