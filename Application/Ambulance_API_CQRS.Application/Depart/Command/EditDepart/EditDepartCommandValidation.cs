using FluentValidation;

namespace Ambulance_API_CQRS.Application.Depart.Command.EditDepart
{
    public class EditDepartCommandValidation : AbstractValidator<EditDepartCommand>
    {
        public EditDepartCommandValidation()
        {
            RuleFor(edTime => edTime.EndTimePatient).NotEmpty();
            RuleFor(startTime => startTime.StartPatient).NotEmpty();
            RuleFor(id => id.DepartId).NotEmpty();
        }
    }
}
