using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


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

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
           return  await _application.Patients.AsNoTracking().ToListAsync();
        }


        public async Task<Patient> GetPatientById(int patientid)
        {
            return await _application.Patients.Include(c => c.CallingAmbulance)
                .FirstOrDefaultAsync(x => x.Id == patientid);
        }
    }
}
