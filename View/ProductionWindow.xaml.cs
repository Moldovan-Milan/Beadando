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

            // Admin gomb engedélyezése
            if (LoggedUser.GetPermission() == 1) { admin_btn.Visibility = Visibility.Visible; }

            cartRepository = GlobalVariables.GetCartRepository();
            main_frame.Content = productListPage;
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
