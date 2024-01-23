
using FluentValidation;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientId
{
    public class GetPatientIdValidations : AbstractValidator<GetPatientIdQuery>
    {
        public GetPatientIdValidations() 
        {
            RuleFor(id => id.Id).NotEmpty();
        }
    }
}
