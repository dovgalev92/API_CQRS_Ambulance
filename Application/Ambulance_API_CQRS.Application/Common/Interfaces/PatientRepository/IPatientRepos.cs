using Ambulance_API_CQRS.Application.Patients;
using Ambulance_API_CQRS.Application.Patients.Queries;
using Ambulance_API_CQRS.Domain.Entities;
using System.Linq.Expressions;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository
{
    public interface IPatientRepos
    {
        Task<int> CreatePatient(Patient patient);
        Task<PagedList<Patient>> GetAllPatients(PatientParametr patientParametr);
        Task<Patient> GetPatientById(int patientid);
        Task<IEnumerable<Patient>> Get(Expression<Func<Patient, bool>> filter);
        IQueryable<Patient> FindAll();

    }
}
