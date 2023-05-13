using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System.Xml.XPath;

namespace DataLayer.Repositories
{
    public class RoomRepository : RepositoryBase<Room>
    {
        private readonly AppDbContext dbContext;

        public RoomRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Room> GetAllFreeRooms()
        {
            var results = dbContext.Rooms
                .Where(e => e.IsAvailableFrom >= DateTime.Today.Date
                && e.Deleted == false)
                .ToList();

            return results;
        }

        public List<Room> GetAllFreeRoomsForDate(DateTime date)
        {
            var results = dbContext.Rooms
                .Where(e => e.IsAvailableFrom >= date.Date
                && e.Deleted == false)
                .ToList();

            return results;
        }

        public List<Room> GetAllFreeRoomsByType(string roomType)
        {
            var results = dbContext.Rooms
                .Where(e => e.RoomType == roomType
                && !e.Deleted)
                .ToList();

            return results;
        }

        public List<Room> GetAllFreeRoomsCheaperThan(float price)
        {
            var results = dbContext.Rooms
                .Where(e => e.Price <= price
                && !e.Deleted)
                .ToList();

            return results;
        }
    }
}
