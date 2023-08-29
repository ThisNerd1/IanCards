namespace VideoGameLibrary7._0.Data
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
