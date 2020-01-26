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
        List<Player> players;


        public EuroBusinessController()
        {

        }
        List<Player> initializationPlayer()
        {
            var pawn = new Pawn("red", 1, 1);
            List<Player> players = new List<Player>(); ;
            players.Add(new Player("Kamil", 13, pawn));
            players.Add(new Player("Ola", 0, pawn));
            players.Add(new Player("Daniel", 0, pawn));
            players.Add(new Player("Kuba", 0, pawn));
            return players;


        }

        public ViewResult EuroBusiness()
        {
            players = initializationPlayer();
            ViewData["Players"] = players;
            return View();
        }

        public IActionResult click(int button)
        {

            players[button].AddMoney(1000);
            ViewData["Players"] = players;
            return PartialView("EuroBusiness");
        }
      

    }



}