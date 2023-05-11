using CodeFirst.Entities.Concrete;
using CodeFirst.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
