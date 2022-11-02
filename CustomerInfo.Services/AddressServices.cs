using CustomerInfo.Data;
using CustomerInfo.Entities;
using CustomerInfo.Services.AbstractClass;
using CustomerInfo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Services
{
    public class AddressServices:BaseRepository<Address>, IAddressServices
    {

        private new readonly ApplicationDbContext _context = null;
        public AddressServices(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<string> UpdateAsync(Address model)
        {
            try
            {
                await using var dbContextTransaction = _context.Database.BeginTransaction();

                try
                {
                    Update(model);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
                       ex.Message, ex.StackTrace, ex.InnerException, ex.Source);

                    dbContextTransaction.Rollback();
                    return ex.InnerException.Message;
                }

            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
                       ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return ex.Message;
            }
            return "1";
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                int output = 0;
                var address = await _context.CustomerAddress.FirstOrDefaultAsync(x => x.Id == id);
                if (address != null)
                {
                    _context.Remove(address);
                    output= await _context.SaveChangesAsync();
                }
                return output > 0 ? "1" : "0";

            }
            catch (DbUpdateException ex)
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
