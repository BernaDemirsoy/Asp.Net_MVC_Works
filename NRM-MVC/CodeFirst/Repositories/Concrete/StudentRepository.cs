using CodeFirst.AppDbContext;
using CodeFirst.Entities.Concrete;
using CodeFirst.Repositories.Abstract;

namespace CodeFirst.Repositories.Concrete
{
    public class StudentRepository : GenericRepository<Student> ,IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
    }
}
