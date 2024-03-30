using AppointmentSystem.Domain.Entities;
using AppointmentSystem.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Persistence.Context
{
    public class AppointmentSqlContext : DbContext
    {
        public AppointmentSqlContext(DbContextOptions<AppointmentSqlContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<PatientUser> PatientUsers { get; set; }
        public DbSet<DoctorUser> DoctorUsers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorUserConfiguration());
            modelBuilder.ApplyConfiguration(new PatientUserConfiguration());
            modelBuilder.ApplyConfiguration(new PoliclinicConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
        }
    }
}
