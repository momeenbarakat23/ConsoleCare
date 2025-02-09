using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.Models
{
    public class followUp
    {
        [Key]
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
        [ForeignKey("Customer")]
        public int IdOfCustomer { get; set; }
        [ForeignKey("Employee")]
        public int? IdOfEmployee { get; set; }
       

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }


    }
}
