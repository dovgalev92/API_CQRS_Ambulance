using MediatR;

namespace Ambulance_API_CQRS.Application.Depart.Command.EditDepart
{
    public  class EditDepartCommand : IRequest<Unit>
    {
        public int DepartId { get; set; }
        public TimeSpan StartPatient { get; set; }
        public TimeSpan EndTimePatient { get; set; }
    }
}
