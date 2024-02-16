using Ambulance_API_CQRS.Application.Patients;
using Ambulance_API_CQRS.Application.Patients.Queries;
using Ambulance_API_CQRS.Domain.Entities;




namespace Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository
{
    public interface IPatientRepos
    {
        Task<int> CreatePatient(Patient patient);
        Task<PagedList<Patient>> GetAllPatients(PatientParametr patientParametr);
        Task<Patient> GetPatientById(int patientid);
        IQueryable<Patient> FindAll();
        Task UpdatePatient(Patient patient);

    }
}
