using Beadando.Data;
using Beadando.Model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        List<Opinion> opinions;

        public ProductWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel.SelectedProduct;
            price_block.Text = "Ár: " + ViewModel.SelectedProduct.Price + " Ft";
            avarge_rating.Content = "Átlagos értékelés: " + GlobalVariables.GetOpinionRepository().
                                    GetAvargeProductRate(ViewModel.SelectedProduct.Id);
            LoadProductRating();
            if (!LoggedUser.IsLogged())
            {
                add_to_cart.Visibility = Visibility.Collapsed;
                login_text.Visibility = Visibility.Visible;
            }
        }

        private void LoadProductRating()
        {
            this.opinions = GlobalVariables.GetOpinionRepository().GetOpinionByProductId(ViewModel.SelectedProduct.Id);
            if (this.opinions.Count == 0)
            {
                no_opinions.Visibility = Visibility.Visible;
            }
            rating.ItemsSource = this.opinions;
        }

        // Add item to the cart
        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Hozzáadod ezt az elemet a kosárhoz?",
                "Kosárhoz adás", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                //GlobalVariables.AddCartElement(ViewModel.SelectedProduct.Id, 1);
                GlobalVariables.GetCartRepository().AddItemToCart(LoggedUser.GetUid(), ViewModel.SelectedProduct.Id, 1);
                GlobalVariables.GetCartRepository().Save();
                MessageBox.Show("A terméket hozzáadtuk a kosárhoz!");
            }
        }
    }
}
