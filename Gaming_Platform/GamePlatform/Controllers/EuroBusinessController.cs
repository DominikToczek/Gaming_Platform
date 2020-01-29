using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePlatform.Models;

namespace GamePlatform.Controllers
{
    public class EuroBusinessController : Controller
    {

        Game game;
   

        public ViewResult EuroBusiness()
        {
            game = new Game();
            return View();
        }

        [HttpPost]
        public JsonResult StartGame(Player[] playersData)
        {
            return Json(game.InitPlayer(playersData));
        }

        public IActionResult AddPlayers()
        {
            return View();
        }
    }
}