using Microsoft.AspNetCore.Mvc;
using VideoGameLibrary_PartOne.Models;
using VideoGameLibrary7._0.Interfaces;

namespace VideoGameLibrary7._0.Controllers
{
    public class GameController : Controller
    {
        IDataAccessLayer dal;

        public GameController(IDataAccessLayer indal)
        {
            dal = indal;
        }

        public IActionResult GameLibrary()
        {
            return View("GameLibrary", dal.GetGames());
        }

        [HttpPost]

        public IActionResult LoanTo(int? id)
        {
            dal.Loan(id, Request.Form["LoanToBox"]);
            return View("GameLibrary", dal.GetGames());
        }

        [HttpPost]

        public IActionResult ReturnGame(int? id)
        {
            dal.ReturnGame(id);
            return View("GameLibrary", dal.GetGames());
        }

        [HttpPost]
        public IActionResult AddGame()
        {
            Game game;
            int id = dal.GetGames().Count() + 1;
            if (Request.Form["LoanBox"] == "")
            {
                game = new Game(id, Request.Form["TitleBox"], Request.Form["PlatformBox"],
                    Request.Form["GenreBox"], Request.Form["ESRBBox"],
                    int.Parse(Request.Form["YearBox"]), Request.Form["ImageLinkBox"]);
            }
            else
            {
                game = new Game(id, Request.Form["TitleBox"], Request.Form["PlatformBox"],
                    Request.Form["GenreBox"], Request.Form["ESRBBox"], int.Parse(Request.Form["YearBox"]),
                    Request.Form["ImageLinkBox"], Request.Form["LoanBox"], DateTime.Now);
            }
            if (ModelState.IsValid)
            {
                //dal.DeleteGame(game.Id);
                dal.AddGame(game);
            }
            return View("GameLibrary", dal.GetGames());
        }

        public IActionResult DeleteGame(int? id)
        {
            dal.DeleteGame(id);
            return View("GameLibrary", dal.GetGames());
        }

        public IActionResult SearchGame()
        {
            return View("GameLibrary", dal.Search(Request.Form["txtSearch"]));
        }

        public IActionResult FilterCollection()
        {
            return View("GameLibrary", dal.Filter(Request.Form["FilterByPlatform"],
                Request.Form["FilterByRating"], Request.Form["FilterByGenre"]));
        }

        public IActionResult UpdateGamePage(int? id)
        {
            return View("UpdateGamePage", dal.GetGame(id));
        }

        public IActionResult UpdateGame(Game game)
        {
            game = new Game(game.Id, Request.Form["TitleBox"], Request.Form["PlatformBox"], Request.Form["GenreBox"],
                Request.Form["ESRBBox"], int.Parse(Request.Form["YearBox"]), Request.Form["ImageLinkBox"], Request.Form["LoanBox"], DateTime.Now);
            if (ModelState.IsValid)
            {
                dal.UpdateGame(game);
            }
            return View("GameLibrary", dal.GetGames());
        }
    }
}
