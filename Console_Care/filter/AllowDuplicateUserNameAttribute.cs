using Console_Care.identity;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Console_Care.filter
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class AllowDuplicateUserNameAttribute : Attribute
    {
    }

}
