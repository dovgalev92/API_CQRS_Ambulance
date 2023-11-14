using Ambulance_API_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities
{
    public class DepatrConfiguration : BaseEntityConfiguration<AmbulanceDepart>
    {
        protected override void AddConfigureEntity(EntityTypeBuilder<AmbulanceDepart> builder)
        {
            builder.HasOne(c => c.Calling)
                .WithOne(d => d.Departure)
                .HasForeignKey<AmbulanceDepart>(fk => fk.CallingAmbulanceId)
                .IsRequired();
            builder.Property(d => d.DateDepart)
                .HasColumnType("date");
            builder.HasIndex(d => d.DateDepart);
        }
    }
}
