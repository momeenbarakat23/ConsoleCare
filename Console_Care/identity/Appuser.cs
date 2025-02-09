using Console_Care.filter;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Console_Care.identity
{
    public class Appuser : IdentityUser
    {
        public string name {  get; set; }
        [AllowDuplicateUserName]
        public override string? UserName { get; set; }
        public string? Address { get; set; }
        public string? city { get; set; }
    }
}
