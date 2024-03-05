using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopCMS.Data;
using OnlineShopCMS.Models;

namespace OnlineShopCMS.Controllers
{
    public class UserController : Controller
    {

        private readonly OnlineShopContext context;
        public UserController(OnlineShopContext context)
        {
            this.context = context;
        }
        
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            var myUser = context.User.Where(x => x.Email == u.Email && x.Password == u.Password).FirstOrDefault();
            if(myUser != null)
            {
                HttpContext.Session.SetString("UserSession", myUser.Name);
                return RedirectToAction("Index", "Products");
            }
            return View();
        }

        public IActionResult Signup()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value="Male", Text="Male"},
                new SelectListItem{Value="Female", Text="Female"}
            };
            ViewBag.Gender = Gender;
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Signup(User u)
        {
            if(ModelState.IsValid)
            {
                await context.User.AddAsync(u);
                await context.SaveChangesAsync();
                TempData["Success"] = "Registered Success";
                return RedirectToAction("Login");
            }
            return View(u);
        }

        public IActionResult Logout()
        {
            if(HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }


                



    }
}
