using CustomerInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services.Interfaces
{
    public interface ICountryServices
    {
        Task<List<Country>> GetCountriesAsync();

      
    }
}
