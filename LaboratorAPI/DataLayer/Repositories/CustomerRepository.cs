using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        private readonly AppDbContext dbContext;

        public CustomerRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Customer GetCustomerByUserID(int userID)
        {
            var result = dbContext.Customers
                .Where(e => e.UserID == userID
                && !e.Deleted)
                .FirstOrDefault();

            return result;
        }
    }
}
