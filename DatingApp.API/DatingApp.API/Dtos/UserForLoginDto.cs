using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForLoginDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 10 characters")]
        public string Password { get; set; }
    }
}
