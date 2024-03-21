using Ambulance_API_CQRS.Domain.Entities.Base;
using Ambulance_API_CQRS.Domain.Enums;

namespace Ambulance_API_CQRS.Domain.Entities
{
    public class CallingAmbulance : BaseEntity
    {
        /// <summary>
        /// имя, фамилия кто сделал вызов(пациент или сторонний человек)
        /// </summary>
        public string NameOfCAllAmbulance { get; set; }
        /// <summary>
        /// дата вызова
        /// </summary>
        public DateTime DateCall { get; set; }
        /// <summary>
        /// Время вызова
        /// </summary>
        public TimeSpan? TimeCall { get; set; }
        /// <summary>
        /// Причина вызова
        /// </summary>
        public string CauseCall { get; set; }
        /// <summary>
        /// приоритет вызова
        /// </summary>
        public Priority? Priority { get; set; }
        /// <summary>
        /// Переадресация вызова в другую организацию 
        /// </summary>
        public string? RedirectCall { get; set; }

        //связи
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public AmbulanceDepart? Departure { get; set; }
    }
}
