using Ambulance_API_CQRS.Application.Common.Exceptions;
using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class Callingrepository : ICallingRepository
    {
        private readonly IApplicationDb _application;
        public Callingrepository(IApplicationDb application)
        {
            _application = application;
        }
        public async Task<int> CreateCalling(int id, CallingAmbulance create)
        {
            var executeId = await _application.Patients
                .FirstOrDefaultAsync(i => i.Id == id)!= null ? await _application.Callings.AddAsync(create) 
                : throw new NotFoundException(nameof(Patient), id);

            return create.Id;
        }

    }
}
