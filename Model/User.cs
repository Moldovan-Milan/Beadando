using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    [Table("users")]
    internal class User
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

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
