using Microsoft.EntityFrameworkCore;

namespace Console_Care.Models
{
    [PrimaryKey("ItineraryId", "Employeeid")]
    public class EmployeeItinerary
    {
        public int ItineraryId { get; set; }
        
        public int Employeeid { get; set; }

        public Employee Employee { get; set; }
        public Itinerary Itinerary { get; set; }
    }
}
