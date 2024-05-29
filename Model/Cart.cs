using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beadando.Model
{
    [Table("cart")]
    public class Cart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("User")]
        [Column("uid")]
        public int UserId { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("counts")]
        public int Counts { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}
