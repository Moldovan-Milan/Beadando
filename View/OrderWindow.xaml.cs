using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using Org.BouncyCastle.Asn1.Cms;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        private CartRepository cartRepository;
        private OrderRepository orderRepository;
        private OrderElementsRepository orderElementsRepository;

        private TextBox[] textBoxes;

        public OrderWindow()
        {
            InitializeComponent();
            cartRepository = GlobalVariables.GetCartRepository();
            orderRepository = new OrderRepository(GlobalVariables.GetContext());
            orderElementsRepository = new OrderElementsRepository(GlobalVariables.GetContext());

            textBoxes = new TextBox[]
            { name_input_box, phone_input_box, country_input_box, 
              postal_box_input_box, city_input_box, street_input_box, address_input_box};
        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInputField())
            {
                string orderId = GenerateOrderId();
                // Save Order
                orderRepository.AddOrder(new Order 
                {
                    Id = orderId,
                    Name = name_input_box.Text,
                    PhoneNumber = phone_input_box.Text,
                    Country = country_input_box.Text,
                    PostalCode = int.Parse(postal_box_input_box.Text),
                    City = city_input_box.Text,
                    Street = street_input_box.Text,
                    Address = address_input_box.Text,
                    OrderDate = DateTime.Now,
                    Uid = LoggedUser.GetUid(),
                });
                orderRepository.Save();

                // Save product
                foreach (Cart cart in ViewModel.CartItems)
                {
                    orderElementsRepository.Add(new OrderElements
                    {
                        OrderId = orderId,
                        ProductId = cart.ProductId,
                        Counts = cart.Counts
                    });
                    cartRepository.DeleteItemFromCart(cart.Id);
                }
                cartRepository.Save();
                orderElementsRepository.Save();
                MessageBox.Show("A rendelésed megkaptuk!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Minden adatot ki kell tölteni!");
            }
        }

        private bool CheckInputField()
        {
            bool result = true;
            
            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "") { result = false; break; }
            }

            return result;
        }

        private string GenerateOrderId()
        {
            string id = DateTime.Now.ToString().Replace('.', '-').Replace(':', '_');
            id += "-" + LoggedUser.GetUid();
            MessageBox.Show(id.Trim());

            return id.Trim();
        }
    }
}
