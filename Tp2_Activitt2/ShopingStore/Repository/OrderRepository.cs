using ShoppingStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingStore.Repository
{
    class OrderRepository
    {
        private Context context;

        public OrderRepository()
        {
            context = new Context();
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = context.Orders.SingleOrDefault(o => o.OrderId == id );
            if (order != null) context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void Update(Order order)
        {
            Order updated = context.Orders.SingleOrDefault(o => o.OrderId == order.OrderId);
            if(updated != null)
            {
               // change values of fields
            }

            context.SaveChanges();
        }

        public Order FindById(int id)
        {
            return context.Orders.SingleOrDefault(o => o.OrderId == id);
        }

        public List<Order> FindAll()
        {
            return context.Orders.ToList();
        }
    }
}
