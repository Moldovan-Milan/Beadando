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
using System.Windows.Shapes;

namespace Beadando.View
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        UserRepository repository;
        public RegistrationWindow()
        {
            InitializeComponent();
            repository = new UserRepository(GlobalVariables.GetContext());
        }

        private void login_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void registration_btn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckDatas())
            {
                bool usernameCheck = false;
                bool emialCheck = false;
                bool passwordLengthCheck = false;
                bool passwordCheck = false;

                // Check username
                if (repository.GetUserNameExist(username_box.Text))
                {
                    user_name_error.Visibility = Visibility.Visible;
                }
                else
                {
                    usernameCheck = true;
                    user_name_error.Visibility = Visibility.Collapsed;
                }

                // Check email
                if (repository.GetEmailExist(email_box.Text))
                {
                    email_error.Visibility = Visibility.Visible;
                }
                else
                {
                    emialCheck = true;
                    email_error.Visibility = Visibility.Collapsed;
                }
                
                // Check password length
                if (password_box.Password.Length < 3)
                {
                    password_length_error.Visibility = Visibility.Visible;
                } 
                else { password_length_error.Visibility = Visibility.Collapsed; passwordLengthCheck = true; }

                // Check password again box
                if (password_box.Password != password_again_box.Password)
                {
                    password_check_error.Visibility = Visibility.Visible;
                }
                else { password_check_error.Visibility = Visibility.Collapsed; passwordCheck = true; }

                // Registrate User
                if (usernameCheck && emialCheck && passwordLengthCheck && passwordCheck) 
                {
                    RegistrateUser();
                }

            }
            else { MessageBox.Show("Minden adatot ki kell tölteni!"); }

            
        }

        private bool CheckDatas()
        {
            bool result = false;
            if (username_box.Text.Length > 0 && email_box.Text.Length > 0 
                && password_box.Password.Length > 0 && password_again_box.Password.Length > 0)
            {
                result = true;
            }

            return result;
        }

        private void RegistrateUser()
        {
            repository.AddUser(new User {
                Username = username_box.Text,
                Email = email_box.Text,
                Password = Functions.EncryptionHelper.Encrypt(password_box.Password),
                PermissionId = 2
                
            });
            repository.Save();
            repository.Dispose();

            MessageBox.Show("Regisztráció kész");
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            repository.Dispose();
            this.Close();
        }
    }

}
