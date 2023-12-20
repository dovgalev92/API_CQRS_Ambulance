using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientDto : IMapping<Patient>
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime BithYear { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<Patient, GetAllPatientDto>();
    }
}
