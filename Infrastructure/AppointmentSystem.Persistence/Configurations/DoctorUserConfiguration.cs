using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Persistence.Configurations
{
    public class DoctorUserConfiguration : IEntityTypeConfiguration<DoctorUser>
    {
        public void Configure(EntityTypeBuilder<DoctorUser> builder)
        {
            builder.Property(x => x.Degree).IsRequired();
            builder.Property(x => x.PoliclinicId).IsRequired();
            builder.HasMany(x => x.Appointments).WithOne(x => x.DoctorUser).HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
