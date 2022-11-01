using CustomerInfo.API.DTO;
using CustomerInfo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;

namespace CustomerInfo.API.Controllers.Api.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICountryServices _countryServices = null;
        public CustomerController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
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
    }
}
