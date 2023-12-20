using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using AutoMapper;
using MediatR;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, GetAllPatientVm>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepos _repos;
        public GetAllPatientsQueryHandler(IMapper mapper, IPatientRepos repos)
                => (_mapper, _repos) = (mapper, repos);
        public async Task<GetAllPatientVm> Handle (GetAllPatientsQuery request, CancellationToken cancellation)
        {
            var query = await _repos.GetAllPatients();
            var mapp = _mapper.Map<IEnumerable<GetAllPatientDto>>(query);

            return new GetAllPatientVm { AllPatients = mapp };

        }
    }
}
