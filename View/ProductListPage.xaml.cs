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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private ViewModel viewModel;
        public ProductListPage()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            productRepository = new ProductRepository(GlobalVariables.GetContext());
            categoryRepository = new CategoryRepository(GlobalVariables.GetContext());
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
                    viewModel.Products = productRepository.GetProducts();
                }
                else
                {
                    viewModel.Products = productRepository.GetProductByCategoryId(categoryId);
                }
                listBox.ItemsSource = viewModel.Products;
            }
            catch { }
        }

        private void LoadCategory()
        {
            viewModel.Categories = categoryRepository.GetAll();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LoggedUser.GetPermission() == 1)
            {
                
            }
            else
            {
                ProductWindow productWindow = new ProductWindow();
                productWindow.ShowDialog();
            }
        }

        private void category_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Category _category = (Category) category_list.SelectedItem;
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
