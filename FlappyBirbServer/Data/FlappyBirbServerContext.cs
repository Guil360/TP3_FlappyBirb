using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FlappyBirbServer.Data
{
    public class FlappyBirbServerContext : IdentityDbContext<User>
    {
        public FlappyBirbServerContext(DbContextOptions<FlappyBirbServerContext> options)
            : base(options)
        {
        }

        public DbSet<FlappyBirbServer.Models.User> User { get; set; } = default!;
        public DbSet<FlappyBirbServer.Models.Score> Score { get; set; } = default!;


        //Creation du seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            User user = new User
            {
                Id = "1",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "user1@email.com",
                NormalizedEmail = "USER1@EMAIL.COM",
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "admin");

            User user2 = new User
            {
                Id = "2",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user2@email.com",
                NormalizedEmail = "USER2@EMAIL.COM",
            };

            user2.PasswordHash = passwordHasher.HashPassword(user2, "user");

            modelBuilder.Entity<User>().HasData(user, user2);

            //On ajoute les scores

            modelBuilder.Entity<Score>().HasData(
                new Score
                {
                    Id = 1,
                    Amount = 10,
                    ScoreOwner = user,
                    Visible = false,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 2,
                    Amount = 20,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                //Score privé
                new Score
                {
                    Id = 3,
                    Amount = 30,
                    ScoreOwner = user,
                    Visible = false,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 4,
                    Amount = 40,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 5,
                    Amount = 50,
                    ScoreOwner = user,
                    Visible = false,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 6,
                    Amount = 60,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 7,
                    Amount = 70,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 8,
                    Amount = 80,
                    ScoreOwner = user,
                    Visible = false,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 9,
                    Amount = 90,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 10,
                    Amount = 100,
                    ScoreOwner = user,
                    Visible = true,
                    Username = "admin",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 11,
                    Amount = 10,
                    ScoreOwner = user2,
                    Visible = true,
                    Username = "user",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 12,
                    Amount = 20,
                    ScoreOwner = user2,
                    Visible = false,
                    Username = "user",
                    Date = DateTime.Now
                },
                new Score
                {
                    Id = 13,
                    Amount = 30,
                    ScoreOwner = user2,
                    Visible = true,
                    Username = "user",
                    Date = DateTime.Now
                }
            );
        }
    }
}
