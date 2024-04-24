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
        private ViewModel viewModel;
        public ProductListPage()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            productRepository = new ProductRepository(GlobalVariables.GetContext());

            LoadProducts();
            this.DataContext = viewModel;
        }

        private void LoadProducts()
        {
            viewModel.Products = productRepository.GetProducts();
            listBox.ItemsSource = viewModel.Products;
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
        }
    }
}
