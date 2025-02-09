using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Other_expenses
    {
        public int Id { get; set; }
        [Display(Name = "قيمة المصروف")]
        public decimal ExpenseValue { get; set; }
        [Display(Name = "جهة الصرف")]
        public string DisbursementName { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime DateTime { get; set; }
        [Display(Name = "نوع الدفع")]
        [MaxLength(50)]
        public string? typeofcash { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Note { get; set; }
    }
}
