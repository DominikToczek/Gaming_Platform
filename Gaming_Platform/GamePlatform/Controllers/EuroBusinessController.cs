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
        List<Player> players = new List<Player>();
        List<Player> initializationPlayer(DataFromForm[] playersData)
        {
            List<Player> players = new List<Player>();

            for(int i=0; i<playersData.Length; i++)
            {
                Pawn pawn = new Pawn(playersData[i].Color, 1, 0);
                players.Add(new Player(playersData[i].Name, playersData[i].Avatar, 5000, pawn));
            }
            return players;
        }

        public ViewResult EuroBusiness()
        {
            ViewData["payers"] = players;
            return View();
        }

        [HttpPost]
        public JsonResult StartGame(DataFromForm[] playersData)
        {
            players = initializationPlayer(playersData);
            return Json(players);
        }

        public IActionResult AddPlayers()
        {
            return View();
        }
    }
}