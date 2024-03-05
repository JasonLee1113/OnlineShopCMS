using Microsoft.AspNetCore.Mvc;
using OnlineShopCMS.Data;
using OnlineShopCMS.Models;
using System.Diagnostics;

namespace OnlineShopCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly OnlineShopContext context;

        public HomeController(OnlineShopContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            RedirectToAction("Login");

            if (HttpContext.Session.GetString("UserSession") != null)           //判斷 登入變logout、登出變login
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }

        public IActionResult Privacy()
        {

            if (HttpContext.Session.GetString("UserSession") != null)           //判斷 登入變logout、登出變login
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            if (HttpContext.Session.GetString("UserSession") != null)           //判斷 登入變logout、登出變login
            {
                ViewData["MySession"] = HttpContext.Session.GetString("UserSession").ToString();
            }

            return View();
        }





    }
}
