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
        public List<Player> players;


        public EuroBusinessController()
        {

        }
        List<Player> initializationPlayer(Player[] playersData)
        {
            List<Player> players = new List<Player>();

            foreach(Player a in playersData)
            {
                players.Add(new Player(a.Name, a.Avatar, a.Money, a.Pawns));
            }
            return players;
        }

        public ViewResult EuroBusiness()
        {
            initializationPlayer(data)
            ViewData["Players"] = players;
            return View();
        }

        public JsonResult StartGame(Player[] data)
        {
            players = initializationPlayer(data);
            return Json(players);
        }

        public IActionResult click(int button)
        {

            players[button].AddMoney(1000);
            ViewData["Players"] = players;
            return PartialView("EuroBusiness");
        }

        public IActionResult AddPlayers()
        {
            return View();
        }
    }
}