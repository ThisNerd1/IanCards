using Microsoft.EntityFrameworkCore;
using VideoGameLibrary_PartOne.Models;
using VideoGameLibrary7._0.Areas.Identity.Data;

namespace VideoGameLibrary7._0.Data
{
    public class GameContext : DbContext
    {

        public GameContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameUser> AspNetUsers { get; set; }
    }
}
