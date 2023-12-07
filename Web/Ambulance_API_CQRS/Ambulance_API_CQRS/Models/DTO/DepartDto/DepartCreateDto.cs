using Ambulance_API_CQRS.Application.Common.Interfaces.IMapp;
using Ambulance_API_CQRS.Application.Depart.Command;
using AutoMapper;

namespace Ambulance_API_CQRS.Models.DTO.DepartDto
{
    public class DepartCreateDto : IMapping<CreateDepartCommand>
    {
        /// <summary>
        /// номер бригады скорой
        /// </summary>
        public int NumberAccident_AssistantSquad { get; set; }

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
        public int? CallingAmbulanceId { get; set; }

        public void Mapping(Profile profile)
           => profile.CreateMap<DepartCreateDto, CreateDepartCommand>();
        
    }
}
