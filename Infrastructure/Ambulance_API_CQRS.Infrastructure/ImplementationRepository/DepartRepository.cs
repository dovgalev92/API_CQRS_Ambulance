using Ambulance_API_CQRS.Application.Common.Exceptions;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;

namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class DepartRepository : IDepartRepository
    {
        private readonly IApplicationDb _application;
        public DepartRepository(IApplicationDb application) => _application = application;

        public async Task CreateDepart(int id, AmbulanceDepart depart)
        {
            var queryId = _application.Callings.SingleOrDefault(x => x.Id == id) != null ? await _application.Departs.AddAsync(depart)
            : throw new NotFoundException(nameof(CallingAmbulance), id);

        }
    }
}
