using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Cash
    {
        public int Id { get; set; }
        [Display(Name ="الحساب")]
        public string AccountName { get; set; }
        [Display(Name = " الداخل")] 
        public decimal paid { get; set; }
        [Display(Name = " الخارج")]
        public decimal Outgoing { get; set; }
        [Display(Name = "خارج الي")]
        [MaxLength(300)]
        public string? MoneyOut { get; set; }
        [Display(Name = "الاجمالي")]
        public decimal? TotalAmount { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
        [Display(Name = "اسم العميل")]
        public string? Nameofcust { get; set; }
        [Display(Name = "اسم المهندس")]
        public string? Nameoftech { get; set; } 
       
        [Display(Name = "رقم الحساب")]
        public string? NoOfaccount { get; set; }
        [Display(Name = "رقم الفاتوره")]
        public string? NoOfInvoice { get; set; }
        [Display(Name = "البيان")]
        public string? Statement { get; set; }
    }
}
