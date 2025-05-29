using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class course_detailfile
    {
        public int id { get; set; }
        public string adress { get; set; }
        public string name { get; set; }
        public string descript { get; set; }
        public int CourseId { get; set; }
        public course Course { get; set; }
    }
}
