using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using MediatR;
using AutoMapper;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientId
{
    public class GetPAtientIdQueryHandler : IRequestHandler<GetPatientIdQuery, GetPatientIdDto>
    {
        private readonly IPatientRepos _patientRepos;
        private readonly IMapper _mapper;
        public GetPAtientIdQueryHandler(IPatientRepos patientRepos, IMapper mapper)
            => (_patientRepos, _mapper) = (patientRepos, mapper);
        
        public async Task<GetPatientIdDto> Handle(GetPatientIdQuery request, CancellationToken cancellation)
        {
            var queryId = await _patientRepos.GetPatientById(request.Id);
            
            return _mapper.Map<GetPatientIdDto>(queryId);

        }
    }
}
