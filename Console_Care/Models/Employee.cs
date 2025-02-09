using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "الاسم")]
        public string name { get; set; }
        [Display(Name = "الوظيفه")]
        public string role { get; set; }
        [Display(Name = "الملاحظات")]
        public string?Note { get; set; }
        public int? countinvoice { get; set; }
        public decimal? paid { get; set; }

        public List<EmployeeMaterials> materials { get; set; }
        public List<EmployeeItinerary> employeeItineraries{ get; set; }
        public List<AdminEmployee> AdminEmployees { get; set; }
        public List<followUp> followups { get; set; }


    }
}
