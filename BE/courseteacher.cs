using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class courseteacher
    {
        public int id { get; set; }
        public int courseId { get; set; }
        public course course { get; set; }

        public int teacherId { get; set; }
        public Teacher teacher { get; set; }
    }
}
