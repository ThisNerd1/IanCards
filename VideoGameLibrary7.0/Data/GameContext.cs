using Microsoft.EntityFrameworkCore;
using VideoGameLibrary_PartOne.Models;

namespace VideoGameLibrary7._0.Data
{
    public class GameContext : DbContext
    {

        public GameContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
    }
}
