using System.ComponentModel.DataAnnotations;

namespace kantech2.Controllers
{
    public class UserDetails
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}