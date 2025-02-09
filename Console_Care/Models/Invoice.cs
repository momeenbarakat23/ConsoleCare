using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.Models
{
    public class Invoice
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="اسم الفني")]
        public string nameoftechnecal { get; set; }
        public string? nameofcustomer { get; set; }
        [Display(Name = "نوع الفاتوره")]
        public string typeofinvoice { get; set; } 
        [Display(Name = "نوع الدفع")]
        public string typeofcash { get; set; }
        public string? type { get; set; }
        [Display(Name ="رقم")]
        public List< int>? number { get; set; }
        [Display(Name = "المواصفات")]
        public List<string> item { get; set; }
        [Display(Name = "الكميه")]
        public List<int> quantity { get; set; }
        [Display(Name = "السعر")]
        public List<decimal>? price { get; set; }
        public List<decimal>? TotalpriceForitem { get; set; }
        [Display(Name = "خصم قطع")]
        public List<decimal>? Discount { get; set; }
        [Display(Name = "خصم ضمان")]
        public decimal? Discountwarranty { get; set; }
        [Display(Name = "   خصومات (%)")]
        public decimal? specialDiscount { get; set; }
        [Display(Name = "المبلغ الكلي")]
        public decimal Total_Amount {  get; set; }
        [Display(Name = "المبلغ المستحق بعد الخصم")]
        public decimal Total_Amountafterdisc {  get; set; }
        [Display(Name = "المدفوع")]
        public decimal Paid { get; set; }
        public decimal remaining { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime? DateTime { get; set; }
        public List<CustomerDataBasesInvoice>? CustomerDataBasesInvoice { get; set; }
        public Customer? Customer { get; set; }

        

    }
}
