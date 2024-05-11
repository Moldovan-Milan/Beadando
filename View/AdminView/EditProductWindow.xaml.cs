using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Beadando.View.AdminView
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        // Repositories
        private ProductRepository productRepository;
        private CategoryRepository categoryRepository;
        private ImageRepository imageRepository;

        private bool editMode = false;
        private string imageFileName;
        private byte[] imageBytes;
        private IList<Category> categories;

        public EditProductWindow(bool editMode = false)
        {
            InitializeComponent();
            this.editMode = editMode;

            productRepository = new ProductRepository(GlobalVariables.GetContext());
            categoryRepository = new CategoryRepository(GlobalVariables.GetContext());
            imageRepository = new ImageRepository(GlobalVariables.GetContext());

            // Combobox betöltése
            categories = categoryRepository.GetAll();
            category_combobox.ItemsSource = categories;

            if (editMode )
            {
                title.Content = ViewModel.SelectedProduct.Name + " szerkesztése";
            }
            else
            {
                title.Content = "Új termék";

            }
        }

        private void image_select_bnt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Válassz képet";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imageFileName = op.FileName;
                selected_image.Width = 100;
                selected_image.Height = 100;
                selected_image.Source = new BitmapImage(new Uri(op.FileName));
                imageBytes = getJPGFromImageControl(selected_image.Source as BitmapImage);
            }
            MessageBox.Show(imageFileName);
        }

        // Forrás: https://stackoverflow.com/questions/553611/wpf-image-to-byte
        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!editMode && category_combobox.SelectedIndex != -1 && imageFileName != string.Empty)
            {
                // Kép mentése
                imageRepository.AddImage(imageBytes, product_name.Text.ToLower());
                imageRepository.Save();


                // Termék mentése
                Category _category = (Category)category_combobox.SelectedItem;
                productRepository.AddProduct(new Product
                {
                    Name = product_name.Text,
                    Price = int.Parse(product_price.Text),
                    Description = new TextRange(desc.Document.ContentStart, desc.Document.ContentEnd).Text, // https://stackoverflow.com/questions/957441/richtextbox-wpf-does-not-have-string-property-text
                    CategoryId = _category.Id,
                    ImgId = imageRepository.GetByName(product_name.Text.ToLower()).ID
                });
                productRepository.Save();
                MessageBox.Show("Termék elmentve");
            }
        }
    }
}
