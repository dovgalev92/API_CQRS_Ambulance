using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;
using MediatR;

namespace Ambulance_API_CQRS.Application.Depart.Command.EditDepart
{
    public class EditDepartCommandHandler : IRequestHandler<EditDepartCommand, Unit>
    {
        private readonly IDepartRepository _departRepository;
        private readonly IApplicationDb _application;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EditDepartCommandHandler(IDepartRepository departRepository, IApplicationDb application, ILoggerManager logger, IMapper mapper) 
            => (_departRepository, _application, _logger, _mapper)  = (departRepository, application, logger, mapper);
        public async Task<Unit> Handle(EditDepartCommand request, CancellationToken cancellation)
        {
            var dto = new EditDepartDto()
            {
                EndTimePatient = request.EndTimePatient,
                StartPatient = request.StartPatient,
            };
            var mapEdit = _mapper.Map<AmbulanceDepart>(dto);
            _logger.LogError($"Automapper missing type map configuration or unsupported mapping {nameof(EditDepartCommandHandler)}");

            await _departRepository.EditDepat(request.DepartId, mapEdit);
            await _application.SaveChangesAsync(cancellation);
            _logger.LogInfo("Update Depart");
            
            return Unit.Value;
        }
    }
}
