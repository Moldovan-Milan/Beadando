using Beadando.Data;
using Beadando.Functions;
using Beadando.Model;
using Beadando.Repository;
using Beadando.View;
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

namespace Beadando
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserRepository repository;

        public MainWindow()
        {
            InitializeComponent();
            repository = new UserRepository(GlobalVariables.GetContext());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = repository.GetUserByName(username_box.Text);

                if (EncryptionHelper.Decrypt(user.Password) == password_box.Password)
                {
                    LoggedUser.Login(user.UID, user.Username, user.Email);
                    ProductionWindow productionWindow = new ProductionWindow();
                    repository.Dispose();
                    productionWindow.Show();
                    this.Close();
                }
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Minden mezőt ki kell tölteni!\n Vagy nem megfelő a felhasználónév vagy a jelszó!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }

        private void registration_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }
    }
}
