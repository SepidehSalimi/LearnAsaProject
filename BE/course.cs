using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class course
    {
        public int id { get; set; }
        public string title { get; set; }
        public float? totaltime { get; set; }
        public List<courseteacher> courseteachers { get; set; } = new List<courseteacher>();
        public string descript { get; set; }
        public string videointro { get; set; }
        public float? price { get; set; }
        public List<course_detailfile> files { get; set; } = new List<course_detailfile>();

        public List<Order_Course> order_courses  { get; set; }

    }
}
