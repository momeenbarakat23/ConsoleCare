using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Closeday
    {
        public int Id { get; set; }
        [Display(Name = "التاريخ")]
        public DateTime Date { get; set; }
        [Display(Name = "الأصول")]
        public string Origins {  get; set; }
        [Display(Name = "النقدية")]
        public decimal? Cash {  get; set; }
        [Display(Name = "المبيعات")]
        public decimal? Sales {  get; set; }
        [Display(Name = "مدفوع مبيعات")]
        public decimal? PaidSales {  get; set; }
        [Display(Name = "متبقي مبيعات")]
        public decimal? Remainingsales {  get; set; }
        [Display(Name = "مشتريات")]
        public decimal? Procurement {  get; set; }
        [Display(Name = "مدفوع مشتريات")]
        public decimal? PaidPurchases {  get; set; }
        [Display(Name = "متبقي مشتريات")]
        public decimal? Remainingpurchases {  get; set; }
        [Display(Name = "مصروفات")]
        public decimal? Expenses {  get; set; }
    }
}
