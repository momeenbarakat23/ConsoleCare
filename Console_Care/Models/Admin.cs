using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console_Care.Models
{
    public class Admin
    {
        [Key]
        
        public  int  Id { get; set; }
        public string? AdminName { get; set; }       
        public string? NotesToMaintenanceTeam { get; set; }
        public string? RouteDistributionOfficer { get; set; }

        public string? VisitStatus { get; set; }



       
        public List<AdminCustomers> AdminCustomers { get; set; }
        public List<AdminEmployee> adminEmployee { get; set; }
        public List<AdminItinerary> AdminItineraries { get; set; }

    }
}
