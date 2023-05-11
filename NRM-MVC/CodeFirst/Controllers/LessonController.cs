using CodeFirst.Entities.Concrete;
using CodeFirst.Models;
using CodeFirst.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class LessonController : Controller
    {
        private readonly IRepository<Lesson> lessonRepository;

        public LessonController(IRepository<Lesson> lessonRepository)
        {
            this.lessonRepository = lessonRepository;
        }
        public IActionResult Index()
        {
            var lessonList = lessonRepository.GetAll().ToList();
            return View(lessonList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LessonCreateVM lessonCreateVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            Lesson lesson = new() { Name = lessonCreateVM.Name };
            var result = lessonRepository.Add(lesson);
            if (result)
            {
                TempData["Bildiri"] = "Kayıt işlemi başarılır bir şekilde gerçekleşti";
                return RedirectToAction("Index");
            }
            ViewBag.Bildiri = "Kayıt yaparken bir yerde hata oluştu. tekrar deneyiniz";
            return View();
        }

    }
}
