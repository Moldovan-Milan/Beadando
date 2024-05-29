using Beadando.Data;
using Beadando.Functions;
using Beadando.Model;
using System.Windows;
using System.Windows.Controls;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        private TextBox[] textBoxes;

        public OrderWindow()
        {
            InitializeComponent();

            textBoxes = new TextBox[]
            { name_input_box, phone_input_box, country_input_box,
              postal_box_input_box, city_input_box, street_input_box, address_input_box};
        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MakeOrder.AddOrderToDatabase(textBoxes, ViewModel.CartItems, LoggedUser.GetUid()))
            {
                MessageBox.Show("A rendelésed megkaptuk!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Rendelésed nem kaptuk meg :(");
            }
        }
    }
}
