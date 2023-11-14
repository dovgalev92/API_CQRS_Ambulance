using Ambulance_API_CQRS.Domain.Entities.Base;

namespace Ambulance_API_CQRS.Domain.Entities
{
    public class Locality : BaseEntity
    {
        public string NameLocality { get; set; } = string.Empty;

        //связи
        public ICollection<Patient>? Patients { get; set; }
        public ICollection<Street>? Streets { get; set; }
    }
}
