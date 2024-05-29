using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using System.Windows;
using System.Windows.Controls;

namespace MoldovanMilanBeadando.View
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private ViewModel viewModel;
        public ProductListPage()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            LoadCategory();
            LoadProducts(0);
            this.DataContext = viewModel;

            // Admin gombok
            if (LoggedUser.GetPermission() == 1)
            {
                admin_check_p_btn.Visibility = Visibility.Visible;
                admin_edit_p_btn.Visibility = Visibility.Visible;
                admin_new_p_btn.Visibility = Visibility.Visible;
            }

        }

        private void LoadProducts(int categoryId)
        {
            try
            {
                if (categoryId == 0)
                {
                    viewModel.Products = GlobalVariables.GetProductRepository().GetProducts();
                }
                else
                {
                    viewModel.Products = GlobalVariables.GetProductRepository().GetProductByCategoryId(categoryId);
                }
                listBox.ItemsSource = viewModel.Products;
            }
            catch { }
        }

        private void LoadCategory()
        {
            viewModel.Categories = GlobalVariables.GetCategoryRepository().GetAll();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoggedUser.GetPermission() != 1)
            {
                ProductWindow productWindow = new ProductWindow();
                productWindow.ShowDialog();
            }
            else
            {
                if (listBox.SelectedIndex != -1)
                {
                    admin_check_p_btn.IsEnabled = true;
                    admin_edit_p_btn.IsEnabled = true;
                }
                else if (listBox.SelectedIndex == -1)
                {
                    admin_check_p_btn.IsEnabled = false;
                    admin_edit_p_btn.IsEnabled = false;
                }
            }


        }

        private void category_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category _category = (Category)category_list.SelectedItem;
            LoadProducts(_category.Id);
        }

        private void admin_check_p_btn_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
        }

        private void admin_edit_p_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminView.EditProductWindow editProductWindow = new AdminView.EditProductWindow(true);
            editProductWindow.ShowDialog();
        }

        private void admin_new_p_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminView.EditProductWindow editProductWindow = new AdminView.EditProductWindow();
            editProductWindow.ShowDialog();
        }
    }
}
