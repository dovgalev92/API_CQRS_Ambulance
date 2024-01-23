

namespace Ambulance_API_CQRS.Application.Patients
{
    public class PatientParametr : PageFilterPatient
    {
        public string? Name { get; set; }
        public string? FamilyName { get; set; }
        public string? Patronymic { get; set; }

    }
}
