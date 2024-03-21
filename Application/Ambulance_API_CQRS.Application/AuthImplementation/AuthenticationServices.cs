using Ambulance_API_CQRS.Application.Common.Interfaces.IAuthentication;
using Ambulance_API_CQRS.Application.Common.Interfaces.ILogger;
using Ambulance_API_CQRS.Domain.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ambulance_API_CQRS.Application.AuthImplementation
{
    public class AuthenticationServices : IAuthenticationService
    {
        private readonly ILoggerManager _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        private IdentityUser? _user;
        public AuthenticationServices(ILoggerManager logger, UserManager<IdentityUser> userManager, IConfiguration configuration)
            => (_logger, _userManager, _configuration) = (logger, userManager, configuration);
       

        public async Task<string> CreateToken()
        {
            var signingCredential = GetSigningCredentials();
            var claims = await GetClaim();
            var tokenOptions = GenerateTokenOptions(signingCredential, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        }

        public async Task<IdentityResult> RegisterUser(AuthorizationUserDto authorization)
        {
            var user = new IdentityUser()
            {
                UserName = authorization.Name,
                PasswordHash = authorization.Password,
                Email = authorization.Email
            };

            var result = await _userManager.CreateAsync(user, user.PasswordHash);
            if(result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, authorization.Roles);
            }
            return result;
        }

        public async Task<bool> ValidateUser(AuthenticationDto authentication)
        {
            _user = await _userManager.FindByNameAsync(authentication.NameUser);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, authentication.Password));
            if(!result)
            {
                _logger.LogWarning($"{nameof(ValidateUser)} : Authentication failed. Wrong user or password");
            }
            return result;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtSettings:Key").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaim()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSetting = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
                (
                    issuer: jwtSetting["validIssuer"],
                    audience: jwtSetting["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSetting["expires"])),
                    signingCredentials: signingCredentials
                );
            return tokenOptions;
        }
    }
}
