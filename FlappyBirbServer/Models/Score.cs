using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FlappyBirbServer.Models
{
    public class Score
    {
        public int Id { get; set; }

        // Pour le pseudo
        public string? Username { get; set; }

        // This would be the amount in seconds
        [Required(ErrorMessage = "Nombre de temps requis")]
        public int Amount { get; set; }

        [JsonIgnore]
        public virtual User? ScoreOwner { get; set; }

        [Required(ErrorMessage = "Visibilité requise")]
        public bool Visible { get; set; }

        public Score(int id, int amount, User scoreOwner, bool visible, string username)
        {

            Id = id;
            Amount = amount;
            ScoreOwner = scoreOwner ?? throw new ArgumentNullException(nameof(scoreOwner), "ScoreOwner cannot be null.");
            Visible = visible;
            Username = username;
        }

        public Score() { }
    }
}