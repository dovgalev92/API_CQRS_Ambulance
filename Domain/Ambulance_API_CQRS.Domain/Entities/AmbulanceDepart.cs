using Ambulance_API_CQRS.Domain.Entities.Base;

namespace Ambulance_API_CQRS.Domain.Entities
{
    public class AmbulanceDepart : BaseEntity
    {
        /// <summary>
        /// номер бригады скорой
        /// </summary>
        public int NumberAccident_AssistantSquad { get; set; }
        /// <summary>
        /// дата выезда скорой
        /// </summary>
        public DateTime DateDepart { get; set; }
        /// <summary>
        /// время выезда скорой
        /// </summary>
        public TimeSpan TimeDepart { get; set; }
        /// <summary>
        /// время прибытия к пациенту
        /// </summary>
        public TimeSpan StartPatient { get; set; }
        /// <summary>
        /// время убытия 
        /// </summary>
        public TimeSpan EndTimePatient { get; set; }
        /// <summary>
        /// учреждения доставки 
        /// </summary>
        public string NameHospital { get; set; }
        public string Priority { get; set; }
        public string ResultDepart { get; set; }

        // связи
        public CallingAmbulance Calling { get; set; }
        public int CallingAmbulanceId { get; set; }
    }
}
