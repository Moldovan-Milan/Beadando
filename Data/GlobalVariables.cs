using Beadando.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Data
{
    static class GlobalVariables
    {
        private static readonly Context context = new Context(ConfigurationManager.AppSettings.Get("dbconnString"));
        private static readonly CartRepository cartRepository = new CartRepository(context);
        
        public static Context GetContext() { return context; }
        public static CartRepository GetCartRepository() { return cartRepository; }
    }
}
