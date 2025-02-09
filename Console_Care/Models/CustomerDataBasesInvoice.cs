using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.Models
{
    [PrimaryKey("CustomerDataBasesid", "Invoicesid")]
    public class CustomerDataBasesInvoice
    {
        [ForeignKey("CustomerDataBases")]
        
        public string CustomerDataBasesid { get; set; }
       [ForeignKey("Invoice")] 
        public int Invoicesid { get; set; }

        
        public CustomerDataBases CustomerDataBases { get; set; }
        public Invoice Invoice { get; set; }
        
    }
}
