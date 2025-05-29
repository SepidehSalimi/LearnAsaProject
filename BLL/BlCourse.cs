using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlCourse
    {
        DaCourse dat = new DaCourse();
        public void create(course c)
        {
            dat.create(c);
        }
        public void update(course t)
        {
            dat.update(t);
        }
        public int getVideoCount(int id)
        {
            return dat.getVideoCount(id);
        }
        public void getcourseteacher(int id)
        {
            dat.getcourseteacher(id);
        }
        public List<course> PaginationAndSearch(string text, int page)
        {
            return dat.PaginationAndSearch(text, page);
        }
      
        public List<course> search(string text)
        {

            return dat.search(text);

        }
        
        public course searchbyid(int id)
        {
            return dat.searchbyid(id);
        }

        public List<course> SearchByIdBasket(List<int> ids)
        {
            return dat.SearchByIdBasket(ids);
        }

        public List<course> getall()
        {
            return dat.getall();
        }
        public List<course> getskip(int c)
        {
            return dat.getskip(c);
        }

        public double gettotal()
        {
            return dat.gettotal();
        }
        public List<course> search(List<String> lstsearch)
        {
            return dat.search(lstsearch);
        }
        
        public void Delete(course course)
        {
            dat.Delete(course);
        }



    }
}
