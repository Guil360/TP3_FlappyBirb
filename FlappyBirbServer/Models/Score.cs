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

        public int UserId { get; set; }

        // Date du score
        [Required(ErrorMessage = "Date requise")]
        public DateTime Date { get; set; }

        public Score(int id, int amount, User scoreOwner, bool visible, string username, int userId, DateTime date)
        {
            Id = id;
            Amount = amount;
            ScoreOwner = scoreOwner ?? throw new ArgumentNullException(nameof(scoreOwner), "ScoreOwner cannot be null.");
            Visible = visible;
            Username = username;
            UserId = userId;
            Date = date;
        }

        public Score() { }
    }
}