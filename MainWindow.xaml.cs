using Beadando.Data;
using Beadando.Functions;
using Beadando.View;
using System;
using System.Windows;
using System.Windows.Input;

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
            if (!GlobalVariables.GetContext().Database.CanConnect())
            {
                MessageBox.Show("Nem lehet kapcsolódni az adatbázishoz!");
                Environment.Exit(-1);
            }
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
