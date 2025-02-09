using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.ViewModel
{
    public class MaterialsEmployeesviewmodel
    {
        public string id { get; set; }
        public int Employeesid { get; set; }
        public int materialsId { get; set; }
        [Display(Name = "اسم الخامه")]
        public string? materialName { get; set; }
        [Display(Name = "اسم الفني")]
        public string? EmployeesName { get; set; }
        [Display(Name = "الكميه المستخدمه")]
        public int? QuantityUsed { get; set; }
        [Display(Name = "الباقي")]
        public int? calcquntityused { get; set; }
        [Display(Name = "الكميه")]
        public int Quantities { get; set; }

        public DateTime Date { get; set; }

    }
}
