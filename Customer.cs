using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace csharp_ecommerce_db
{
    [Table("customer")] 
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("surname")]
        public string? Surname { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        //relations
        public List<Order>? Orders { get; set; }


    }
}
