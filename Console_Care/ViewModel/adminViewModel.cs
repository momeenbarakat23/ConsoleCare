using System.ComponentModel.DataAnnotations;

namespace Console_Care.ViewModel
{
    public class adminViewModel
    {
        public int IdAdmin { get; set; }
        [Display(Name = "اسم الادمن")]
        public string AdminName { get; set; }
        [Display(Name = "تاريخ الزياره")]
        public DateTime VisitDate { get; set; }
        [Display(Name = "اسم الفني")]
        public string NameOfTechnician { get; set; }
        [Display(Name = "اسم المساعد")]
        public string NameOfAssistant { get; set; }
        [Display(Name = "ملاحظه قبل الوصول للعميل")]
        public string? NotesToMaintenanceTeam { get; set; }
        [Display(Name = "مسؤول خط السير")]
        public string RouteDistributionOfficer { get; set; }
        [Display(Name = "نوع الزياره")]
        public string VisitClassification { get; set; }
        [Display(Name = "المعاد المناسب للعميل")]
        public string? VisitStatus { get; set; }
        [Display(Name = "باقي التيم")]
        public string? RemainingTeam { get; set; }

        public int idofCustomer { get; set; }
        [Display(Name = "اسم العميل")]
        public string NameCustomer { get; set; }
        [RegularExpression("[0-9]{11}")]
        [Display(Name = "رقم العميل")]
        public string? PhoneCustomer { get; set; }
        [Display(Name = "نوع العميل")]
        public string TypeOfCustomer { get; set; }
        [Display(Name = "جهاز العميل")]
        public string Ps4OrPs5 { get; set; }
        [Display(Name = "عنوان العميل")]
        public string AddressCustomer { get; set; }
        [Display(Name = "المدينه")]
        public string cityCustomer { get; set; }
        [Display(Name = "طلب العميل")]
        public string? OrderCustomer { get; set; }
        [Display(Name = "حاله طلب العميل")]
        public string? StateOfOrderCustomer { get; set; }
        public List<string> EmployeeName { get; set; }
    }
}
