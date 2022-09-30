using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ecommerce_db
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Column("name")]
        public string? Name { get; set; }
        [Column("surname")]
        public string? Surname { get; set; }
        [Column("level")]
        public string? Level { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
