using Microsoft.EntityFrameworkCore;
using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities
{
    public class CallingConfiguration : BaseEntityConfiguration<CallingAmbulance>
    {
        protected override void AddConfigureEntity(EntityTypeBuilder<CallingAmbulance> builder)
        {
            builder.Property(d => d.DateCall)
                .HasColumnType("date");
            builder.HasOne(c => c.Patient)
                .WithMany(c => c.CallingAmbulance)
                .HasForeignKey(fk => fk.PatientId)
                .IsRequired();
            builder.HasOne(d => d.Departure)
                .WithOne(c => c.Calling);
            builder.HasIndex(idx => idx.DateCall);
        }
    }
}
