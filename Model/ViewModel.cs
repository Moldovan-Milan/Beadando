using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Model
{
    internal class ViewModel
    {
        public IList<Images> Images { get; set; }
        public IList<Product> Products { get; set; }
        public static IList<Cart> CartItems { get; set; }

        public static Product SelectedProduct { get; set; }
    }
}
