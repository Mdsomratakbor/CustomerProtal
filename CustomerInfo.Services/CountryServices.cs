﻿using CustomerInfo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services
{
    public class CountryServices
    {
        private Task<List<Country>> CreateListAsync()
        {
            return Task.Run(() =>
            {
                var Countrys = new List<Country>
                 {
                        new Country
                        {
                             CountryName = "Afghanistan"
                        },
                        new Country
                        {
                             CountryName = "Albania",
                        },
                        new Country
                        {
                            CountryName = "Algeria"
                        },
                        new Country
                        {
                           CountryName = "American Samoa"
                        },
                        new Country
                        {
                             CountryName = "Andorra"
                        },
                        new Country
                        {
                            CountryName = "Angola"
                        },
                        new Country
                        {
                            CountryName = "Anguilla"
                        },
                        new Country
                        {
                            CountryName = "Antarctica"
                        },
                        new Country {
                             CountryName = "Antigua And Barbuda"
                        },
                        new Country {
                         CountryName = "Argentina"
                        },
                        new Country {
                        CountryName = "Armenia"
                        },
                        new Country {
                        CountryName = "Aruba"
                        },
                        new Country {
                        CountryName = "Australia"
                        },
                        new Country {
                        CountryName = "Austria"
                        },
                        new Country {
                         CountryName = "Azerbaijan"},
                        new Country {
                        CountryName = "Bahamas"},
                        new Country {
                        CountryName = "Bahrain"
                        },
                        new Country {
                       CountryName = "Bangladesh"},
                        new Country {
                         CountryName = "Barbados"},
                        new Country {
                        CountryName = "Belarus"},
                        new Country {
                       CountryName = "Belgium"},
                        new Country {
                       CountryName = "Belize"},
                        new Country {
                        CountryName = "Benin"},
                        new Country {
                      CountryName = "Bermuda"},
                        new Country {
                        CountryName = "Bhutan"},
                        new Country {
                       CountryName = "Bolivia"},
                        new Country {
                       CountryName = "Bosnia and Herzegovina"},
                        new Country {
                     CountryName = "Botswana"},
                        new Country {
                      CountryName = "Bouvet Island"},
                        new Country {
                       CountryName = "Brazil"},
                        new Country {
                       CountryName = "British Indian Ocean Territory"},
                        new Country {
                       CountryName = "Brunei"},
                        new Country {
                       CountryName = "Bulgaria"},
                        new Country {
                         CountryName = "Burkina Faso"},
                        new Country {
                       CountryName = "Burundi"},
                        new Country {
                       CountryName = "Cambodia"},
                        new Country {
                     CountryName = "Cameroon"},
                        new Country {
                       CountryName = "Canada"},
                        new Country {
                         CountryName = "Cape Verde"},
                        new Country {
                       CountryName = "Cayman Islands"},
                        new Country {
                        CountryName = "Central African Republic"},
                        new Country {
                       CountryName = "Chad"},
                        new Country {
                       CountryName = "Chile"},
                        new Country {
                        CountryName = "China"},
                        new Country {
                        CountryName = "Christmas Island"},
                        new Country {
                        CountryName = "Guam"},
                        new Country {
                         CountryName = "Wallis And Futuna Islands"},
                        new Country {
                            CountryName = "Western Sahara"
                        },
                        new Country {
                             CountryName = "Yemen"
                        },
                        new Country {
                            CountryName = "Yugoslavia"},
                        new Country {
                              CountryName = "Zambia"},
                        new Country {
                             CountryName = "Zimbabwe"
                       }
                    };


                return Countrys;
            });
        }

    }
}