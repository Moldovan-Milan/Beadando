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
        
        //private static Dictionary<int, int> LocalCartValues = new Dictionary<int, int>();
        
        public static Context GetContext() { return context; }
        public static CartRepository GetCartRepository() { return cartRepository; }

        //public static Dictionary<int, int> GetLocalCartValues()
        //{
        //    return LocalCartValues;
        //}

        //public static void AddCartElement(int productId, int count)
        //{
        //    if (LocalCartValues.ContainsKey(productId)) 
        //    {
        //        LocalCartValues[productId] += count;
        //    }
        //    else
        //    {
        //        LocalCartValues.Add(productId, count);
        //    }
        //}

        //public static void RemoveCartElement(int productId)
        //{
        //    if (LocalCartValues[productId] > 1)
        //    {
        //        LocalCartValues[productId] -= 1;
        //    }
        //    LocalCartValues.Remove(productId);
        //}
    }
}
