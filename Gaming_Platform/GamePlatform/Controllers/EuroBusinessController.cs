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

        public IActionResult EuroBusiness()
        {
            players = new List<IPlayer>();
            players.Add(new Player("Kamil", 313131));
            players.Add(new Player("Ola", 1314));
            players.Add(new Player("Daniel", 1331));
            players.Add(new Player("Kuba", 1313114));


            ViewData["Players"] = players;
            return View();
        }

      
    }
}