using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class BuyingMaterials
    {
        public int id { get; set; }
        [Display(Name = "اسم الخامه")]
        public string NameOfMaterials { get; set; }
        [Display(Name = "اسم المشتري")]
        public string NameOfBuyer { get; set; }
        [Display(Name = "تاريخ الشراء")]
        public DateTime DateTime { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Note { get; set; }
        [Display(Name = "نوع الدفع")]
        [MaxLength(50)]
        public string? typeofcash { get; set; }
        [Display(Name = "سعر الشراء للقطعه")]
        public decimal PriceofPiece { get; set; }
        [Display(Name = "عدد القطع")]
        public int NoPiece { get; set; }
        [Display(Name = "الاجمالي")]
        public decimal? TotalPrice { get; set; } 
    }
}
