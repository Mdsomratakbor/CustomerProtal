using CustomerInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services.Interfaces
{
    public interface IAddressServices
    {
        Task<string> UpdateAsync(Address model);
        Task<string> DeleteAsync(int id);
    }
}
