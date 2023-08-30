using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VideoGameLibrary_PartOne.Models;
using VideoGameLibrary7._0.Areas.Identity.Data;
using VideoGameLibrary7._0.Data;
using VideoGameLibrary7._0.Interfaces;

namespace VideoGameLibrary7._0.Controllers
{
    public class GameController : Controller
    {
        private readonly UserManager<GameUser> _userManager;

        IDataAccessLayer dal;

        public GameController(IDataAccessLayer indal, GameContext inContext, UserManager<GameUser> userManager)
        {
            dal = indal;
            this._userManager = userManager;
            if (inContext.GetType() == typeof(GameListDAL))
            {
                ((GameListDAL)dal).db = inContext;
            }
        }

        public IActionResult UserLibrary()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            return View("GameLibrary", dal.GetUserGames(userId));
        }

        public IActionResult GameLibrary()
        {
            return View("GameLibrary", dal.GetGames());
        }

        [HttpPost]
        public IActionResult LoanTo(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Redirect("/Identity/Account/Login");
            }
            var user = dal.GetUser(userId);
            dal.Loan(id, user.UserName);
            return View("GameLibrary", dal.GetGames());
        }

        [HttpPost]
        public IActionResult ReturnGame(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dal.ReturnGame(id);
            return View("GameLibrary", dal.GetUserGames(userId));
        }

        [HttpPost]
        public IActionResult AddGame()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null || dal.GetUser(userId).IsAdmin == false)
            {
                return Redirect("/Identity/Account/Login");
            }

            Game game;
            int id = dal.GetGames().Count() + 1;
            
            game = new Game(id, Request.Form["TitleBox"], Request.Form["PlatformBox"],
                Request.Form["GenreBox"], Request.Form["ESRBBox"], int.Parse(Request.Form["YearBox"]),
                Request.Form["ImageLinkBox"], Request.Form["LoanBox"], DateTime.Now);
            
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
