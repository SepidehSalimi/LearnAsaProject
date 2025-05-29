using BE;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LearnAsa.Controllers
{
    public class PaymentController : Controller
    {
        private UserManager<AppUser> userManager;
       
        public PaymentController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            
        }

        public async Task <IActionResult> Payment()
        {
            var coursesInBasket = new List<course>();
            var jsonItems = HttpContext.Session.GetString("basket");

            if (jsonItems != null)
            {
                coursesInBasket = JsonConvert.DeserializeObject<List<course>>(jsonItems);

                var user = await userManager.FindByNameAsync(User.Identity.Name);

                BlOrder blO = new BlOrder();
                var ordercources = new List<Order_Course>();
                foreach (var item in coursesInBasket)
                {
                    ordercources.Add(new Order_Course { CourseId = item.id });
                }

                blO.create(new Order
                {
                    order_courses = ordercources,
                    TotalPric = coursesInBasket.Sum(s => s.price),
                    userId = user.Id 

                });
                HttpContext.Session.Remove("basket");
                TempData["message"] = "پرداخت با موفقیت انجام شد.";

            }
            return RedirectToAction("Index","Profile");
        }
    }
}
















//ViewBag.SuccessPayment = "پرداخت با موفقیت انجام شد.";
//, new { message = "پرداخت با موفقیت انجام شد." }