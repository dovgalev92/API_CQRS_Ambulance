using FluentValidation;

namespace Ambulance_API_CQRS.Application.Patients.Command.CreatePatient
{
    public class CreatePatientCommandValidation : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientCommandValidation()
        {
            RuleFor(name => name.Name).NotEmpty();
            RuleFor(family => family).NotEmpty();
        }
    }
}
