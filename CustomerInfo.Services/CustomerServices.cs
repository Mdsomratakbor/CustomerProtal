using CustomerInfo.Data;
using CustomerInfo.Entities;
using CustomerInfo.Services.AbstractClass;
using CustomerInfo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services
{
    public class CustomerServices : BaseRepository<Customer>, ICustomerServices
    {
        private readonly ApplicationDbContext _context;
        public CustomerServices(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<string> CustomerDelete(int id)
        {
            try
            {
                int output=0;
                var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (customer != null)
                {
                    _context.Remove(customer);
                    output= await _context.SaveChangesAsync();
                }
                return output > 0 ? "1" : "0";
                
            }
            catch(DbUpdateException ex)
            {
                return ex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
