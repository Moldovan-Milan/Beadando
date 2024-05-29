using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Beadando.Functions
{
    public static class MakeOrder
    {
        private static OrderRepository orderRepository = new OrderRepository(GlobalVariables.GetContext());
        private static OrderElementsRepository orderElementsRepository = new OrderElementsRepository(GlobalVariables.GetContext());

        public static bool AddOrderToDatabase(TextBox[] textBoxes, IList<Cart> cart, int userId)
        {
            bool result = false;
            try
            {
                if (CheckInputField(textBoxes))
                {
                    string orderId = GenerateOrderId(userId);
                    SaveOrder(textBoxes, userId, orderId);
                    SaveCartElements(cart, orderId);
                    result = true;
                }
                else
                {
                    MessageBox.Show("Minden adatot ki kell tötleni!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            return result;
        }

        private static bool CheckInputField(TextBox[] textBoxes)
        {
            bool result = true;

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.Text == "") { result = false; break; }
            }

            return result;
        }

        private static string GenerateOrderId(int userId)
        {
            string id = DateTime.Now.ToString().Replace('.', '-').Replace(':', '_');
            id += "-" + userId;

            return id.Trim();
        }

        private static void SaveOrder(TextBox[] textBoxes, int userId, string orderId)
        {
            // Save Order
            orderRepository.AddOrder(new Model.Order
            {
                Id = orderId,
                Name = textBoxes[0].Text,
                PhoneNumber = textBoxes[1].Text,
                Country = textBoxes[2].Text,
                PostalCode = int.Parse(textBoxes[3].Text),
                City = textBoxes[4].Text,
                Street = textBoxes[5].Text,
                Address = textBoxes[6].Text,
                OrderDate = DateTime.Now,
                Uid = userId,
            });
            orderRepository.Save();
        }

        private static void SaveCartElements(IList<Cart> cart, string orderId)
        {
            foreach (Cart _cart in cart)
            {
                orderElementsRepository.Add(new OrderElements
                {
                    OrderId = orderId,
                    ProductId = _cart.ProductId,
                    Counts = _cart.Counts
                });
                GlobalVariables.GetCartRepository().DeleteItemFromCart(_cart.Id);
            }
            GlobalVariables.GetCartRepository().Save();
            orderElementsRepository.Save();
        }
    }
}
