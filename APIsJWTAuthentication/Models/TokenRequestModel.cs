using System.ComponentModel.DataAnnotations;

namespace APIsJWTAuthentication.Models
{
    public class TokenRequestModel
    {
        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
