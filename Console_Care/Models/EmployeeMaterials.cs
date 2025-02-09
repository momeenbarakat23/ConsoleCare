using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Console_Care.Models
{
   
    public class EmployeeMaterials
    {
        [Key]
        public string id { get; set; }
        [ForeignKey("Employee")]
        public int Employeesid { get; set; }
        [ForeignKey("Materials")]
        public int materialsId { get; set; }
        public int? QuantityUsed { get; set; }
        public int Quantities { get; set; }
        public DateTime Date { get; set; }
        public Materials Materials { get; set; }
        public Employee Employee { get; set; }

    }
}
