using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Domain.Entities;

namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class Callingrepository : ICallingRepository
    {
        private readonly IApplicationDb _application;
        public Callingrepository(IApplicationDb application)
        {
            _application = application;
        }
        public async Task<int> CreateCalling(CallingAmbulance create)
        {
            await _application.Callings.AddAsync(create);
            return create.Id;
        }
    }
}
