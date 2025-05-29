using BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DaCourse
    {
        db db=new db();

        public void create(course c)
        {
            db.course.Add(c);
            db.SaveChanges();
        }
        public void getcourseteacher(int id)
        {
            var courseteachers = db.courseteachers.Where(q => q.courseId == id).ToList();
            db.courseteachers.RemoveRange(courseteachers);
            db.SaveChanges();
        }
        public course searchbyid(int id)
        {
            return db.course.Include(q => q.files).Include(q => q.courseteachers).ThenInclude(q => q.teacher).FirstOrDefault(q => q.id == id);
        }

        public List<course> SearchByIdBasket(List<int> ids)
        {
            var q=from i in db.course where ids.Contains(i.id) select i;
            return q.ToList();
        }

        public List<course> getall()
        {
          
            var q = from i in db.course select i;
            return q.ToList();
        }
        
        public List<course> PaginationAndSearch(string text, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            int skip = (page - 1) * 10;
            return search(text).Skip(skip).Take(10).ToList();
        }
        
        public int getVideoCount(int id)
        {
            return db.file.Where(q => q.CourseId == id).Count();
        }
        
        public List<course> search(string text)
        {
            if (text == "" || text == null)
            {
                return db.course.ToList();
            }
            return db.course.Where(q => q.title.Contains(text)).ToList();
        }
        public double gettotal()
        {
            
            return db.teacher.Count();
        }

        public List<course> getskip(int c)
        {
            int t = c * 10;
          
            var q = db.course.Skip(t).Take(10);
            return q.ToList();
        }
        public List<course> search(List<String> lstsearch)
        {
            List<course> te = new List<course>();
            foreach (var item in lstsearch)
            {
               
                var q = from i in db.course
                        where i.title.Contains(item.ToString())
                        select i;

                te = te.Concat(q.ToList()).ToList();
            }
            return te;
        }

        public void update(course t)
        {

            var q = from i in db.course
                    where i.id == t.id
                    select i;

            q.Single().title = t.title;
            q.Single().price = t.price;
            q.Single().totaltime = t.totaltime;
            q.Single().videointro = t.videointro;
            q.Single().descript = t.descript;
            db.SaveChanges();
        }

      
        public void Delete(course course)
        {
            db.Remove(course);
            db.SaveChanges();
        }

    }
}
