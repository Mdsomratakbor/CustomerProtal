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
        Task<List<Customer>> GetCustomersGetByIdAsync();
        Task<string> SaveDataAsync(Customer model);
        Task<string> DeleteAsync(int id);
        Task<string> UpdateAsync(Customer model);
     
    }
}
