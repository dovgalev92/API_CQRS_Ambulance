using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingCommandHandler : IRequestHandler<CreateCallingCommand, int>
    {
        private readonly IApplicationDb _application;
        private readonly ICallingRepository _repository;
        public CreateCallingCommandHandler(IApplicationDb application, ICallingRepository repository)
        {
            _application = application;
            _repository = repository;
        }

        public async Task<int> Handle(CreateCallingCommand request, CancellationToken cancellationToken)
        {
            var newCalling = new CallingAmbulance
            {
                NameOfCAllAmbulance = request.NameOfCAllAmbulance,
                DateCall = DateTime.Now.Date,
                TimeCall = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                CauseCall = request.CauseCall,
                RedirectCall = request.RedirectCall
            };
            await _repository.CreateCalling(newCalling);
            await _application.SaveChangesAsync(cancellationToken);
            return newCalling.Id;
        }
    }
}
