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

        public ViewResult Poker()
        {
            return View();
        }

        [HttpPost]
        public JsonResult DealCards()
        {
            return Json("Tu Backendowe dealcards");
        }

        [HttpPost]
        public ActionResult GetPlayerHand()
        {
            return Json("backend player hand");
        }

        [HttpPost]
        public ActionResult GetComputerHand()
        {
            return Json("backend computer hand");
        }

        [HttpPost]
        public ActionResult ChangeCard(int? Id)
        {
            return Json("index to " + Id);
        }
    }
}
