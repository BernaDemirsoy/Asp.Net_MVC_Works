using CodeFirst.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.ViewComponents
{
    public class StudentViewComponent : ViewComponent
    {
        private readonly IStudentRepository studentRepository;

        //Shared/Components/Student/Default klasöründe bulunan View tetiklendiğinde bu class aktif olarka çalışacaktır.
        //ViewComponentlar bu klasın sahip olduğu metotlar ile çalışmaktadır. Yani controller ile çalışmazlarr....

        public StudentViewComponent(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IViewComponentResult Invoke()
        {
            var studentList = studentRepository.GetAll().ToList();
            return View(studentList);
        }
    }
}
