using DAL;
using LearnAsa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BE;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace LearnAsa.Controllers
{
    public class AccountController : Controller
    {
       
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
           
        }
        



        public IActionResult Index()
        {
           
            return View();
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
      
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                ModelState.AddModelError(nameof(model.Username), "این نام کاربری در سیستم موجود میباشد");

                return View(model);
            }

            var newUser = new AppUser
            {
                UserName = model.Username,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await userManager.CreateAsync(newUser, model.Password);

            if (model.Password != model.PasswordTow)
            {
                ModelState.AddModelError("", "پسورد همسان نیست!");

                return View(model);
            }
        
           
            return RedirectToAction("Login", "Account");
           
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این نام کاربری پیدا نشد");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded == false)
            {
                ModelState.AddModelError("", "نام کاربری و یا رمزعبور اشتباه است");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim("fullName", $"{user.FirstName} {user.LastName}")
            };

            var appIdentity = new ClaimsIdentity(claims);

            User.Identities.FirstOrDefault().Label = "sepideh salimi";

           
            return RedirectToAction("index", "home");
        }

        //[Authorize]
        public async Task<IActionResult> logout()
        {

            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var model = new EditProfileModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username=user.UserName
               

            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName= model.FirstName;
            user.LastName= model.LastName;
            user.UserName = model.Username;
            user.Email= model.Email;
      
           
            var result=  await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
               TempData["message"] = "اطلاعات شما با موفقیت بروزرسانی شد.";
                return RedirectToAction("Index","Profile");
            }

            return View(model);
        }

    }
}
