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
            builder.HasOne(p => p.Patient)
                .WithOne(p => p.CallingAmbulance);
            builder.HasOne(d => d.Departure)
                .WithOne(c => c.Calling);
            builder.HasIndex(idx => idx.DateCall);
        }
    }
}
