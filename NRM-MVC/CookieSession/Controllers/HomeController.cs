using CookieSession.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CookieSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            User user = new();
            string name = Request.Cookies["Name"];

            if (!string.IsNullOrEmpty(name))
            {
                user.Name = name;
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            CookieOptions options = new CookieOptions(); // Cookie optionsları oluşturulur.
            options.Expires = DateTime.Now.AddSeconds(10); // cookie'nin intihar ayarı :)
            Response.Cookies.Append("Name", user.Name, options);

            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            Response.Cookies.Delete("Name");
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}