using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private CartRepository cartRepository;

        public ProductWindow()
        {
            InitializeComponent();
            cartRepository = new CartRepository(GlobalVariables.GetContext());
            this.DataContext = ViewModel.SelectedProduct;
            price_block.Text = "Ár: " + ViewModel.SelectedProduct.Price + " Ft";

            if (!LoggedUser.IsLogged())
            {
                add_to_cart.Visibility = Visibility.Collapsed;
                login_text.Visibility = Visibility.Visible;
            }
        }

        // Add item to the cart
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Hozzáadod ezt az elemet a kosárhoz?",
                "Kosárhoz adás", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //GlobalVariables.AddCartElement(ViewModel.SelectedProduct.Id, 1);
                cartRepository.AddItemToCart(LoggedUser.GetUid(), ViewModel.SelectedProduct.Id, 1);
                cartRepository.Save();
                MessageBox.Show("A terméket hozzáadtuk a kosárhoz!");
            }
        }
    }
}
