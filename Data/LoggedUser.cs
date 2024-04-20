using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Data
{
    public static class LoggedUser
    {
        private static int uid;
        private static string userName;
        private static string email;

        private static bool isLogged = false;

        public static void Login(int uId, string username, string _email)
        {
            if (!isLogged)
            {
                uid = uId;
                userName = username;
                email = _email;
                isLogged = true;
            }
            else
            {
                throw new Exception("User is logged!");
            }
        }

        public static int GetUid() { return uid; }
        public static string GetUserName() { return userName;}
        public static string GetEmail() { return email;}
        public static bool IsLogged() {  return isLogged;}

        public static void Logout()
        {
            uid = -1;
            userName = string.Empty;
            email = string.Empty;
            isLogged = false;
        }

    }
}
