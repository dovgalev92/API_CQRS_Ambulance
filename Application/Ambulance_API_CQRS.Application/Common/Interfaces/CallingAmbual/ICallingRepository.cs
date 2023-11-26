using Ambulance_API_CQRS.Domain.Entities;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual
{
    public interface ICallingRepository
    {
        Task<int> CreateCalling(CallingAmbulance create);
    }
}
