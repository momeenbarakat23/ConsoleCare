using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Console_Care.ViewModel;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using Console_Care.identity;

namespace Console_Care.Models
{
    public class Appdbcontext : IdentityDbContext<Appuser>
    {
        public Appdbcontext(DbContextOptions options) : base(options)
        {

        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Materials> materials { get; set; }
        public DbSet<followUp> followUp { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Itinerary> itineraries { get; set; }
        public DbSet<AdminEmployee> AdminEmployee { get; set; }
        public DbSet<AdminItinerary> AdminItinerary { get; set; }
        public DbSet<EmployeeItinerary> EmployeeItinerary { get; set; }
       public DbSet<EmployeeMaterials> EmployeeMaterials { get; set; }
       public DbSet<CustomerDataBases> CustomerDataBases { get; set; }
       public DbSet<StaticAssets> StaticAssets { get; set; }
       public DbSet<Other_expenses> Other_expenses { get; set; }
       public DbSet<static_expenses> static_expenses { get; set; }
       public DbSet<Purchase_Payments> Purchase_Payments { get; set; }
       public DbSet<Cash> Cash { get; set; }
       public DbSet<BuyingMaterials> BuyingMaterials { get; set; }
       public DbSet<Closeday> Closeday { get; set; }

        public DbSet<AdminCustomers> AdminCustomers { get; set; }
        public DbSet<sales> sales { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<CustomerDataBasesInvoice> CustomerDataBasessInvoice { get; set; }
        //public DbSet<Console_Care.ViewModel.ItineraryViewModel> ItineraryViewModel { get; set; } = default!;
    }
}
