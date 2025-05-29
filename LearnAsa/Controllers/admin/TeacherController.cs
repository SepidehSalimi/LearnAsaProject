using Microsoft.AspNetCore.Mvc;
using System;
using BE;
using BLL;
using Microsoft.AspNetCore.Hosting;
using NuGet.DependencyResolver;
using Newtonsoft.Json.Linq;

namespace LearnAsa.Controllers.admin
{
    public class TeacherController : Controller
    {
        private IWebHostEnvironment Environment;

        public TeacherController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult Showall()
        {
            BlTeacher blt =new  BlTeacher();
            return View("ShowTeacher",blt.getskip(0));
        }
        public IActionResult search(string search)
        {
            BlTeacher blteacher = new BlTeacher();
            var result = blteacher.PaginationAndSearch(search, 1);
            return PartialView("_searchPartial", result);
        }

        [HttpPost]
        public IActionResult create(Models.Teacher t)
        {
            BlTeacher blt=new BlTeacher();
            BE.Teacher bet = new Teacher();
            bet.name=t.name;
            bet.family=t.family;    
            bet.email=t.email;
            uploadfile uf = new uploadfile(Environment);
            bet.pic = uf.upload(t.pic); 
            blt.create(bet);
           
            return RedirectToAction(nameof(Showall));


        }
        public string update(Models.Teacher t)  
        {

            BlTeacher blt = new BlTeacher();
          
            var item = blt.searchbyid(t.id);

            item.name = t.name;
            item.family = t.family;
            item.email = t.email;
            uploadfile uf = new uploadfile(Environment);
            if (t.pic != null)
                item.pic = uf.upload(t.pic);
            blt.update(item);
            return "ثبت شد";
        }

        public IActionResult getskip(int c)
        {
            BlTeacher blt = new BlTeacher();
            return View("ShowTeacher", blt.getskip(c));
        }

        [HttpPost]
        public IActionResult Delete(int iddelete)
        {
            BlTeacher blt = new BlTeacher();
            var tt = blt.searchbyid(iddelete);
            if (tt == null)
            {
                return NotFound();
            }
          
            blt.Delete(tt);
            var result = blt.PaginationAndSearch("", 1);
            return PartialView("_searchPartial", result);
        }



    }
}
