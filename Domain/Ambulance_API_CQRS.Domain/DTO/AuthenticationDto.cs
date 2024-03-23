using System.ComponentModel.DataAnnotations;

namespace Ambulance_API_CQRS.Domain.DTO
{
    public class AuthenticationDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string NameUser { get; init;}
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; init;}
    }
}
