using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameLibrary_PartOne.Interfaces;
using VideoGameLibrary_PartOne.Models;

namespace VideoGameLibrary_PartOne.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        /*public static List<Game> GameList = new List<Game>()
        {
            new Game(1,"Call of Duty®: Black Ops III", "Xbox One, PS4, PS3, PC", "Action-Adventure, First-Person Shooter",
                "Mature", 2015, "https://cdn.cloudflare.steamstatic.com/steam/apps/311210/header.jpg?t=1639696350"),
            new Game(2,"Minecraft", "PC, Xbox One, Xbox Series X|S, PS4, Nintendo Switch, Mobile Phone", "Sandbox, Survival","Everyone 10+", 2011,
                "https://play-lh.googleusercontent.com/yAtZnNL-9Eb5VYSsCaOC7KAsOVIJcY8mpKa0MoF-0HCL6b0OrFcBizURHywpuip-D6Y=w412-h220-rw", "6un5linga", DateTime.Now),
            new Game(3,"Team Fortress 2", "PC, Xbox 360, PS3, Mac OS X, Linux", "First-Person Shooter", "Mature",
                2007, "https://cdn.cloudflare.steamstatic.com/steam/apps/440/header.jpg?t=1592263852"),
            new Game(4,"UNCHARTED™: The Nathan Drake Collection", "PS4", "Action-Adventure, Third-Person Shooter",
                "Teen", 2015, "https://gmedia.playstation.com/is/image/SIEPDC/Uncharted-the-collection-keyart-01-en-16jun21?$native$"),
            new Game(5,"Mario Party Superstars", "Nintendo Switch", "Party", "Everyone", 2021,
                "https://www.comicsunearthed.com/wp-content/uploads/2021/10/MarioPartySuperstars-KeyArt.jpg"),
            new Game(6,"Halo: The Master Chief Collection", "PC, Xbox One, Xbox Series X|S", "First-Person Shooter", "Mature",
                2014, "https://cdn.cloudflare.steamstatic.com/steam/apps/976730/header.jpg?t=1634144453", "ConJonSilv3r", DateTime.Today)
        };*/

        private GameContext db;

        public GameListDAL(GameContext indb)
        {
            this.db = indb;
        }



        public void AddGame(Game game)
        {
            //GameList.Add(game);
            game.Id = 0;
            db.Add(game);
            db.SaveChanges();
        }

        public void DeleteGame(int? id)
        {
            if (id > 0)
            {
                db.Games.Remove(db.Games.Find(id));
                db.SaveChanges();
            }
            /*
            Game foundGame = GetGame(id);
            if (foundGame != null)
            {
                GameList.Remove(foundGame);
            }
            */
        }

        public void Loan(int? id, string LoanTo)
        {
            Game foundGame = GetGame(id);
            if (foundGame != null)
            {
                if (foundGame.LoanStatus == null)
                {
                    foundGame.LoanStatus = LoanTo;
                    foundGame.LoanDate = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public void ReturnGame(int? id)
        {
            Game foundGame = GetGame(id);
            if (foundGame != null)
            {
                if (foundGame.LoanStatus != null)
                {
                    foundGame.LoanStatus = null;
                    foundGame.LoanDate = null;
                    db.SaveChanges();
                }
            }
        }

        public Game GetGame(int? id)
        {
            return db.Games.FirstOrDefault(game => game.Id == id);
            /*
             Game foundGame = null;
            if (id != null)
            {
                GameList.ForEach(i =>
                {
                    if (i.Id == id)
                    {
                        foundGame = i;
                    }
                });
            }
            return foundGame;
            */
        }

        public IEnumerable<Game> GetGames()
        {
            //return GameList;
            db.SaveChanges();
            return db.Games.ToList();
        }


        public IEnumerable<Game> Search(string strSearch)
        {

            List<Game> foundGames = new List<Game>();

            foreach (var game in db.Games)
            {
                if (game.Title.ToUpper().Contains(strSearch.ToUpper()))
                {
                    foundGames.Add(game);
                }
            }
            return foundGames;
        }
        public IEnumerable<Game> Filter(string platform, string esrb, string genre)
        {
            List<Game> foundGames = new List<Game>();
            foreach (var game in db.Games)
            {
                if (game.Platform.ToUpper().Contains(platform.ToUpper()) || platform == "Any Platform")
                {
                    foundGames.Add(game);
                    if (!game.ESRB.ToUpper().Contains(esrb.ToUpper()) && esrb != "Any Rating")
                    {
                        foundGames.Remove(game);
                    }
                    if (!game.Genre.ToUpper().Contains(genre.ToUpper()) && genre != "Any Genre")
                    {
                        foundGames.Remove(game);
                    }
                }
                else if (game.ESRB.ToUpper().Contains(esrb.ToUpper()) || esrb == "Any Rating")
                {
                    foundGames.Add(game);
                    if (!game.Genre.ToUpper().Contains(genre.ToUpper()) && genre != "Any Genre")
                    {
                        foundGames.Remove(game);
                    }
                    if (!game.Platform.ToUpper().Contains(platform.ToUpper()) && platform != "Any Platform")
                    {
                        foundGames.Remove(game);
                    }
                }
                else if (game.Genre.ToUpper().Contains(genre.ToUpper()) || genre == "Any Genre")
                {
                    foundGames.Add(game);
                    if (!game.Platform.ToUpper().Contains(platform.ToUpper()) && platform != "Any Platform")
                    {
                        foundGames.Remove(game);
                    }
                    if (!game.ESRB.ToUpper().Contains(esrb.ToUpper()) && esrb != "Any Rating")
                    {
                        foundGames.Remove(game);
                    }
                }
            }
            return foundGames;
        }

        public void UpdateGame(Game game)
        {
            //DeleteGame(game.Id);
            db.Games.Update(game);
            db.SaveChanges();
        }
    }
}