using Microsoft.AspNetCore.Mvc;

namespace LearnAsa.ViewComponents
{
    public class CourseViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL.BlCourse blc = new BLL.BlCourse();
            return View("Default", blc.getall());
        }
        //public async Task<IViewComponentResult> InvokeAsync(int courseId)
        //{

        //    var blcourse = new BLL.BlCourse();

        //    var course = blcourse.searchbyid(courseId);

        //    return View(course);

        //}
    }
}
