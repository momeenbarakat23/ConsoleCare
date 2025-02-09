using Console_Care.Models;
using Console_Care.ViewModel;

namespace Console_Care.orderforcust
{
    public interface Iorder
    {
        public Task<OrderByCustomer> CreateOrder(OrderByCustomer customer); 
       public  Task< OrderByCustomer> EditOrder(OrderByCustomer customer);
    }
}
