using BE;
using DAL;


namespace BLL
{
    public class BlTeacher
    {
        DaTeacher dat =new DaTeacher();
        public void create(Teacher t)
        {
            dat.create(t);
        }
        public void update(Teacher t)
        {
            dat.update(t);
        }
        public List<Teacher> getall()
        {
            return dat.getall();

        }
        public List<Teacher> Existed(int[] ids)
        {
            return dat.Existed(ids);
        }
        public void Delete(Teacher t)
        {
            dat.Delete(t);
        }
        public List<Teacher> Pagination(int page)
        {
            return dat.Pagination(page);
        }
        
        public List<Teacher> PaginationAndSearch(string text, int page)
        {
            return dat.PaginationAndSearch(text, page);
        }
        public int gettotal()
        {
            return dat.gettotal();
        }
        public List<Teacher> getskip(int c)
        {
            return dat.getskip(c);
        }
        public List<Teacher> searchbylist(List<String> lstsearch)
        {
            return dat.searchbylist(lstsearch);
        }
        public List<Teacher> search(string text)
        {
            return dat.search(text);
        }
        public Teacher searchbyid(int id)
        {
            return dat.searchbyid(id);
        }
    }
}
