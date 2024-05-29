using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoldovanMilanBeadando.Model
{
    [Table("images")]
    public class Images
    {
        [Key]
        [Column("img_id")]
        public int ID { get; set; }

        [Column("caption")]
        public string Caption { get; set; }

        [Column("img")]
        public byte[] IMG { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
