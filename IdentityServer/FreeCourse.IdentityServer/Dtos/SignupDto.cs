using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FreeCourse.IdentityServer.Dtos
{
    public class SignupDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string City { get; set; }
        
    }
}