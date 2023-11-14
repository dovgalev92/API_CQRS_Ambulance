using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambulance_API_CQRS.Domain.Entities.Base;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(i => i.Id)
                .IsRequired();

            AddConfigureEntity(builder);
        }
        /// <summary>
        /// add configure your entity
        /// </summary>
        /// <param name="builder"></param>
        protected abstract void AddConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
