using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string CustomerName { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string FatherName { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string MotherName { get; set; }
        [Column(TypeName = "INT")]
        public int MaritalStatus { get; set; }
        [Column(TypeName = "varbinary(MAX)")]
        public string CustomerPhoto { get; set; }
        [ForeignKey("Countries")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
