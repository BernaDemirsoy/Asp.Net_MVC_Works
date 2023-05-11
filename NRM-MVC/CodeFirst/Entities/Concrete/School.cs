using CodeFirst.Entities.Abstract;

namespace CodeFirst.Entities.Concrete
{
    public class School : BaseEntity
    {
        public School()
        {
            Students = new HashSet<Student>();
            Lessons = new List<Lesson>();
        }
        public ICollection<Student> Students { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
