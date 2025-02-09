using Microsoft.EntityFrameworkCore;

namespace Console_Care.Models
{
    [PrimaryKey("itinerarieId", "AdminId")]
    public class AdminItinerary
    {
        public int itinerarieId { get; set; }
        public int AdminId { get; set; }
        public Itinerary Itinerary { get; set; }
        public Admin Admin { get; set; }
    }
}
