using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Application.LoggerImplementation;

namespace Ambulance_API_CQRS.DIServices
{
    public static class LoggerServices
    {
        public static void ConfigureLoggerServices(this IServiceCollection services)
            => services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
