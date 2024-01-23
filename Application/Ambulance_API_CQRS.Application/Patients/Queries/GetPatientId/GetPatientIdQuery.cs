using MediatR;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientId
{
    public class GetPatientIdQuery : IRequest<GetPatientIdDto>
    {
        public int Id { get; set; }
    }
}
