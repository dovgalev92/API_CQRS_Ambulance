using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Application.Patients;
using Ambulance_API_CQRS.Application.Patients.Queries;
using Ambulance_API_CQRS.Domain.Entities;
using Ambulance_API_CQRS.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Infrastructure.ImplementationRepository
{
    public class PatientRepos : IPatientRepos
    {
        private readonly IApplicationDb _application;
        private readonly ApplicationDbContext context;
        public PatientRepos(IApplicationDb application)
        {
            _application = application;
        }
        public async Task<int> CreatePatient(Patient patient)
        {
            await _application.Patients.AddAsync(patient);
            return patient.Id;
        }
        public IQueryable<Patient> FindAll()
        {
            IQueryable<Patient> patients = _application.Patients.AsQueryable().AsNoTracking();
            return patients;
        }
        public async Task<PagedList<Patient>> GetAllPatients(PatientParametr patientParametr)
        {
            var patient = FindAll();

            if (!patient.Any() || string.IsNullOrWhiteSpace(patientParametr.FamilyName) || string.IsNullOrWhiteSpace(patientParametr.Name) 
                || string.IsNullOrWhiteSpace(patientParametr.Patronymic))
            {
                return await PagedList<Patient>.ToPagedList(patient, patientParametr.PageNumber, patientParametr.PageSize);
            }

            var sortPatient = patient.AsNoTracking().Where(x => x.FamilyName.Contains(patientParametr.FamilyName)
            && x.Name.Contains(patientParametr.Name) && x.Patronymic.Contains(patientParametr.Patronymic)).AsNoTracking();

            return await PagedList<Patient>.ToPagedList(sortPatient, patientParametr.PageNumber, patientParametr.PageSize);
        }
        public async Task<Patient> GetPatientById(int patientid)
        {
            return await _application.Patients.AsNoTracking().Include(c => c.CallingAmbulance)
                .FirstOrDefaultAsync(x => x.Id == patientid);
        }
        public  async Task UpdatePatient(Patient patient)
        {
            _application.Patients.Update(patient);
        }
    }
}
