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
        private enum LoginResults
        {
            UnkownError = -1,
            Success = 0,
            UsernameNotFound = 1,
            PasswordNotCorrect = 2
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginResults result = (LoginResults)Auth.Login(username_box.Text, password_box.Password);

            if (result == LoginResults.Success)
            {
                ProductionWindow productionWindow = new ProductionWindow();
                productionWindow.Show();
                this.Close();
            }
            else if (result == LoginResults.UsernameNotFound)
            {
                MessageBox.Show("Hibás a felhasználónév!");
            }
            else if (result == LoginResults.PasswordNotCorrect)
            {
                MessageBox.Show("Hibás a jelszó!");
            }
            else if (result == LoginResults.UnkownError)
            {
                MessageBox.Show("Sikertelen bejelentkezés ismeretlen hiba miatt!");
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
