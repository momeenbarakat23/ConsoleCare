using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [RegularExpression("[0-9]{11}")]
        public string? Phone { get; set; }
        public string TypeOfCustomer { get; set; }
        public string Ps4OrPs5 { get; set; } 
        public string Address { get; set; }
        public string city { get; set; }
        public string? Order { get; set; }
        public string? StateOfOrder { get; set; }
        [ForeignKey("Itinerary")]
        public int? ItineraryId { get; set; }
        public List<AdminCustomers> AdminCustomers { get; set; }
        public followUp followUp { get; set; }
        public Itinerary Itinerary { get; set; }
        [ForeignKey("Invoice")]
        public int? Invoiceid { get; set; }
        public Invoice Invoice { get; set; }


    }
}
