using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Application.Calling.Command.CreateCalling;
using AutoMapper;
using Ambulance_API_CQRS.Domain.Enums;

namespace Ambulance_API_CQRS.Models.DTO
{
    public class CreateCallingDto : IMapping<CreateCallingCommand>
    {
        public string NameOfCAllAmbulance { get; set; }
        public string CauseCall { get; set; }
        public string? RedirectCall { get; set; }
        public Priority Priority { get; set; }
        public int? PatientId { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<CreateCallingDto, CreateCallingCommand>();
    }
}
