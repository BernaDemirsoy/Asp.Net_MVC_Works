using CodeFirst.Entities.Abstract;

namespace CodeFirst.Entities.Concrete
{
    public class Lesson : BaseEntity
    {
        public Lesson()
        {
            Schools = new List<School>();
            Students = new List<Student>();
        }
        public ICollection<School> Schools { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
