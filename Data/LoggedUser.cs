using System;

namespace Beadando.Data
{
    public static class LoggedUser
    {
        private static int uid;
        private static string userName;
        private static string email;
        private static int permission;

        private static bool isLogged = false;

        public static void Login(int uId, string username, string _email, int _permission)
        {
            if (!isLogged)
            {
                uid = uId;
                userName = username;
                email = _email;
                permission = _permission;
                isLogged = true;
            }
            else
            {
                throw new Exception("User is logged!");
            }
        }

        public static int GetUid() { return uid; }
        public static string GetUserName() { return userName; }
        public static string GetEmail() { return email; }

        public static int GetPermission() { return permission; }

        public static bool IsLogged() { return isLogged; }

        public static void Logout()
        {
            uid = -1;
            userName = string.Empty;
            email = string.Empty;
            permission = 0;
            isLogged = false;
        }

    }
}
