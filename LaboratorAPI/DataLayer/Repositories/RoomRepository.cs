using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class RoomRepository : RepositoryBase<Room>
    {
        private readonly AppDbContext dbContext;

        public RoomRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
