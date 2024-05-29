using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoldovanMilanBeadando.Model
{
    [Table("permission")]
    public class Permission
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("permission_name")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
