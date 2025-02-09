using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.ViewModel
{
    public class followupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "بيان العطل")]
        public string? FaultStatement { get; set; }
        [Display(Name = "نوع العميل")]
        public string? TypeOfCustomer { get; set; }
        [Display(Name = "تاريخ الصيانه")]
        public DateTime Maintenance_Implementation_Date { get; set; }
        [Display(Name = "المتابعه التانيه")]
        public DateTime NextFollowUpDate { get; set; }
        [Display(Name = "المتابعه الاولى")]
        public DateTime LastFollowUpDate { get; set; }
        [Display(Name = "الشكاوي و الملاحظات")]
        public string? SuggestionsAndIssues { get; set; }
        [Display(Name = "حاله المتابعه")]
        public string? stateOfFolowUp { get; set; }
        [Display(Name = "تاريخ الضمان")]
        public DateTime WarrantyTime { get; set; }
        public int IdOfCustomer { get; set; }
        [Display(Name = "اسم العميل")]
        public string NameofCustomer { get; set; }

        public int? IdOfEmployee { get; set; }
        [Display(Name = "اسم الفني")]
        public string NameofEmployee { get; set; }

    }
}
