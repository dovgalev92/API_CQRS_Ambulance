using Microsoft.AspNetCore.Identity;

namespace Ambulance_API_CQRS.Application.Common.Interfaces.IAuthentication
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser();
        Task<bool> ValidateUser();
        Task<string> CreateToken();
    }
}
