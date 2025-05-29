using BE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BE;
using System.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DAL
{
    public class db : IdentityDbContext<AppUser>
    {
        public db() : base() { }
        public db(DbContextOptions<db> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=blogging.db");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-7JHHOIU\\WEB;Initial Catalog=rr;Integrated Security=True;User ID = t1; Password =1");
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=LearnAsa;Integrated Security=True; Encrypt=False;");
            base.OnConfiguring(optionsBuilder);
        }


        public DbSet<course> course { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<courseteacher> courseteachers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Order_Course> order_courses { get; set; }
        public DbSet<course_detailfile> file { get; set; }

    }
}
