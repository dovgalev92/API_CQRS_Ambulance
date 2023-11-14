using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities
{
    public class LocalityConfiguration : BaseEntityConfiguration<Locality>
    {
        protected override void AddConfigureEntity(EntityTypeBuilder<Locality> builder)
        {
            builder.HasMany(str => str.Streets)
               .WithOne(l => l.Locality)
               .HasForeignKey(fk => fk.LocalityId)
               .IsRequired();
            builder.HasMany(p => p.Patients)
                .WithOne(l => l.Locality);
        }
    }
}
