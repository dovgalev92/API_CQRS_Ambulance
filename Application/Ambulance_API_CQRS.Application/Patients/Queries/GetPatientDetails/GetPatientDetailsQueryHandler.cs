using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using AutoMapper;
using MediatR;


namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsQueryHandler : IRequestHandler<GetPatientDetailsQuery, GetPatientDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepos _repos;
        private readonly ILoggerManager _logger;
        public GetPatientDetailsQueryHandler(IMapper mapper, IPatientRepos repos, ILoggerManager logger)
            => (_mapper, _repos, _logger) = (mapper, repos, logger);

        public async Task<GetPatientDetailsDto> Handle(GetPatientDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("Started quering in database for details patient");
            var queryId = await _repos.GetPatientById(request.Id);

            return _mapper.Map<GetPatientDetailsDto>(queryId);
        }
    }
}
