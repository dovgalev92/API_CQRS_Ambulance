using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Application.Calling.Command.CreateCalling;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Ambulance_API_CQRS.Domain.Entities;

namespace Ambulance_API_CQRS.Models.DTO
{
    public class CreateCallingDto : IMapping<CreateCallingCommand>
    {
        public string NameOfCAllAmbulance { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCall { get; set; }
        public TimeSpan TimeCall { get; set; }
        public string CauseCall { get; set; }
        public string? RedirectCall { get; set; }
        public int? PatientId { get; set; }


        public void Mapping(Profile profile)
            => profile.CreateMap<CreateCallingDto, CreateCallingCommand>();
         
    }
}
