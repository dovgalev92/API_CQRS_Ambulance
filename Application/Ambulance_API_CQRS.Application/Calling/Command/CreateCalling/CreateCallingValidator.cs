using FluentValidation;

namespace Ambulance_API_CQRS.Application.Calling.Command.CreateCalling
{
    public class CreateCallingValidator : AbstractValidator<CreateCallingCommand>
    {
        public CreateCallingValidator()
        {
            RuleFor(create => create.PatientId).NotNull();
            RuleFor(create => create.NameOfCAllAmbulance).NotEmpty().MinimumLength(5).MaximumLength(45);
        }
    }
}
