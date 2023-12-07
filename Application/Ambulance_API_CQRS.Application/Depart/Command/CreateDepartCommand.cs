using MediatR;

namespace Ambulance_API_CQRS.Application.Depart.Command
{
    public record CreateDepartCommand : IRequest
    {
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
        public int CallingAmbulanceId { get; set; }
    }
}
