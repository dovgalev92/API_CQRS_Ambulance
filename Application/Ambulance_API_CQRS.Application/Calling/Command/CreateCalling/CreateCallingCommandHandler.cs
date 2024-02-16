using Ambulance_API_CQRS.Application.Common.Exceptions;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;


namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingCommandHandler : IRequestHandler<CreateCallingCommand, int>
    {
        private readonly IApplicationDb _application;
        private readonly ICallingRepository _repository;
        private readonly ILoggerManager _logger;
        public CreateCallingCommandHandler(IApplicationDb application, ICallingRepository repository, ILoggerManager logger)
        {
            _application = application;
            _repository = repository;
            _logger = logger;
        }

        public async Task<int>Handle(CreateCallingCommand request, CancellationToken cancellationToken)
        {
            
            var calling = new CallingAmbulance
            {
                NameOfCAllAmbulance = request.NameOfCAllAmbulance,
                DateCall = DateTime.Now.Date,
                TimeCall = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                CauseCall = request.CauseCall,
                Priority = request.Priority,
                RedirectCall = request.RedirectCall,
                PatientId = request.PatientId
            };
            await _repository.CreateCalling(request.PatientId, calling);
            try
            {
                await _application.SaveChangesAsync(cancellationToken);
                _logger.LogInfo("SaveChanges createCalling");
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error SaveChanges in the {nameof(CreateCallingCommandHandler)} service method {ex}");
            }
            return calling.Id;
        }
    }
}
