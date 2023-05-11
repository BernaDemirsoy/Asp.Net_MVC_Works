using Microsoft.AspNetCore.Mvc;
using NRM_MVC.Models;
using System.Diagnostics;

namespace NRM_MVC.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //Yeni bir view ekranı tasarlanacak. Bu ekranda giriş yapılmasını istiyorum.Kullanıcı adı: sa , şifresi 12345
        //Form yöntemi ile kullancı adı ve şifresi alınacak.
        public IActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            if (userName.Trim() == "sa" && password.Trim() == "12345")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Message = "Hatalı giriş yaptınız";
            //TempData["Denek"] = "Eksik giriş";
            return RedirectToAction("Login");
        }

        //Guncel bir login giris ekranı istiyorum. Kullanıcı üye değilse kayıt olma ekranına tıklasın kayıt olsun. Kayıt olma ekranında isim, soyisim , doğum tarihi seçtirin , cinsiyeti, telefon numarası, tc:no bilgileirni alalım, username , şifre ,şifre tekrar ekranları olsun. Bu bilgileri girdikten sonra Index sayfasına yönlensin. Index sayfasında bir kullanıcı card'ı şeklinde oluşturdugunuz ekrana (yaş bilgisini ayrı verelim) bilgileri yerleştirin. Geliştirmekte tabikide özgürsünüz :)...Model kullanım.. Enum kullanımı...


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}