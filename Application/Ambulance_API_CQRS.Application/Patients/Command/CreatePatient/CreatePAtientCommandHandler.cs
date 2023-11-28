using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ambulance_API_CQRS.Application.Patients.Command.CreatePatient
{
    public class CreatePAtientCommandHandler : IRequestHandler<CreatePatientCommand, int>
    {
        private readonly IPatientRepos _repos;
        private readonly IApplicationDb _application;

        public CreatePAtientCommandHandler(IPatientRepos repos, IApplicationDb application) 
            => (_repos, _application) = (repos, application);

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellation)
        {
            var queryId = await _application.Callings.
                FirstOrDefaultAsync(x => x.Id == request.CallingAmbulanceId) != null ? request.CallingAmbulanceId 
                : throw new ArgumentNullException(nameof(request.CallingAmbulanceId)); 

            var patient = new Patient
            {
                FamilyName = request.FamilyName,
                Name = request.Name,
                Patronymic = request.Patronymic,
                Age = request.Age,
                BirthYear = request.BirthYear,
                CallingAmbulanceId = queryId
            };
            
            await _repos.CreatePatient(patient);
            await _application.SaveChangesAsync(cancellation);
            return patient.Id;
        }
    }
}
