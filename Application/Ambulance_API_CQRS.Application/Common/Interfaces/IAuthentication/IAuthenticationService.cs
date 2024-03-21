using Microsoft.AspNetCore.Identity;
using Ambulance_API_CQRS.Domain.DTO;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(AuthorizationUserDto authorization);
        Task<bool> ValidateUser(AuthenticationDto authentication);
        Task<string> CreateToken();
    }
}
