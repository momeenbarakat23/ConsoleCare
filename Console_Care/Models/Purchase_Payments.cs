using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Purchase_Payments
    {
        public int Id { get; set; }
        [Display(Name = "قيمة الفاتورة")]
        public decimal InvoiceValue { get; set; } 
        [Display(Name = "قيمة المدفوع")]
        public decimal PaidValue { get; set; }  
        [Display(Name = "المتبقي (واجب الدفع)")]
        public decimal? remaining { get; set; }
        [Display(Name = "اسم المورد")]
        public string SupplierName { get; set; }  
        [Display(Name = "رقم الفاتورة")]
        public string Invoicenumber { get; set; }
        [Display(Name = "نوع الدفع")]
        [MaxLength(50)]
        public string? typeofcash { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime DateTime { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Note { get; set; }
    }
}
