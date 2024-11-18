using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FlappyBirbServer.Models
{
    public class Score
    {
        public int Id { get; set; }

        // Pour le pseudo
        public string? Pseudo { get; set; }

        // Date du score
        [Required(ErrorMessage = "Date requise")]
        [DataType(DataType.Date)]
        public string? Date { get; set; }

        // This would be the amount in seconds
        [Required(ErrorMessage = "Nombre de temps requis")]
        public string TimeInSeconds { get; set; }

        // Valeur du score
        [Required(ErrorMessage = "Valeur du score requise")]
        public int ScoreValue { get; set; }

        [Required(ErrorMessage = "Visibilité requise")]
        public bool IsPublic { get; set; }

        [JsonIgnore]
        public virtual User? ScoreOwner { get; set; }

        public string? UserId { get; set; }
    }
}