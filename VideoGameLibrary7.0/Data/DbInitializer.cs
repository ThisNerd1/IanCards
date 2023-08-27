using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameLibrary_PartOne.Models;

namespace VideoGameLibrary_PartOne.Data
{
    public class DbInitializer
    {
        public static void Initialize(GameContext context)
        {
            context.Database.EnsureCreated();

            SetupUsers(context);
        }

        public static void SetupUsers(GameContext context)
        {
            if (context.Games.Any())
            {
                return;
            }
        }
    }
}
