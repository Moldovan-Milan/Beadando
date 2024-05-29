using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Beadando.Repository
{
    internal class OpinionRepository
    {
        private Context context;

        public OpinionRepository(Context context)
        {
            this.context = context;
        }

        public List<Opinion> GetOpinionByProductId(int productId)
        {
            return context.Opinions.Where(p => p.ProductId == productId).Include(u => u.User).Include(p => p.Product).ToList();
        }

        public double GetAvargeProductRate(int productId)
        {
            double sum = 0;
            List<Opinion> opinions = GetOpinionByProductId(productId);
            foreach (Opinion opinion in opinions)
            {
                sum += opinion.RateValue;
            }
            return Math.Round(sum / opinions.Count, 2);
        }
    }
}
