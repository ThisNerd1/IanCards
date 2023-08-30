using VideoGameLibrary_PartOne.Models;
using VideoGameLibrary7._0.Areas.Identity.Data;

namespace VideoGameLibrary7._0.Interfaces

{
    public interface IDataAccessLayer
    {
        public IEnumerable<Game> GetGames();
        public IEnumerable<Game> Search(string strSearch);
        public IEnumerable<Game> Filter(string platform, string esrb, string genre);
        public IEnumerable<Game> GetUserGames(string userId);
        void AddGame(Game game);

        void DeleteGame(int? id);

        Game GetGame(int? id);

        GameUser GetUser(string userId);

        void ReturnGame(int? id);

        void Loan(int? id, string LoanTo);

        void UpdateGame(Game game);
    }
}
