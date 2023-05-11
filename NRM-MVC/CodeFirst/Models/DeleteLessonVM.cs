using CodeFirst.Entities.Concrete;

namespace CodeFirst.Models
{
    public class DeleteLessonVM
    {
        public int SchoolId { get; set; }
        public List<Lesson> Lessons{ get; set; }
        public int LessonId { get; set; }
        public string Name { get; set; }
    }
}
