using System.ComponentModel.DataAnnotations;

namespace APIsJWTAuthentication.Models
{
    public class RegisterModel
    {
        [Required, MaxLength(100)]
        public required string FirstName { get; set; }

        [Required, MaxLength(100)]
        public required string LastName { get; set; }

        [Required, MaxLength(50)]
        public required string Username { get; set; }

        [Required, MaxLength(128)]
        public required string Email { get; set; }

        [Required, MaxLength(256)]
        public required string Password { get; set; }
    }
}
