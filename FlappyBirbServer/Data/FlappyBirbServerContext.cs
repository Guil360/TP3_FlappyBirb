using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyBirbServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FlappyBirbServer.Data
{
    public class FlappyBirbServerContext : IdentityDbContext<User>
    {
        public FlappyBirbServerContext (DbContextOptions<FlappyBirbServerContext> options)
            : base(options)
        {
        }

        public DbSet<FlappyBirbServer.Models.User> User { get; set; } = default!;
        public DbSet<FlappyBirbServer.Models.Score> Score { get; set; } = default!;
    }
}
