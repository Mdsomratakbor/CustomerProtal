using CustomerInfo.Data;
using CustomerInfo.Entities;
using CustomerInfo.Services.AbstractClass;
using CustomerInfo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services
{
    public class CustomerServices : BaseRepository<Customer>, ICustomerServices
    {
        public CustomerServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
