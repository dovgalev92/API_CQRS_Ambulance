using Ambulance_API_CQRS.Domain.Entities.Base;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingCommand : BaseEntity, IRequest<int>
    {
        public string NameOfCAllAmbulance { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCall { get; set; }
        public TimeSpan TimeCall { get; set; }
        public string CauseCall { get; set; }
        public string? RedirectCall { get; set; }
    }
}
