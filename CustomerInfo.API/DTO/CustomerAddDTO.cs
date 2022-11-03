using CustomerInfo.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerInfo.API.DTO
{
    public class CustomerAddDTO
    {
        //[Required]
        //[MaxLength(100), MinLength(5)]
        public string CustomerName { get; set; }
        //[MaxLength(100), MinLength(5)]
        public string FatherName { get; set; }
        //[MaxLength(100), MinLength(5)]
        public string MotherName { get; set; }
        public int MaritalStatus { get; set; }
        public string CustomerPhoto { get; set; }
        public int CountryId { get; set; }
        public List<AddressDTO> Addresses { get; set; }
    }
}
