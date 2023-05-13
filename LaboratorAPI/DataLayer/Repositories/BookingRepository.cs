using DataLayer.Entities;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>
    {
        private readonly AppDbContext dbContext;

        public BookingRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Booking> GetBookingsByCustomerID(int customerID)
        {
            var result = dbContext.Bookings
                .Where(e => e.CustomerID == customerID
                && e.Deleted == false)
                .ToList();

            return result;
        }

        public List<Booking> GetBookingsByRoomID(int roomID)
        {
            var result = dbContext.Bookings
                .Where(e => e.RoomID == roomID
                && !e.Deleted)
                .ToList();

            return result;
        }

        public List<Booking> GetBookingsAfterStartDate(DateTime date)
        {
            var result = dbContext.Bookings
                .Where(e => e.DateFrom >= date.Date
                && !e.Deleted)
                .ToList();

            return result;
        }

        public List<Booking> GetBookingsByCurrentDate(DateTime currentDate)
        {
            var result = dbContext.Bookings
                .Where(e => e.DateFrom == currentDate.Date
                && !e.Deleted)
                .ToList();

            return result;
        }
    }
}
