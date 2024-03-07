using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using AutoMapper;
using MediatR;


namespace Ambulance_API_CQRS.Application.Depart.Query
{
    public class DepartIdQueryHandler : IRequestHandler<DepartIdQuery, DepartDetailDto>
    {
        private readonly IDepartRepository _departRepositoy;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DepartIdQueryHandler(IDepartRepository departRepository, ILoggerManager logger, IMapper mapper)
            => (_departRepositoy, _logger, _mapper) = (departRepository, logger, mapper);

        public async Task<DepartDetailDto> Handle (DepartIdQuery query, CancellationToken cancellation)
        {
            _logger.LogInfo("starting process date access Depart");
            var queryDetailsDepart = await _departRepositoy.GetDepartId(query.Id);

            var mappDetails = _mapper.Map<DepartDetailDto>(queryDetailsDepart);
            _logger.LogError($"Automapper missing type map configuration or unsupported mapping {nameof(DepartIdQueryHandler)}");

            return mappDetails;   
        }
    }
}
