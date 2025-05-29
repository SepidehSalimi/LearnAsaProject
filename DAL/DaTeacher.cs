using BE;

namespace DAL
{
    public class DaTeacher
    {
        db db = new db();
        public void create(Teacher t)
        {
            db.teacher.Add(t);
            db.SaveChanges();
        }
        public List<Teacher> getall()
        {
            return db.teacher.ToList();
        }
        public List<Teacher> Existed(int[] ids)
        {
            if (ids != null)
            {
                foreach (var item in ids)
                {
                    var teachers = new List<Teacher>();
                    foreach (var item1 in getall())
                    {
                        if (item == item1.id)
                        {
                            teachers.Add(item1);
                            return teachers;
                        }
                    }
                }
            }
            return null;
        }
        public List<Teacher> Pagination(int page)
        {

            int skip = (page - 1) * 10;
            return db.teacher.Skip(skip).Take(10).ToList();
        }
        public int gettotal()
        {
            return db.teacher.Count();
        }

        public List<Teacher> getskip(int c)
        {
            int t = c * 10;
            var q = db.teacher.Skip(t).Take(10);
            return q.ToList();
        }

        public List<Teacher> PaginationAndSearch(string text, int page)
        {
            if (page == 0)
            {
                page = 1;
            }
            int skip = (page - 1) * 10;
            return search(text).Skip(skip).Take(10).ToList();
        }
        //
        public List<Teacher> search(string text)
        {
            if (text == "" || text == null)
            {
                return db.teacher.ToList();
            }
            return db.teacher.Where(q => q.name.Contains(text) || q.family.Contains(text)).ToList();
        }
        public List<Teacher> searchbylist(List<String> lstsearch)
        {
            List<Teacher> te = new List<Teacher>();
            foreach (var item in lstsearch)
            {
             
                var q = search(item);
                te = te.Concat(q.ToList()).ToList();
            }
            return te;
        }
        //
        public Teacher searchbyid(int id)
        {
            return db.teacher.Find(id);
        }
        public void update(Teacher t)
        {
            
          
            var q = searchbyid(t.id);
         
            q.name = t.name;
            q.family = t.family;
            q.email = t.email;
            if (t.pic != null)
            {
                q.pic = t.pic;
            }

            db.SaveChanges();
        }

        public void Delete(Teacher t)
        {
            db.teacher.Remove(t);
            db.SaveChanges();
        }

    }
}
