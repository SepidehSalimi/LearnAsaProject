using Microsoft.AspNetCore.Mvc;

namespace LearnAsa.ViewComponents
{
    public class TeacherViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            BLL.BlTeacher blt = new BLL.BlTeacher();
            return View("_Teacher", blt.getall());
        }

    }
}
