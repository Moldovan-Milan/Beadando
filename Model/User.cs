using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beadando.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("uid")]
        public int UID { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("permission_id")]
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Opinion> Opinion { get; set; }
    }
}
