using CookieSession.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookieSession.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            User user = new();
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Name")) && !string.IsNullOrEmpty(HttpContext.Session.GetInt32("Age").ToString()))
            {
                user.Name = HttpContext.Session.GetString("Name");
                user.Age = (int)HttpContext.Session.GetInt32("Age");
            }

            return View(user);
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            HttpContext.Session.SetString("Name", user.Name);
            HttpContext.Session.SetInt32("Age", user.Age);

            return RedirectToAction("Index");
        }

        public IActionResult BeniUnut()
        {
            HttpContext.Session.Remove("Name");//içini siliyor.
            HttpContext.Session.Remove("Age");
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
