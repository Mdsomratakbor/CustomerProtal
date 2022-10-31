using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInfo.Entities
{
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Customers")]
        [Column(TypeName ="INT")]
        public int CustomerId { get; set; }

        [Column(TypeName = "Nvarchar(500)")]

        [StringLength(500)]

        public string CustomerAddress { get; set; }
    }
}
