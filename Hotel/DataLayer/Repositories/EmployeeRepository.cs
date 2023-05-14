using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace DataLayer.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        private readonly AppDbContext dbContext;

        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee GetEmployeeByUserID(int userID)
        {
            var result = dbContext.Employees
                .Where(e => e.UserID == userID
                && !e.Deleted)
                .FirstOrDefault();

            return result;
        }
    }
}
