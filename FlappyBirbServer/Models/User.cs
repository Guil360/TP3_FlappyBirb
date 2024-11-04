namespace FlappyBirbServer.Models;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual List<Score> Scores { get; set; } = null!; 

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User() { }
    }
