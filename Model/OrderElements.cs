using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    [Table("order_elements")]
    class OrderElements
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("Order")]
        [Column("order_id")]
        public string OrderId { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("counts")]
        public int Counts { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
