using CodeFirst.Entities.Concrete;

namespace CodeFirst.Repositories.Abstract
{
    public interface ISchoolRepository : IRepository<School>
    {
        List<School> GetAllSchoolsIncludeLessons();
    }
}
