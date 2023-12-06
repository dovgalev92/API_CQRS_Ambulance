
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public record CreateCallingCommand : IRequest
    {
        public string NameOfCAllAmbulance { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCall { get; set; }
        public TimeSpan TimeCall { get; set; }
        public string CauseCall { get; set; }
        public string? RedirectCall { get; set; }
        public int PatientId { get; set; }
    }
}
