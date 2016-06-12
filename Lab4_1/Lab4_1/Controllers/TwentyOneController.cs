using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab4_1.Models;

namespace Lab4_1.Controllers
{
    public class TwentyOneController : Controller
    {
        // GET: TwentyOne
        public ActionResult Index()
        {
            return View();
        }
        // get 
        [HttpGet]
        public PartialViewResult TwentyOneGame()
        {
            var game=new GameModel();
            return PartialView( game);
        }
        // post 
        [HttpPost]
        public PartialViewResult TwentyOneGame(GameModel game)
        {
            game.UserInputLogic();

            if (game.WinLogic() && game.ComputerWin == false)
            {
                ViewBag.result = "player win";
                game.CurrentNumber = 0; //Reset after a finished game
            }
            game.ResponseLogic();

            if (game.WinLogic() && game.ComputerWin == true)
            {
                ViewBag.result = "Computer Win";
                game.CurrentNumber = 0; //Reset after a finished game
            }

            ModelState.Remove("CurrentNumber");
            return PartialView(game);

        }
    }
}