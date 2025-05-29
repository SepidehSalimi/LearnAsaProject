using BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DaOrder
    {
        db db = new db();
        public void create(Order c)
        {
            db.orders.Add(c);
            db.SaveChanges();
        }

        public Order searchbyid(int id)
        {
               var q=from i in db.orders where i.Id == id select i;
            return q.SingleOrDefault();
        }

        public List<Order> getskip(int c)
        {
            int t = c * 10;

            var q = db.orders.Skip(t).Take(10);
            return q.ToList();
        }


        public List<Order> getall()
        {

            var q = from i in db.orders select i;
            return q.ToList();
        }


        public void Delete(Order order)
        {
            db.Remove(order);
            db.SaveChanges();
        }

    }
}
