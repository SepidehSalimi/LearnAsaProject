
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Order
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public AppUser User { get; set; }
        public float? TotalPric { get; set; }
        public List<Order_Course> order_courses  { get; set; }
    }


    public class Order_Course
    {
        public int Id { get; set; } 
        public int CourseId { get; set; } 
        public int OrderId { get; set; } 
        public course courses { get; set; } 
        public Order order { get; set; } 

    }
}
