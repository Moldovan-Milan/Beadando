using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    [Table("category")]
    internal class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_name")]
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
