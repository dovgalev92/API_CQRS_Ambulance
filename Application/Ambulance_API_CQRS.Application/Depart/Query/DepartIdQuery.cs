using MediatR;

namespace Ambulance_API_CQRS.Application.Depart.Query
{
    public class DepartIdQuery : IRequest<DepartDetailDto>
    {
      public int Id { get; set; }
    }
}
