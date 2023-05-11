using Ajax.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ajax.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonContext db;

        public PersonController(PersonContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetList()
        {
            var personList = db.People.ToList();
            return PartialView("_GetListPartial", personList);
        }
        public IActionResult AddPerson()
        {
            return PartialView("_CreatePartial");
        }
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(person);
                db.SaveChanges();
                return Json("Ok");
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("hata");
            }
        }
        public IActionResult UpdatePerson(int id)
        {
            Person person=db.People.Where(a=>a.Id==id).FirstOrDefault();
            return PartialView("_UpdatePartial",person);
        }
        [HttpPost]
        public IActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                db.People.Update(person);
                db.SaveChanges();
                return Json("Ok");                
            }
            else
            {
                TempData["Message"] = "Başarısız işlem";
                return Json("hata");
            }
        }
        public IActionResult DeletePerson(int id)
        {
            Person person = db.People.Where(a => a.Id == id).FirstOrDefault();
            db.People.Remove(person);
            db.SaveChanges();
            return Json("Ok");
        }
    }
}
