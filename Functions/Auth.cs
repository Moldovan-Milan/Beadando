using Beadando.Data;
using Beadando.Model;
using Beadando.Repository;
using System;

namespace Beadando.Functions
{
    static class Auth
    {
        static private UserRepository userRepository =
            new UserRepository(GlobalVariables.GetContext());

        public enum LoginResults
        {
            UnkownError = -1,
            Success = 0,
            UsernameNotFound = 1,
            PasswordNotCorrect = 2
        }

        public enum RegistrationResults
        {
            Failed = -1,
            Succes = 0,
            UsernameAlreadyExist = 1,
            EmailAlreadyExist = 2,
            PasswordLenghtToSmall = 3,
            PasswordsNotMacthes = 4,
        }

        public static LoginResults Login(string username, string password)
        {
            LoginResults result = LoginResults.UnkownError;

            try
            {
                User user = userRepository.GetUserByName(username);

                if (user == null) { return LoginResults.UsernameNotFound; }

                if (EncryptionHelper.Decrypt(user.Password) == password)
                {
                    LoggedUser.Login(user.UID, user.Username, user.Email, user.PermissionId);
                    return LoginResults.Success;
                }
                else
                {
                    return LoginResults.PasswordNotCorrect;
                }
            }
            catch (Exception e)
            {
                return result;
            }
        }

        public static RegistrationResults Registrate(string username, string email,
            string password, string passwordAgain)
        {
            RegistrationResults result = RegistrationResults.Failed;

            try
            {
                // Megnézi, hogy a felhasználó vagy az email már megvan-e adva
                if (userRepository.GetUserNameExist(username))
                { return RegistrationResults.UsernameAlreadyExist; }
                if (userRepository.GetEmailExist(email))
                { return RegistrationResults.EmailAlreadyExist; }

                // Jelszó ellenőrzése
                if (password.Length < 3) { return RegistrationResults.PasswordLenghtToSmall; }
                if (password != passwordAgain) { return RegistrationResults.PasswordsNotMacthes; }

                // User regisztrálása, ha minden jó
                userRepository.AddUser(new User
                {
                    Username = username,
                    Email = email,
                    Password = EncryptionHelper.Encrypt(password),
                    PermissionId = 2
                });

                userRepository.Save();
                return RegistrationResults.Succes;

            }
            catch
            {
                return result;
            }
        }
    }
}
