using System.ComponentModel.DataAnnotations;

namespace Console_Care.Models
{
    public class sales
    {
        [Key]
        public int id { get; set; }
        public string Nameofdataentry { get; set; }
        public string NameOfCustomer { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeOfCall { get; set; }
        public bool Interesting { get; set; }
        public string? Note { get; set; }


    }
}
