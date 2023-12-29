using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using AutoMapper;
using MediatR;


namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsQueryHandler : IRequestHandler<GetPatientDetailsQuery, GetPatientDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepos _repos;
        public GetPatientDetailsQueryHandler(IMapper mapper, IPatientRepos repos)
            => (_mapper, _repos) = (mapper, repos);

        public async Task<GetPatientDetailsDto> Handle(GetPatientDetailsQuery request, CancellationToken cancellationToken)
        {
            var queryId = await _repos.GetPatientById(request.Id);

            return _mapper.Map<GetPatientDetailsDto>(queryId);

        }
    }
}
