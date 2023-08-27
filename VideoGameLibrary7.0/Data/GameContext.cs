using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary_PartOne.Models;

namespace VideoGameLibrary_PartOne.Data
{
    public class GameContext : DbContext
    {

        public GameContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
