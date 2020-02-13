using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePlatform.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GamePlatform.Controllers
{
    

    public class EuroBusinessController : Controller 
    {

        readonly Game _game;

        public EuroBusinessController(Game game)
        {
            _game = game;
        }

        public ViewResult EuroBusiness()
        {
            return View();
        }

        public ViewResult AddPlayers()
        {
            return View();
        }


        [HttpPost]
        public JsonResult StartGame(Player[] playersData)
        {
            List<Player> _players = _game.InitPlayer(playersData);
            List<IField> _fields = _game.board.GetAllField;
            return Json(new { players = _players , fields = _fields });
        }


        [HttpPost]
        public JsonResult DiceThrow()
        {
            _game.DiceRoll();
            object a = _game.CreateObjectToView();
            return Json(a);
        }

        [HttpPost]
        public JsonResult NextTurn()
        {
            _game.NextPlayer();
            return Json(null);
        }

        [HttpPost]
        public JsonResult BuyHouse(ObjectBuySell objectBuySell)
        {
            _game.BuyHome(1, objectBuySell.FieldNumber);

            return Json(new {mony = _game.SelectedPlayer.Money });
        }

        [HttpPost]
        public JsonResult BuyHotel(ObjectBuySell objectBuySell)
        {
            _game.BuyHotel(objectBuySell.FieldNumber);
            return Json(new { mony = _game.SelectedPlayer.Money });
        }

        [HttpPost]
        public JsonResult BuyField(ObjectBuySell objectBuySell)
        {
            _game.BuyField(objectBuySell.FieldNumber);

            return Json(new { mony = _game.SelectedPlayer.Money } );
        }


     

        public class ObjectBuySell
        { 
            public int FieldNumber { get; set; }
        }

      

    }
}