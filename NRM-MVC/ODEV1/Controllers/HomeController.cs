using Microsoft.AspNetCore.Mvc;
using ODEV1.Models;
using System.Diagnostics;

namespace ODEV1.Controllers
{ 
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //Guncel bir login giris ekranı istiyorum.Kullanıcı üye değilse kayıt olma ekranına tıklasın kayıt olsun. Kayıt olma ekranında isim, soyisim , doğum tarihi seçtirin , cinsiyeti, telefon numarası, tc:no bilgileirni alalım, username , şifre , şifre tekrar ekranları olsun. Bu bilgileri girdikten sonra Index sayfasına yönlensin.Index sayfasında bir kullanıcı card'ı şeklinde oluşturdugunuz ekrana (yaş bilgisini ayrı verelim) bilgileri yerleştirin. Geliştirmekte tabikide özgürsünüz :)...Model kullanım.. Enum kullanımı...
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();  
        }
        public IActionResult Create()
        {
            RegisterVM registerVM = new RegisterVM() { FullName="Buraya Adınızı yazın",Email="Buraya Email yazın"};
            return View( registerVM);
        }
        [HttpPost]
        public IActionResult Create(string id,RegisterVM registerVM)
        {
            //
            return View(registerVM);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}