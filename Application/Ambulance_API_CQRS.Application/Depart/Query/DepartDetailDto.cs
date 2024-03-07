using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Domain.Entities;
using AutoMapper;

namespace Ambulance_API_CQRS.Application.Depart.Query
{
    public class DepartDetailDto : IMapping<AmbulanceDepart>
    {
        /// <summary>
        /// номер бригады скорой
        /// </summary>
        public int NumberAccident_AssistantSquad { get; set; }
        /// <summary>
        /// дата выезда скорой
        /// </summary>
        public DateTime? DateDepart { get; set; }
        /// <summary>
        /// время выезда скорой
        /// </summary>
        public TimeSpan? TimeDepart { get; set; }
        /// <summary>
        /// время прибытия к пациенту
        /// </summary>
        public TimeSpan? StartPatient { get; set; }
        /// <summary>
        /// время убытия 
        /// </summary>
        public TimeSpan? EndTimePatient { get; set; }
        /// <summary>
        /// учреждения доставки 
        /// </summary>
        public string NameHospital { get; set; }
        public string ResultDepart { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<AmbulanceDepart, DepartDetailDto>();
    }
}
