using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ambulance_API_CQRS.Infrastructure.EfCore
{
    public class ApplicationDbContext : DbContext, IApplicationDb
    {
        public DbSet<Patient> Patients => Set<Patient>();

        public DbSet<CallingAmbulance> Callings => Set<CallingAmbulance>();

        public DbSet<AmbulanceDepart> Departs => Set<AmbulanceDepart>();

        public DbSet<Locality> Localities => Set<Locality>();

        public DbSet<Street> Streets => Set<Street>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
