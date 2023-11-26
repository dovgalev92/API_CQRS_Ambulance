using Ambulance_API_CQRS.Domain.Entities;
using System.Linq.Expressions;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository
{
    public interface IPatientRepos
    {
        Task<int> CreatePatient(Patient patient);
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int patientid);
    }
}
