using Ambulance_API_CQRS.Domain.Entities.Base;


namespace Ambulance_API_CQRS.Domain.Entities
{
    public class Patient : BaseEntity
    {
        /// <summary>
        /// имя пациента
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// фамилия
        /// </summary>
        public string FamilyName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime BirthYear { get; set; }

        // связи
        //public AmbulanceDeparture? Departure { get; set; }
        public CallingAmbulance CallingAmbulance { get; set; }
        public int CallingAmbulanceId { get; set; }
        public Street? Street { get; set; }
        public Nullable<int> StreetId { get; set; }
        public Locality? Locality { get; set; }
        public Nullable<int> LocalityId { get; set; }
    }
}
