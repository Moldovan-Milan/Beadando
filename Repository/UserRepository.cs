using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Repository
{
    internal class UserRepository
    {
        private Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }

        public List<User> GetUsers()
        {
            return context.Users.Include(pe => pe.Permission).ToList();
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
        }

        public User GetUserByName(string name)
        {
            return context.Users.Where(p => p.Username == name).Include(pe => pe.Permission).ToList().First();
        }

        public bool GetUserNameExist(string username)
        {
            bool exists = false;

            try
            {
                if (context.Users.Where(p => p.Username == username).ToList().Count > 0)
                {
                    exists = true;
                }
            } catch { }

            return exists;
        }

        public bool GetEmailExist(string email)
        {
            bool exists = false;

            try
            {
                if (context.Users.Where(p => p.Email == email).ToList().Count > 0)
                {
                    exists = true;
                }
            }catch { }

            return exists;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
