using Ambulance_API_CQRS.Application.Common.Exceptions;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int>Handle(CreateCallingCommand request, CancellationToken cancellationToken)
        {
            var queryId = await _application.Patients
                .FirstOrDefaultAsync(x => x.Id == request.PatientId) != null ? request.PatientId 
                : throw new NotFoundException(nameof(Patient), request.PatientId);

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
            await _repository.CreateCalling(calling);
          
            await _application.SaveChangesAsync(cancellationToken);
            return calling.Id;
        }
    }
}
