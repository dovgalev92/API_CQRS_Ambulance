using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingCommandHandler : IRequestHandler<CreateCallingCommand>
    {
        private readonly IApplicationDb _application;
        private readonly ICallingRepository _repository;
        public CreateCallingCommandHandler(IApplicationDb application, ICallingRepository repository)
        {
            _application = application;
            _repository = repository;
        }

        public async Task Handle(CreateCallingCommand request, CancellationToken cancellationToken)
        {
            var queryId = await _application.Patients
                .FirstOrDefaultAsync(x => x.Id == request.PatientId) != null ? request.PatientId 
                : throw new ArgumentNullException(nameof(request.PatientId));

            var newCalling = new CallingAmbulance
            {
                NameOfCAllAmbulance = request.NameOfCAllAmbulance,
                DateCall = DateTime.Now.Date,
                TimeCall = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
                CauseCall = request.CauseCall,
                RedirectCall = request.RedirectCall,
                PatientId = queryId
                
            };
            await _repository.CreateCalling(newCalling);
            await _application.SaveChangesAsync(cancellationToken);
        }
    }
}
