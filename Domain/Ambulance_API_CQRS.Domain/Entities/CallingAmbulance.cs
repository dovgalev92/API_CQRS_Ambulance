﻿using Ambulance_API_CQRS.Domain.Entities.Base;

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
        /// время вызова
        /// </summary>
        public TimeSpan TimeCall { get; set; }
        /// <summary>
        /// причина вызова
        /// </summary>
        public string CauseCall { get; set; }
        /// <summary>
        /// переадресация вызова в другую организацию 
        /// </summary>
        public string? RedirectCall { get; set; }

        //связи
        public Patient Patient { get; set; }
        public AmbulanceDepart Departure { get; set; }
    }
}
