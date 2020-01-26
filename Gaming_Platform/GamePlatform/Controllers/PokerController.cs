using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePlatform.Models;

namespace GamePlatform.Controllers
{
    public class PokerController : Controller
    {
        List<IPlayer> players;


        public PokerController()
        {

        }
         List<IPlayer> initializationPlayer()
        {
            List<IPlayer> players =new List<IPlayer>(); ;
            players.Add(new Player("Arek", 0));
            return players;
        }

        public ViewResult Poker()
        {
            players = initializationPlayer();
            ViewData["Players"] = players;
            return View();
        }

        public IActionResult click(int button)
        {

            players[button].AddMoney(1000);
            ViewData["Players"] = players;
            return PartialView("Poker");
        }

       
    }



    }
