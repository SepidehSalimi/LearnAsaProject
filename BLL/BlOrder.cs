using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlOrder
    {
        DaOrder dao = new DaOrder();

        public void create(Order c)
        {
            dao.create(c);
        }

        public Order searchbyid(int id)
        {
   
            return dao.searchbyid(id);
        }

        public List<Order> getskip(int c)
        {
      
            return dao.getskip(c);
        }


        public List<Order> getall()
        {

            return dao.getall();
        }


        public void Delete(Order order)
        {
            dao.Delete(order);
        }
    }
}
