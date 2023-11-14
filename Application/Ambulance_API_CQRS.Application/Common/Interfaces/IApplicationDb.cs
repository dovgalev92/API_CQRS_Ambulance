using Ambulance_API_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Application.Common.Interfaces
{
    public interface IApplicationDb
    {
        DbSet<Patient> Patients { get; }
        DbSet<CallingAmbulance> Callings { get; }
        DbSet<AmbulanceDepart> Departs { get; }
        DbSet<Locality> Localities { get; }
        DbSet<Street> Streets { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellation = default);
    }
}
