namespace FlappyBirbServer.Models;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
    {

        public string Name { get; set; } = null!;

        public virtual List<Score> Scores { get; set; } = null!; 

        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public User() { }
    }
