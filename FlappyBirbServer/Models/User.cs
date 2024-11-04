namespace FlappyBirbServer.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public Score[] Scores { get; set; } = null!; 

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User() { }
    }
}