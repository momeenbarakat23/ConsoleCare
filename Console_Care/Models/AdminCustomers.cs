using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    [PrimaryKey("CustomerId", "AdminId")]
    public class AdminCustomers
    {
        
        public int CustomerId { get; set; }
        
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public Customer Customer { get; set; }
    }
}
