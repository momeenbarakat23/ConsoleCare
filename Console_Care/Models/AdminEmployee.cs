using Microsoft.EntityFrameworkCore;

namespace Console_Care.Models
{
    [PrimaryKey("Employeeid", "adminId")]
    public class AdminEmployee
    {
        public int Employeeid { get; set; }
        public int adminId { get; set; }
        public Employee Employee { get; set; }
        public Admin Admin { get; set; }
    }
}
