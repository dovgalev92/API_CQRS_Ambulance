using MediatR;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatientDetailsQuery : IRequest<GetPatientDetailsDto>
    {
        public int Id { get; set; }
    }
}
