using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, PagedList<Patient>>
    {
        private readonly IPatientRepos _repos;
        private readonly ILoggerManager _logger;
        public GetAllPatientsQueryHandler(IPatientRepos repos, ILoggerManager logger)
                => (_repos, _logger) = (repos, logger);
        public async Task<PagedList<Patient>> Handle (GetAllPatientsQuery request, CancellationToken cancellation)
        {
            _logger.LogInfo("Started quering in database for get AllPatient");
            var query = await _repos.GetAllPatients(request.Parametr);
            return query;
        }
    }
}
