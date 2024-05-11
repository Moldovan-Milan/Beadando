using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    [Table("permission")]
    internal class Permission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permission_name")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
