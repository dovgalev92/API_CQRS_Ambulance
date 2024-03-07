using FluentValidation;

namespace Ambulance_API_CQRS.Application.Depart.Command
{
    public class CreateDepartValidation : AbstractValidator<CreateDepartCommand>
    {
       public CreateDepartValidation() 
       {
            RuleFor(callingId => callingId.CallingAmbulanceId).NotNull().NotEmpty();
       }
    }
}
