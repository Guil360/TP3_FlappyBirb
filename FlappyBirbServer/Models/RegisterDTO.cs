using System.ComponentModel.DataAnnotations;

namespace FlappyBirbServer.Models
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est requis.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [MinLength(6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères.")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "La confirmation du mot de passe est requise.")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = null!;

        [Required(ErrorMessage = "L'adresse email est requise.")]
        [EmailAddress(ErrorMessage = "Veuillez fournir une adresse email valide.")]
        public string Email { get; set; } = null!;
    }
}
