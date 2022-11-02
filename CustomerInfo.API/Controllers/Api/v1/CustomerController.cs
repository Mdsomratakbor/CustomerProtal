using CustomerInfo.API.DTO;
using CustomerInfo.Entities;
using CustomerInfo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerInfo.API.Controllers.Api.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICountryServices _countryServices = null;
        private readonly ICustomerServices _customerServices = null;
        private readonly IAddressServices _addressServices = null;
        public CustomerController(ICountryServices countryServices, ICustomerServices customerServices, IAddressServices addressServices)
        {
            _countryServices = countryServices;
            _customerServices = customerServices;
            _addressServices = addressServices;
        }

        [HttpGet("Countries")]
        public ResponseMessage GetPersons()
        {
            try
            {
                List<CountryDTO> countries = new List<CountryDTO>();
                _countryServices.GetCountriesAsync().Result.ForEach(x => countries.Add(new CountryDTO() { Id = x.Id, Name = x.CountryName }));
                return new ResponseMessage(HttpStatusCode.OK, true, "Person Loaded!!", countries);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
     ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);
            }

        }

        [HttpGet("Customers")]
        public ResponseMessage GetCustomers()
        {
            try
            {
                List<CustomerListDTO> countries = new List<CustomerListDTO>();
                _customerServices.GetCustomersAsync().Result.ForEach(x => countries.Add(new CustomerListDTO() { Id = x.Id, CustomerName = x.CustomerName, FatherName = x.FatherName, MotherName = x.MotherName }));
                return new ResponseMessage(HttpStatusCode.OK, true, "Customer Loaded!!", countries);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
     ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);
            }

        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ResponseMessage> Add(CustomerAddDTO model)
        {
            try
            {
                string output = string.Empty;
                if (!ModelState.IsValid)
                {
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ModelState.Select(x=>x.Value), null);
                }

                List<Address> addresses = new ();
                model.Addresses.ForEach(x => addresses.Add(new Address() { CustomerAddress = x.CustomerAddress }));
                
                var customer = new Customer()
                {
                   CountryId = model.CountryId,
                   CustomerName = model.CustomerName,
                   FatherName   =  model.FatherName,
                   MaritalStatus = model.MaritalStatus,
                   MotherName = model.MotherName,
                  CustomerPhoto = model.CustomerPhoto,
                  Addresses = addresses

                };
                 output = await _customerServices.SaveDataAsync(customer);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Save Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);

            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ResponseMessage> Edit(CustomerEditDTO model)
        {
            try
            {
                string output = string.Empty;
                if (!ModelState.IsValid)
                {
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ModelState.Select(x => x.Value), null);
                }

                List<Address> addresses = new();
                model.Addresses.ForEach(x => addresses.Add(new Address() { CustomerId= model.Id, Id = x.Id, CustomerAddress = x.CustomerAddress }));

                var customer = new Customer()
                {
                    Id = model.Id,
                    CountryId = model.CountryId,
                    CustomerName = model.CustomerName,
                    FatherName   =  model.FatherName,
                    MaritalStatus = model.MaritalStatus,
                    MotherName = model.MotherName,
                    CustomerPhoto = model.CustomerPhoto,
                  
                    Addresses = addresses

                };
                output = await _customerServices.UpdateAsync(customer);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Update Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);

            }
        }




        [HttpPut]
        [Route("[action]")]
        public async Task<ResponseMessage> Delete([FromBody] int id)
        {
            try
            {
                if (id == 0)
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, "Please enter valid Id", null);

                var output = await _customerServices.DeleteAsync(id);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Delete Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);

            }
        }


        [HttpPost]
        [Route("Address/Edit")]
        public async Task<ResponseMessage> EditAddress([FromBody]AddressEditDTO model)
        {
            try
            {
                string output = string.Empty;
                if (!ModelState.IsValid)
                {
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ModelState.Select(x => x.Value), null);
                }

                var customer = new Address() { CustomerId= model.CustomerId, CustomerAddress = model.CustomerAddress, Id = model.Id };
                output = await _addressServices.UpdateAsync(customer);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Update Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);

            }
        }




        [HttpPut]
        [Route("Address/Delete")]
        public async Task<ResponseMessage> DeleteAddress([FromBody] int id)
        {
            try
            {
                if (id == 0)
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, "Please enter valid Id", null);

                var output = await _customerServices.DeleteAsync(id);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Delete Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
            }
            catch (Exception ex)
            {
                Log.Error("An error occurred while seeding the database  {Error} {StackTrace} {InnerException} {Source}",
ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
                return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ex.Message, null);

            }
        }
    }
}
