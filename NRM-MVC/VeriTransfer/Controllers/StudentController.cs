using Microsoft.AspNetCore.Mvc;
using VeriTransfer.Data;
using VeriTransfer.Models;

namespace VeriTransfer.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> students;
        public StudentController()
        {
            students = DefaultData.Students;
        }
        public IActionResult Index()
        {
            ViewBag.Header = "Öğrenci İşlemleri";
            ViewData["list"] = students;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateVM studentCreateVM)
        {
            Student student = new();
            student.FirstName = studentCreateVM.FirstName;
            student.LastName = studentCreateVM.LastName;
            student.Age= studentCreateVM.Age;
            student.Id = DefaultData.Id;
            students.Add(student);
            TempData["Success"] = "Kayıt işlemi başarılı";
            return RedirectToAction("Index");
        }
        public IActionResult Anasayfa()
        {
            ViewBag.Header = "Öğrenci Anasayfa";
            ViewData["list"] = students;
            return View();
        }

        public IActionResult YasaGore()
        {
            return View(students);
        }
    }
}
