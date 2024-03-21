using System.ComponentModel.DataAnnotations;

namespace Ambulance_API_CQRS.Domain.DTO
{
    public class AuthorizationUserDto
    {
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "UserName is required")]
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<string>? Roles { get; init; }
    }
}
