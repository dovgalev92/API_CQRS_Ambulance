using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using MediatR;
using AutoMapper;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientId
{
    public class GetPAtientIdQueryHandler : IRequestHandler<GetPatientIdQuery, GetPatientIdDto>
    {
        private readonly IPatientRepos _patientRepos;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public GetPAtientIdQueryHandler(IPatientRepos patientRepos, IMapper mapper, ILoggerManager logger)
            => (_patientRepos, _mapper, _logger) = (patientRepos, mapper, logger);
        
        public async Task<GetPatientIdDto> Handle(GetPatientIdQuery request, CancellationToken cancellation)
        {
            _logger.LogInfo($"Started quering in database for get patientId {request.Id}");
            var queryId = request.Id != 0 ? await _patientRepos.GetPatientById(request.Id) : throw new ArgumentException("patientId cannot be 0", nameof(request.Id));

            return _mapper.Map<GetPatientIdDto>(queryId);
        }
    }
}
