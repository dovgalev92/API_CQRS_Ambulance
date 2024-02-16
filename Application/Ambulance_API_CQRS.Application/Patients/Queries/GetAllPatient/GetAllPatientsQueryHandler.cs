using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PagedList<Patient>>
    {
        private readonly IPatientRepos _repos;
        public GetAllPatientsQueryHandler(IPatientRepos repos)
                => (_repos) = (repos);
        public async Task<PagedList<Patient>> Handle (GetAllPatientsQuery request, CancellationToken cancellation)
        {
            var query = await _repos.GetAllPatients(request.Parametr);
            return query;
        }
    }
}
