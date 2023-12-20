

namespace Ambulance_API_CQRS.Application.Patients.Queries.GetAllPatient
{
    public class GetAllPatientVm
    {
        public IEnumerable<GetAllPatientDto> AllPatients { get; set; }
    }
}
