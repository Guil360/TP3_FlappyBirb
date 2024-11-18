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

            // Seed scores
            modelBuilder.Entity<Score>().HasData(
                new Score
                {
                    Id = 1,
                    ScoreValue = 100,
                    IsPublic = false,
                    Pseudo = "admin",
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    TimeInSeconds = "10",
                    UserId = user.Id
                },

                new Score
                {
                    Id = 2,
                    ScoreValue = 200,
                    IsPublic = true,
                    Pseudo = "user",
                    Date = DateTime.Now.ToString("yyyy-MM-dd"),
                    TimeInSeconds = "20",
                    UserId = user2.Id
                },
                    new Score
                    {
                        Id = 3,
                        ScoreValue = 150,
                        IsPublic = true,
                        Pseudo = "player1",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "15",
                        UserId = user.Id
                    },

                    new Score
                    {
                        Id = 4,
                        ScoreValue = 250,
                        IsPublic = false,
                        Pseudo = "player2",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "25",
                        UserId = user2.Id
                    },

                    new Score
                    {
                        Id = 5,
                        ScoreValue = 300,
                        IsPublic = true,
                        Pseudo = "player3",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "30",
                        UserId = user.Id
                    },

                    new Score
                    {
                        Id = 6,
                        ScoreValue = 350,
                        IsPublic = false,
                        Pseudo = "player4",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "35",
                        UserId = user2.Id
                    },

                    new Score
                    {
                        Id = 7,
                        ScoreValue = 400,
                        IsPublic = true,
                        Pseudo = "player5",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "40",
                        UserId = user.Id
                    },

                    new Score
                    {
                        Id = 8,
                        ScoreValue = 450,
                        IsPublic = false,
                        Pseudo = "player6",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "45",
                        UserId = user2.Id
                    },

                    new Score
                    {
                        Id = 9,
                        ScoreValue = 500,
                        IsPublic = true,
                        Pseudo = "player7",
                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                        TimeInSeconds = "50",
                        UserId = user.Id
                    }





            );
        }

        
        public DbSet<FlappyBirbServer.Models.Score> Score { get; set; } = default!;
    }
}
