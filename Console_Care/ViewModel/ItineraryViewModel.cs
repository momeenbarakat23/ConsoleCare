using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class ItineraryViewModel
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name = "اسم الفني")]
        public string? Nameoftech { get; set; }
        [Required]
        [Display(Name = "اسم المساعد")]
        public string? NameOfAssistant { get; set; }
        [Required]
        [Display(Name = "باقي التيم")]
        public string? RemainingTeam { get; set; }
        [Display(Name = "اسم مدخل البيانات")]
        public string? DataEntryName { get; set; }
        [Display(Name = "نوع العميل")]
        public string? typeofcustomer { get; set; }
        [Required]
        [Display(Name = "تاريخ الزياره")]
        public DateTime? VisitDate { get; set; }
        [Required]
        [Display(Name = "نوع الزياره")]
        public string? VisitClassification { get; set; }
        [Display(Name = "بيان العطل")]
        public string? FaultStatement { get; set; }
        [Display(Name = "حاله الطلب")]
        public string? StatusOfOrder { get; set; }
        [Display(Name = "ملاحظات")]
        public string? Note { get; set; }
        [Required]
        [Display(Name = "اسم العميل")]
        public string? NameOfcustomer { get; set; }
        [Display(Name = "عنوان العميل")]
        public string? AddressOfcustomer { get; set; }
        [Display(Name = "المدينه")]

        public string? cityOfcustomer { get; set; }
        [Display(Name = "طلب العميل")]
        public string? Orderforcustomer { get; set; }
        [Display(Name = "حاله الاوردر للعميل")]
        public string? StateOfOrderforcustomer { get; set; }
        [Display(Name = "رقم العميل")]
        public string? PhoneOfcustomer { get; set; }
        [Display(Name = "ملاحظات للتيم قبل الوصول")]
        public string? NotesToMaintenanceTeam { get; set; }
        [Required]
        [Display(Name = "مسؤول خط السير")]
        public string? RouteDistributionOfficer { get; set; }
        [Required]
        [Display(Name = "حاله الزياره")]
        public string? VisitStatus { get; set; }

    }
}
