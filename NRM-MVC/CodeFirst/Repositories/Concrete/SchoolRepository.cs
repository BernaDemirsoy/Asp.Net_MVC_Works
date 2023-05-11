using CodeFirst.AppDbContext;
using CodeFirst.Entities.Concrete;
using CodeFirst.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Repositories.Concrete
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        private readonly ApplicationDbContext db;

        public SchoolRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }

        public List<School> GetAllSchoolsIncludeLessons()
        {
            return db.Schools.Include(a => a.Lessons).ToList();
        }
    }
}
