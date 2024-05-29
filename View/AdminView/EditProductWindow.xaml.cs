using MoldovanMilanBeadando.Data;
using MoldovanMilanBeadando.Model;
using MoldovanMilanBeadando.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace MoldovanMilanBeadando.View.AdminView
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

            if (editMode)
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
                //imageBytes = File.ReadAllBytes(op.FileName);
            }
            MessageBox.Show(imageFileName);
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
                imageRepository.AddImage(File.ReadAllBytes(imageFileName), product_name.Text.ToLower());
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
