using FluentValidation;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingValidator : AbstractValidator<CreateCallingCommand>
    {
        public CreateCallingValidator()
        {
            RuleFor(create => create.PatientId).NotNull();
            RuleFor(c => c.CauseCall).NotEmpty();
        }
    }
}
