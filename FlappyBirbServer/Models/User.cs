namespace FlappyBirbServer.Models;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser
    {
        public virtual List<Score> Scores { get; set; } = null!;

        public User() { }
    }
