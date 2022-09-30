using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_ecommerce_db
{
    [Table("payment")]

    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("ammount")]
        public float Ammount { get; set; }
        [Column("status")]
        public string? Status { get; set; }
        //relations
        [Column("oreder_id")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
