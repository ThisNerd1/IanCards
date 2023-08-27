using VideoGameLibrary_PartOne.Models;


namespace VideoGameLibrary_PartOne.Interfaces

{
    public interface IDataAccessLayer
    {
        public IEnumerable<Game> GetGames();
        public IEnumerable<Game> Search(string strSearch);
        public IEnumerable<Game> Filter(string platform, string esrb, string genre);
        void AddGame(Game game);

        void DeleteGame(int? id);

        Game GetGame(int? id);

        void ReturnGame(int? id);

        void Loan(int? id, string LoanTo);
        void UpdateGame(Game game);
    }
}
