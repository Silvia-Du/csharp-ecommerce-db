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
    [Table("order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Column("create_date")]
        public DateTime Date { get; set; }
        [Column("ammount")]
        public float Ammount { get; set; }
        [Column("status")]
        public string? Status { get; set; }
        [Column("customer_id")]
        //relations
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<Customers>? ProductList{ get; set; }

    }
}
