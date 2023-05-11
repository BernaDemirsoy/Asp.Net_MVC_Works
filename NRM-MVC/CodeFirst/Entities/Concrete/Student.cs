using CodeFirst.Entities.Abstract;

namespace CodeFirst.Entities.Concrete
{
    public class Student : BaseEntity
    {
        public string Class { get; set; }

        public School School { get; set; }
        public Lesson Lessons { get; set; }
    }
}
