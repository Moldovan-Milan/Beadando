using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using Beadando.Functions;
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
using System.Windows.Shapes;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private enum RegistrationResults
        {
            Failed = -1,
            Succes = 0,
            UsernameAlreadyExist = 1,
            EmailAlreadyExist = 2,
            PasswordLenghtToSmall = 3,
            PasswordsNotMacthes = 4,
        }

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void login_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void SetPageToDefault()
        {
            user_name_error.Visibility = Visibility.Collapsed;
            email_error.Visibility = Visibility.Collapsed;
            password_length_error.Visibility = Visibility.Collapsed;
            password_length_error.Visibility = Visibility.Collapsed;
        }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {
            SetPageToDefault();
            RegistrationResults result = (RegistrationResults)Auth.Registrate(username_box.Text, email_box.Text,
                password_box.Password, password_again_box.Password);

            if (result == RegistrationResults.Succes)
            {
                MessageBox.Show("Regisztráció kész");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else if (result == RegistrationResults.UsernameAlreadyExist)
                { user_name_error.Visibility = Visibility.Visible; }
            else if (result == RegistrationResults.EmailAlreadyExist)
                { email_error.Visibility = Visibility.Visible; }
            else if (result == RegistrationResults.PasswordLenghtToSmall) 
                { password_length_error.Visibility = Visibility.Visible; }
            else if (result == RegistrationResults.PasswordsNotMacthes) 
                { password_check_error.Visibility = Visibility.Visible; }
            else if (result == RegistrationResults.Failed) 
                { MessageBox.Show("Sikertelen regisztráció!"); }
        }
    }

}
