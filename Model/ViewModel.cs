using System.Collections.Generic;

namespace Beadando.Model
{
    internal class ViewModel
    {
        public IList<Images> Images { get; set; }
        public IList<Product> Products { get; set; }
        public IList<Category> Categories { get; set; }
        public static IList<Cart> CartItems { get; set; }

        public static Product SelectedProduct { get; set; }
    }
}
