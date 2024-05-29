using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoldovanMilanBeadando.Model
{
    [Table("opinions")]
    public class Opinion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("rate_value")]
        public int RateValue { get; set; }

        [Column("opinion_text")]
        public string OpinionText { get; set; }

        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }


        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
