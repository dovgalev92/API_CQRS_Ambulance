using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;

namespace Ambulance_API_CQRS.Application.Depart.Command.EditDepart
{
   public class EditDepartDto : IMapping<AmbulanceDepart>
   {
        public TimeSpan StartPatient { get; set; } 
        public TimeSpan EndTimePatient { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<EditDepartDto, AmbulanceDepart>();
   }
}
