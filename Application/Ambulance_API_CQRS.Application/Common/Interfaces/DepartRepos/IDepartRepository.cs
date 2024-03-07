using Ambulance_API_CQRS.Domain.Entities;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos
{
    public interface IDepartRepository
    {
        Task CreateDepart(int id, AmbulanceDepart depart);
        Task<AmbulanceDepart> GetDepartId (int id);
        Task EditDepat(int id, AmbulanceDepart depart);
    }
}
