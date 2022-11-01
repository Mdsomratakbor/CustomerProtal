using CustomerInfo.Data;
using CustomerInfo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Service

{
    public class DbContextInitializer
    {
        public static async Task Initialize(ApplicationDbContext applicationDbContext, ICountryServices countryService)
        {
         

            // check, if db applicationContext is created
            await applicationDbContext.Database.EnsureCreatedAsync();
            if (applicationDbContext.Countries.Any())
            {
                return;
            }
 

            // Populate Country database
            var countries = await countryService.GetCountriesAsync();
            if (countries.Count > 0)
            {
                await applicationDbContext.Countries.AddRangeAsync(countries);
                await applicationDbContext.SaveChangesAsync();

            }
        }
    }
}
