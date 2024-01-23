using AutoMapper;
using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsDto : IMapping<Patient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameOfCAllAmbulance { get; set; }
        /// <summary>
        /// дата вызова
        /// </summary>
        public string DateCall { get; set; }
        /// <summary>
        /// Время вызова
        /// </summary>
        public string TimeCall { get; set; }
        /// <summary>
        /// Причина вызова
        /// </summary>
        public string CauseCall { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<Patient, GetPatientDetailsDto>()
            .ForMember(dto => dto.NameOfCAllAmbulance,
                map => map.MapFrom(p => string.Join(",", p.CallingAmbulance.OrderBy(x => x.PatientId == p.Id)
                    .Select(name => name.NameOfCAllAmbulance))))
            .ForMember(dto => dto.CauseCall, map => map.MapFrom(x => string.Join(",", x.CallingAmbulance.OrderBy(i => i.PatientId == x.Id)
                .Select(cause => cause.CauseCall))))
            .ForMember(dto => dto.DateCall, map => map.MapFrom(d => string.Join(",", d.CallingAmbulance.OrderBy(i => i.PatientId == d.Id)
                .Select(d => d.DateCall.ToString("D")))))
            .ForMember(dto => dto.TimeCall, map => map.MapFrom(d => string.Join(",", d.CallingAmbulance.OrderBy(i => i.PatientId == d.Id)
                .Select(t => t.TimeCall))));

    }
}
