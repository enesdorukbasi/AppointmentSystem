using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Persistence.Context;
using AppointmentSystem.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentSystem.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppointmentSqlContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPatientUserRepository, PatientUserRepository>();
            services.AddScoped<IDoctorUserRepository, DoctorUserRepository>();
            services.AddScoped<IPoliclinicRepository, PoliclinicRepository>();
        }
    }
}
