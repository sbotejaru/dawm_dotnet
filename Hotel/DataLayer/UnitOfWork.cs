using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public AdminRepository Admins { get; }
        public BookingRepository Bookings { get; }
        public CustomerRepository Customers { get; }
        public EmployeeRepository Employees { get; }
        public RoleRepository Roles { get; }
        public RoomRepository Rooms { get; }
        public UserRepository Users { get; }


        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            AdminRepository admins,
            BookingRepository bookings,
            CustomerRepository customers,
            EmployeeRepository employees,
            RoleRepository roles,
            RoomRepository rooms,
            UserRepository users

        )
        {
            _dbContext = dbContext;
            Admins = admins;
            Bookings = bookings;
            Customers = customers;
            Employees = employees;
            Roles = roles;
            Rooms = rooms;
            Users = users;

        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
