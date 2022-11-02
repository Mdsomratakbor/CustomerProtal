using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CustomerInfo.API.DTO
{
    public class AddressDTO
    {
        [MaxLength(500), MinLength(5)]
        public string CustomerAddress { get; set; }
    }
}
