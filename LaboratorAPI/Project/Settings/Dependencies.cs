using DataLayer.Repositories;
using Core.Services;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Project.Settings
{
    public static class Dependencies
    {

        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDbContext>();

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }

        private static void AddServices(IServiceCollection services)
        {
            //services.AddScoped<StudentService>();
           // services.AddScoped<ClassService>();
           // services.AddScoped<GradeService>();
            services.AddScoped<AdminService>();
            services.AddScoped<BookingService>();
            services.AddScoped<CustomerService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<RoleService>();
            services.AddScoped<RoomService>();
            services.AddScoped<UserService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            //services.AddScoped<StudentsRepository>();
            //services.AddScoped<ClassRepository>();
            //services.AddScoped<GradesRepository>();
            services.AddScoped<AdminRepository>();
            services.AddScoped<BookingRepository>();
            services.AddScoped<CustomerRepository>();
            services.AddScoped<EmployeeRepository>();
            services.AddScoped<RoleRepository>();
            services.AddScoped<RoomRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<UnitOfWork>();
        }

    }
}
