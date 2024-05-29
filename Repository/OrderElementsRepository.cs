using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Beadando.Repository
{
    class OrderElementsRepository
    {
        private Context context;

        public OrderElementsRepository(Context context)
        {
            this.context = context;
        }

        public List<OrderElements> GetAll()
        {
            return context.OrderElements.ToList();
        }

        public List<OrderElements> GetElementsByOrderId(string orderId)
        {
            return context.OrderElements.Where(p => p.OrderId == orderId)
                .Include(or => or.Order).Include(pr => pr.Product).ToList();
        }

        public void Add(OrderElements orderElements)
        {
            context.Add(orderElements);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
