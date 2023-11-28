using Ambulance_API_CQRS.Domain.Entities;
using MediatR;
namespace Ambulance_API_CQRS.Application.Patients.Command.CreatePatient
{
    public class CreatePatientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime BirthYear { get; set; }
        public int CallingAmbulanceId { get; set; } 
    }
}
