using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnAsa.Controllers
{
   // [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index(string ShowBasket)
        {
            ViewBag.ShowBasket = ShowBasket;
            return View();
        }
       
    }
}
