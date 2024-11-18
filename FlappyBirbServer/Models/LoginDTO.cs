using System.ComponentModel.DataAnnotations;

namespace FlappyBirbServer.Models
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ce champ est requis!")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Ce champ est requis!")]
        public string Password { get; set; } = null!;
    }
}
