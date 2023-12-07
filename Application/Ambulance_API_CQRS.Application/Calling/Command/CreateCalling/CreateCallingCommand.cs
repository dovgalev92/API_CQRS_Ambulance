
using Ambulance_API_CQRS.Domain.Enums;
using MediatR;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public record CreateCallingCommand : IRequest
    {
        public string NameOfCAllAmbulance { get; set; }
        public string CauseCall { get; set; }
        public Priority Priority { get; set; }
        public string? RedirectCall { get; set; }
        public int PatientId { get; set; }
    }
}
