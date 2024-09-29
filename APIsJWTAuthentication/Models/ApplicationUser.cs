using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace APIsJWTAuthentication.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, MaxLength(100)]
        public required string FirstName { get; set; }

        [Required, MaxLength(100)]
        public required string LastName { get; set; }
    }
}
