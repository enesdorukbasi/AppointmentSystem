using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Persistence.Configurations
{
    public class PatientUserConfiguration : IEntityTypeConfiguration<PatientUser>
    {
        public void Configure(EntityTypeBuilder<PatientUser> builder)
        {
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.City).IsRequired();
            builder.HasMany(x => x.Appointments).WithOne(x => x.PatientUser).HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
