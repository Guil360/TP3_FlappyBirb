namespace FlappyBirbServer.Models
{
    public class Score
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public virtual User? ScoreOwner { get; set; }

        public bool Visible { get; set; }

        public Score(int id, int amount, User scoreOwner, bool visible) 
        {
            Id = id;
            Amount = amount;
            ScoreOwner = scoreOwner;
            Visible = visible;
        }

        public Score() { }
    }
}