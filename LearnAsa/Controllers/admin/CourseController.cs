using Microsoft.AspNetCore.Mvc;
using BE;
using BLL;
using LearnAsa.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace LearnAsa.Controllers.admin
{
    public class CourseController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnviroment;
        public CourseController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviroment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            BlTeacher blteacher = new BlTeacher();
            ViewBag.Teachers = blteacher.getall();
            return View();
            
        }

        [HttpPost]
        public ActionResult Create(Models.Course t)
        {
            var blc = new BLL.BlCourse();
            course tt = new course();

            BlTeacher blteacher = new BlTeacher();
            uploadfile uploadfile = new uploadfile(_webHostEnviroment);



            tt.title = t.title;
            tt.totaltime = t.totaltime;
            tt.price = t.price;
            tt.totaltime = t.totaltime;
            tt.descript = t.descript;
            tt.videointro = uploadfile.uploadVideo(t.videointro);
            if (t.teachers != null)
            {
                foreach (var item in t.teachers)
                {
                    if (item != null)
                    {
                        var teacher = blteacher.searchbyid(Convert.ToInt32(item));
                        tt.courseteachers.Add(new courseteacher { courseId = Convert.ToInt32(item), teacherId = teacher.id });
                    }
                }

            }

            blc.create(tt);


            return RedirectToAction(nameof(showcourse));

        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
           
            var blcourse = new BlCourse();

            var course = blcourse.searchbyid(id);

            if (course != null)
            {
                return View(course);
            }

            return NotFound();

        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddToBasket(int courseId)
        {

            var coursesInBasket = new List<course>();
            var jsonItems = HttpContext.Session.GetString("basket");

            if (jsonItems != null)
            {
                coursesInBasket = JsonConvert.DeserializeObject<List<course>>(jsonItems);
            }

            var blcourse = new BlCourse();

            var course = blcourse.searchbyid(courseId);

            if (course != null)
            {

                if (coursesInBasket.Where(s => s.id == courseId).Count() == 0)
                {
                    coursesInBasket.Add(course);
                }

                HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(coursesInBasket, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            }

            return RedirectToAction("details", new { id = courseId });
        }


        public ActionResult showcourse(int id = 1)

        {
            BlCourse blcourse = new BlCourse();
            double Pages = Math.Ceiling(blcourse.gettotal() / 10);
            ViewBag.CurrentPage = id;
            ViewBag.PageCount = Pages;
            ViewBag.Count = blcourse.gettotal();
            return View(blcourse.PaginationAndSearch("", id));
        }
        //new
        [HttpGet]
        public IActionResult search(string search)
        {
            BlCourse blcourse = new BlCourse();
            var result = blcourse.PaginationAndSearch(search, 1);
            return PartialView("_coursePartial", result);
        }
        public IActionResult Edit(int id)
        {
            BlCourse blcourse = new BlCourse();
            BlTeacher blteacher = new BlTeacher();

            var model = blcourse.searchbyid(id);

            if (model == null)
            {
                return NotFound();
            }
            var course = new Models.Course
            {
                id = model.id,
                title = model.title,
                descript = model.descript,
                price = model.price,
                totaltime = model.totaltime
            };
            var Exteachers = model.courseteachers.Where(q => q.courseId == course.id).Select(q => q.teacher).ToList();
            var teachers = blteacher.getall();
            if (Exteachers.Count != 0)
            {
                foreach (var item in Exteachers)
                {
                    var t = teachers.FirstOrDefault(q => q.id == item.id);
                    teachers.Remove(t);
                }
            }

            ViewBag.Exsited = Exteachers;
            ViewBag.Teachers = teachers;
            return View(course);
        }
        [HttpPost]
        public IActionResult Edit(Models.Course model)
        {
            if (ModelState.IsValid)
            {
                uploadfile uploadfile = new uploadfile(_webHostEnviroment);
                BlCourse blcourse = new BlCourse();
                BlTeacher blteacher = new BlTeacher();
               

                var course = blcourse.searchbyid(model.id);
                if (course == null)
                {
                    return NotFound();

                }
                course.title = model.title;
                course.descript = model.descript;
                course.price = model.price;
                course.totaltime = model.totaltime;
                course.videointro = (model.videointro != null) ? uploadfile.uploadVideo(model.videointro) : course.videointro;
                var courses = course.courseteachers.ToList();
                blcourse.getcourseteacher(course.id);
                if (model.teachers != null)
                {

                    foreach (var item in model.teachers)
                    {
                        if (item != null)
                        {
                            var teacher = blteacher.searchbyid(Convert.ToInt32(item));

                            course.courseteachers.Add(new courseteacher { courseId = Convert.ToInt32(item), teacherId = teacher.id });
                        }
                    }

                }
                blcourse.update(course);
                return RedirectToAction(nameof(showcourse));
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int iddelete)
        {
            BlCourse blcourse = new BlCourse();
            var course = blcourse.searchbyid(iddelete);
            if (course == null)
            {
                return NotFound();
            }

            blcourse.Delete(course);
            var result = blcourse.PaginationAndSearch("", 1);
            return PartialView("_coursePartial", result);
        }
      


    } 
}
