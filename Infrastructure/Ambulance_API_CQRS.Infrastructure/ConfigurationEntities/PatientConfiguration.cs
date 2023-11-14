using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Infrastructure.ConfigurationEntities.BaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambulance_API_CQRS.Infrastructure.ConfigurationEntities
{
    public class PatientConfiguration : BaseEntityConfiguration<Patient>
    {
        protected override void AddConfigureEntity(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(d => d.BirthYear)
                .HasColumnType("date");
            builder.HasOne(c => c.CallingAmbulance)
                .WithOne(p => p.Patient)
                .HasForeignKey<Patient>(fk => fk.CallingAmbulanceId)
                .IsRequired();
            builder.HasOne(str => str.Street)
                .WithMany(p => p.Patients)
                .HasForeignKey(fk => fk.StreetId)
                .IsRequired(false);
            builder.HasOne(l => l.Locality)
                .WithMany(p => p.Patients)
                .HasForeignKey(fk => fk.LocalityId)
                .IsRequired(false);
            builder.HasIndex(p => new { p.Name, p.FamilyName, p.Patronymic });
        }
    }
}
