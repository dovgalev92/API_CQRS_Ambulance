using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.DepartRepos;
using MediatR;
using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;


namespace Ambulance_API_CQRS.Application.Depart.Command
{
    public class CreateDepartCommandHandler : IRequestHandler<CreateDepartCommand>
    {
        private readonly IApplicationDb _application;
        private readonly IDepartRepository _repository;
        private readonly ILoggerManager _logger;
        public CreateDepartCommandHandler(IApplicationDb application, IDepartRepository repository, ILoggerManager logger) 
            => (_application, _repository, _logger) = (application, repository, logger);
        
        public async Task Handle(CreateDepartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.CreateDepart(request.CallingAmbulanceId, new AmbulanceDepart
                {
                    NumberAccident_AssistantSquad = request.NumberAccident_AssistantSquad,
                    DateDepart = DateTime.Now.Date,
                    TimeDepart = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                    NameHospital = request.NameHospital,
                    ResultDepart = request.ResultDepart,
                    CallingAmbulanceId = request.CallingAmbulanceId
                });
                await _application.SaveChangesAsync(cancellationToken);
                _logger.LogInfo($"SaveChanges depart {request.CallingAmbulanceId}");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"something went wrong in the {nameof(CreateDepartCommandHandler)} service method {ex}");
            }
        }
    }
}
