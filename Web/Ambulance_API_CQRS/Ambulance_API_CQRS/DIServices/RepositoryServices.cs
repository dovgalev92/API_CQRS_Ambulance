using Ambulance_API_CQRS.Application.Common.Interfaces.CallingAmbual;
using Ambulance_API_CQRS.Application.Common.Interfaces.PatientRepository;
using Ambulance_API_CQRS.Infrastructure.ImplementationRepository;

namespace Ambulance_API_CQRS.Services
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped<ICallingRepository, Callingrepository>();
            services.AddScoped<IPatientRepos, PatientRepos>();

            return services;
        }
    }
}
