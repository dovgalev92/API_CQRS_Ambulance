using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities
{
    public class StreetConfiguration : BaseEntityConfiguration<Street>
    {
        protected override void AddConfigureEntity(EntityTypeBuilder<Street> builder)
        {
            builder.HasOne(l => l.Locality)
               .WithMany(str => str.Streets)
               .HasForeignKey(fk => fk.LocalityId)
               .IsRequired();
            builder.HasMany(p => p.Patients)
                .WithOne(str => str.Street);
        }
    }
}
