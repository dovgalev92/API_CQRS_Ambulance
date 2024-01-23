using Ambulance_API_CQRS.Domain.Entities;
using MediatR;


namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientsQuery : IRequest<PagedList<Patient>>
    {
        public PatientParametr Parametr { get; set; }
    }
}
