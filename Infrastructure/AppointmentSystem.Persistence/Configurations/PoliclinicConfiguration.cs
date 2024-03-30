using AppointmentSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentSystem.Persistence.Configurations
{
    public class PoliclinicConfiguration : IEntityTypeConfiguration<Policlinic>
    {
        public void Configure(EntityTypeBuilder<Policlinic> builder)
        {
            builder.HasKey(x => x.PoliclinicId);
            builder.Property(x => x.Definition).IsRequired();
            builder.HasMany(x => x.DoctorUsers).WithOne(x => x.Policlinic).HasForeignKey(x => x.PoliclinicId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
