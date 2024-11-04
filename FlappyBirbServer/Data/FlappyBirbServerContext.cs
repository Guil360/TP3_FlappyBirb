using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FlappyBirbServer.Models;

namespace FlappyBirbServer.Data
{
    public class FlappyBirbServerContext : DbContext
    {
        public FlappyBirbServerContext (DbContextOptions<FlappyBirbServerContext> options)
            : base(options)
        {
        }

        public DbSet<FlappyBirbServer.Models.User> User { get; set; } = default!;
        public DbSet<FlappyBirbServer.Models.Score> Score { get; set; } = default!;
    }
}
