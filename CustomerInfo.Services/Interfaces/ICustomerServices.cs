using CustomerInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services.Interfaces
{
    public interface ICustomerServices
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomersGetByIdAsync(int id);
        Task<string> SaveDataAsync(Customer model);
        Task<string> DeleteAsync(int id);
        Task<string> UpdateAsync(Customer model);
     
    }
}
