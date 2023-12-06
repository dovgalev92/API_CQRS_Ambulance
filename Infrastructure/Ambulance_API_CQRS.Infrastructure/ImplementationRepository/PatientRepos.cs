using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Domain.Entities;


namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class PatientRepos : IPatientRepos
    {
        private readonly IApplicationDb _application;
        public PatientRepos(IApplicationDb application)
        {
            _application = application;
        }

        public async Task<int> CreatePatient(Patient patient)
        {
            
            await _application.Patients.AddAsync(patient);
            return patient.Id;
        }

        public Task<IEnumerable<Patient>> GetAllPatients()
        {
            throw new NotImplementedException();
        }


        public Task<Patient> GetPatientById(int patientid)
        {
            throw new NotImplementedException();
        }
    }
}
