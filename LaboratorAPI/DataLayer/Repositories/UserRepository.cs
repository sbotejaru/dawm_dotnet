using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public User GetByUsername(string userUsername)
        { 
            var results = dbContext.Users
                .Where(e => e.Username == userUsername
                && e.Deleted == false)
                .FirstOrDefault();

            return results;
        }

        public User GetByUsernameAndPassword(string userUsername, string userPassword)
        {
            var results = dbContext.Users
                .Where(e => e.Username == userUsername
                && e.Password == userPassword
                && e.Deleted == false)
                .FirstOrDefault();

            return results;

        }

        public User GetByRole(RoleType userRole)
        {
            var results = dbContext.Users
                .Where(e => e.RoleID == userRole
                && e.Deleted == false)
                .FirstOrDefault();

            return results;
        }

    }
}
