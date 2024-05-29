using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using MoldovanMilanBeadando.Repository;
using System.Windows;
using System.Windows.Controls;

namespace MoldovanMilanBeadando.View
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        private CartRepository cartRepository;
        private ViewModel viewModel;
        private int price = 0;

        public CartPage()
        {
            InitializeComponent();
            this.viewModel = new ViewModel();
            this.cartRepository = GlobalVariables.GetCartRepository();
            LoadData();
        }

        public void LoadData()
        {
            ViewModel.CartItems = this.cartRepository.GetByUserId(LoggedUser.GetUid());
            item_list.ItemsSource = ViewModel.CartItems;
            this.DataContext = viewModel;

            // Ha nincs termék, kiírja: a kosár üres...
            if (ViewModel.CartItems.Count == 0)
            {
                cart_is_empty_label.Visibility = Visibility.Visible;
                order_btns_st_panel.Visibility = Visibility.Collapsed;
            }
            else
            {
                cart_is_empty_label.Visibility = Visibility.Collapsed;
                order_btns_st_panel.Visibility = Visibility.Visible;

                price = cartRepository.GetPriceSum(LoggedUser.GetUid());
                sum_price.Text = $"Összesen: {price} Ft";
            }


        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (item_list.SelectedIndex > -1)
            {
                if (MessageBox.Show("Biztos törlöd?", "Elem törlése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Cart selected = item_list.SelectedItem as Cart;
                    cartRepository.DeleteItemFromCart(selected.Id);
                    cartRepository.Save();
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Nincs kiválasztott elem!");
            }

        }

        private void clear_cart_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos kiüríted a kosarat?", "Kosár kiürítése", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                cartRepository.ClearCartItems(LoggedUser.GetUid());
                cartRepository.Save();
                LoadData();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }
    }
}
