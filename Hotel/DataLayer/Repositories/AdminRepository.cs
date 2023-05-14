using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>
    {
        private readonly AppDbContext dbContext;

        public AdminRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Admin GetAdminByUserID(int userID)
        {
            var result = dbContext.Admins
                .Where(e => e.UserID == userID)
                .FirstOrDefault();

            return result;
        }
    }
}
