using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beadando.Model
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("country")]
        public string Country { get; set; }

        [Column("postal_code")]
        public int PostalCode { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("User")]
        [Column("uid")]
        public int Uid { get; set; }

        public virtual User User { get; set; }

        public ICollection<OrderElements> OrderElements { get; set; }
    }
}
