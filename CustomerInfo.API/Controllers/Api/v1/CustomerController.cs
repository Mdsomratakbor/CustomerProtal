using CustomerInfo.API.DTO;
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
        public CustomerController(ICountryServices countryServices, ICustomerServices customerServices)
        {
            _countryServices = countryServices;
            _customerServices = customerServices;
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
                if (ModelState.IsValid)
                {
                    return new ResponseMessage(HttpStatusCode.NotAcceptable, false, ModelState.Select(x=>x.Value), null);
                }

                //var person = new PersonalInfo() { Name = model.Name, CountryId = model.CountryId, CityId = model.CityId, FileUrl = dbPath, DateOfBirth = model.DateOfBirth.ToString(), Language = model.Language == null ? "" : model.Language, FileName = string.IsNullOrWhiteSpace(model.FileName) ? "" : model.FileName };
                //var output = await _personalService.PersonDataSaveAndUpdate(person);

                return output == "1" ? new ResponseMessage(HttpStatusCode.OK, true, "Data Save Successfully", null) : new ResponseMessage(HttpStatusCode.BadRequest, false, output, null);
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

                var output = await _customerServices.CustomerDelete(id);

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
