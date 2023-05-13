using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ClassRepository : RepositoryBase<Class>
    {
        public ClassRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<Class> GetAllWithStudentCount()
        {
            return GetRecords()
                .Include(c => c.Students)
                .Select(c => new Class
                {
                    Id = c.Id,
                    Name = c.Name,
                    StudentCount = c.Students.Count

                }).ToList();
        }
    }
}
