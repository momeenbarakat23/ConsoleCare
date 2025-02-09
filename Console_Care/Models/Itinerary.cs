using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }
        public string? Nameoftech { get; set; }
        public string? NameOfAssistant { get; set; }
        public string? RemainingTeam { get; set; }
        public DateTime VisitDate { get; set; }
        public string? VisitClassification { get; set; }
        public string? FaultStatement { get; set; }
        public string? StatusOfOrder { get; set; }
        public string? Note {  get; set; }
        public List<Customer> Customer { get; set; }
        public List<EmployeeItinerary> employeeItineraries { get; set; }
        public List<AdminItinerary> AdminItineraries { get; set; }
    }
}
