using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    [Table("product")]
    internal class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public int Price { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [ForeignKey("Category")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [ForeignKey("Images")]
        [Column("img_id")]
        public int ImgId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Images Img { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
