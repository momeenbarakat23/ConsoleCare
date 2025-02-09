using Console_Care.Models;
using Console_Care.ViewModel;

namespace Console_Care.Iinvoice
{
    public interface Iinvoice
    {
        public Task<Invoice> CreateAsync(Invoice invoice);  
        public Task<InvoiceViewModel> UpdateAsync(InvoiceViewModel invoice);
    }
}
