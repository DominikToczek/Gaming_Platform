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
        List<IPlayer> players;


        public EuroBusinessController()
        {

        }
         List<IPlayer> initializationPlayer()
        {
            List<IPlayer> players =new List<IPlayer>(); ;
            players.Add(new Player("Kamil", 0));
            players.Add(new Player("Ola", 1314));
            players.Add(new Player("Daniel", 1331));
            players.Add(new Player("Kuba", 1313114));
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
