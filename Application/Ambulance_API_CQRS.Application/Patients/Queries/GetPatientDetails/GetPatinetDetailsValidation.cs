using FluentValidation;

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetPatientDetails
{
    public class GetPatinetDetailsValidation : AbstractValidator<GetPatientDetailsQuery>
    {
        public GetPatinetDetailsValidation()
        {
            RuleFor(id => id.Id).NotNull();
        }
    }
}
