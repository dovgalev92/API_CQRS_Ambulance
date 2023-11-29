using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Application.Patients.Command.CreatePatient;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;

namespace Ambulance_API_CQRS.Models.DTO.PatientDTO
{
    public class CreatePatientDto : IMapping<CreatePatientCommand>
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime BirthYear { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<CreatePatientDto, CreatePatientCommand>();
    }
}
