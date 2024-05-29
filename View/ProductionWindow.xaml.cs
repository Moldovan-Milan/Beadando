using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using System.Windows;

namespace MoldovanMilanBeadando.View
{
    /// <summary>
    /// Interaction logic for ProductionWindow.xaml
    /// </summary>
    public partial class ProductionWindow : Window
    {
        private ProductListPage productListPage;
        private CartPage cartPage;

        public ProductionWindow()
        {
            InitializeComponent();
            productListPage = new ProductListPage();
            cartPage = new CartPage();

            // Admin gomb engedélyezése
            if (LoggedUser.GetPermission() == 1) { admin_btn.Visibility = Visibility.Visible; }
            main_frame.Content = productListPage;
        }


        private void logout_menu_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Biztos kijelentkezel?", "Kijelentkezés", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                LoggedUser.Logout();
                ViewModel.SelectedProduct = null;
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
