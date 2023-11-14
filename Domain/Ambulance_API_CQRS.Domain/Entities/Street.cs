using Ambulance_API_CQRS.Domain.Entities.Base;

namespace Ambulance_API_CQRS.Domain.Entities
{
    public class Street : BaseEntity
    {
        /// <summary>
        /// название улицы
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// номер дома
        /// </summary>
        public string NumberHouse { get; set; } = string.Empty;
        /// <summary>
        /// номер подъезда
        /// </summary>
        public string? NumberEntranceOfHouse { get; set; } = string.Empty;
        /// <summary>
        /// номер квартиры
        /// </summary>
        public string? NumberFlat { get; set; } = string.Empty;

        // связи

        public ICollection<Patient>? Patients { get; set; }
        public Locality? Locality { get; set; }
        public int LocalityId { get; set; }
    }
}
