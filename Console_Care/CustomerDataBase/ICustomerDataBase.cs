
using Console_Care.Models;

namespace Console_Care.CustomerDataBase
{
    public interface ICustomerDataBase
    {
        public Task<List<CustomerDataBases>> AddData(string typeofcustomer); 
    }
}
