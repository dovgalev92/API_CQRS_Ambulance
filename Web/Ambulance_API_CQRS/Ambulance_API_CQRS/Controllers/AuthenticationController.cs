using Ambulance_API_CQRS.Application.Common.Interfaces.IAuthentication;
using Ambulance_API_CQRS.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Ambulance_API_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService) => _authenticationService = authenticationService;
        
        [HttpPost]
        public async Task<IActionResult> RegistrationUser([FromBody] AuthorizationUserDto authorization)
        {
            var authorize = await _authenticationService.RegisterUser(authorization);
            if(!authorize.Succeeded)
            {
                foreach(var error in authorize.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
        [HttpPost("authenticationUser")]
        public async Task<IActionResult> AuthenticationUser([FromBody] AuthenticationDto authentication)
        {
            if(!await _authenticationService.ValidateUser(authentication))
                return Unauthorized();
            return Ok( new {Token = await _authenticationService.CreateToken() });
        }
    }
}
