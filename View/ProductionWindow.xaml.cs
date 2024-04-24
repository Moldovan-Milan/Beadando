using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProductionWindow.xaml
    /// </summary>
    public partial class ProductionWindow : Window
    {
        private ProductListPage productListPage;
        private CartPage cartPage;
        private CartRepository cartRepository;

        public ProductionWindow()
        {
            InitializeComponent();
            productListPage = new ProductListPage();
            cartPage = new CartPage();

            cartRepository = GlobalVariables.GetCartRepository();
            main_frame.Content = productListPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //main_frame.Content = MainPage;
            //MainPage.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (MainPage.Visibility == Visibility.Collapsed)
            //{
            //    MessageBox.Show("collapsed");
            //    productPage = new ProductPage();
            //    main_frame.Content = productPage;
            //}
        }

        private void logout_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos kijelentkezel?", "Kijelentkezés", MessageBoxButton.YesNo)  == MessageBoxResult.Yes)
            {
                LoggedUser.Logout();
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        // Save cart elements to database
        private void Window_Closed(object sender, EventArgs e)
        {
            //Dictionary<int, int> cartValues = GlobalVariables.GetLocalCartValues();

            //foreach (var cart in cartValues)
            //{
            //    cartRepository.AddItemToCart(LoggedUser.GetUid(),
            //        cart.Key, cart.Value);
            //}
            //cartRepository.Save();

            
        }

        private void main_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            main_frame.Content = productListPage;
        }

        private void cart_btn_Click(object sender, RoutedEventArgs e)
        {
            cartPage.LoadData();
            main_frame.Content = cartPage;
        }
    }
}
