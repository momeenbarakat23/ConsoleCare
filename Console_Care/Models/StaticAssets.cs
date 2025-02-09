using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class StaticAssets
    {
        public int Id { get; set; }
        [Display(Name = "السعر")]
        public decimal Price { get; set; }  
        [Display(Name = "الاجمالي")]
        public decimal Total { get; set; }
        [Display(Name = "العدد")]
        public int Number { get; set; }
        [Display(Name = "البيان")]
        public string Statement { get; set; } 
        [Display(Name = "نوع الاصول الثابته")]
        public string typeOfStaticAssets { get; set; }
        [Display(Name = "نوع الدفع")]
        [MaxLength(50)]
        public string? typeofcash { get; set; }
        [Display(Name = "مواصفات")]
        public string Specifications { get; set; }
        [Display(Name = "تاريخ الشراء")]
        public DateTime DateTime { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Note { get; set; }
    }
}
