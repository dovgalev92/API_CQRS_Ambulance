using Ambulance_API_CQRS.Application.Common.Interfaces;
using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
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
        private readonly ILoggerManager _logger;
        public CreatePAtientCommandHandler(IPatientRepos repos, IApplicationDb application, ILoggerManager logger) 
            => (_repos, _application, _logger) = (repos, application, logger);

        public async Task<int> Handle(CreatePatientCommand request, CancellationToken cancellation)
        {
            var patient = new Patient
            {
                FamilyName = request.FamilyName,
                Name = request.Name,
                Patronymic = request.Patronymic,
                Age = request.Age,
                BirthYear = request.BirthYear 
            };

            try
            {
                await _repos.CreatePatient(patient);
                await _application.SaveChangesAsync(cancellation);
                _logger.LogInfo("Patient create");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(CreatePAtientCommandHandler)} service method {ex}");
            }
            return patient.Id;
        }
    }
}
