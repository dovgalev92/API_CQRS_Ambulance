using Ambulance_API_CQRS.Application.AuthImplementation;
using Ambulance_API_CQRS.Application.Common.Behavior;
using Ambulance_API_CQRS.Application.Common.Interfaces.IAuthentication;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ambulance_API_CQRS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationServices>();
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly));
            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly()});
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
