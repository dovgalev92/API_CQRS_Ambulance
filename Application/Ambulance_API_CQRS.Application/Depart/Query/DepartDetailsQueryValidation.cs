using FluentValidation;

namespace Ambulance_API_CQRS.Application.Depart.Query
{
    public class DepartDetailsQueryValidation : AbstractValidator<DepartIdQuery>
    {
        public DepartDetailsQueryValidation()
        {
            RuleFor(id => id.Id).NotEmpty();
        }
    }
}
