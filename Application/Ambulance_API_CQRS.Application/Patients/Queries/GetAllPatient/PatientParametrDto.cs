using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using AutoMapper;


namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class PatientParametrDto : IMapping<PatientParametr>
    {
        public PatientParametrDto()
        {
            PageNumber = 1;
            PageSize = 10;
        }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string? Name { get; set; }
        public string? FamilyName { get; set; }
        public string? Patronymic { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<PatientParametr, PatientParametrDto>().ReverseMap();
    }
}
