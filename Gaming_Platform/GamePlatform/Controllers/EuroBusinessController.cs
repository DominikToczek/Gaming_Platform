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
            //Tej metody będę używał do wywołania rzutu kostką jako wynik będzie zwracany obiekt z flagami
            _game.DiceRoll();
            object a = _game.CreateObjectToView();
            return Json(a);
        }

        [HttpPost]
        public JsonResult BuyHouse(ObjectBuySell objectBuySell)
        {

            /*Tej metody będę używał do zakupu domków przez użytkownika. Otrzymasz taki obiekt
             * {
                numer_gracza: 1,
                ilosc_domków: 3,
                numer_pola: 31
                } 


                w odpowiedzi oczekuję
                {
                    numer_gracza: 1,
                    stan_konta: 34212
                }
             */
            _game.BuyHome(1, objectBuySell.FieldNumber);

            return Json(new { idPlayer = _game.SelectedPlayer.Id, mony = _game.SelectedPlayer.Money });
        }

        [HttpPost]
        public JsonResult BuyField(ObjectBuySell objectBuySell)
        {
            //tej metody będę używał do kupowania pól
            /* {
            IDplayer: responceOnStartTurn.IDPlayer,
            numer_pola: responceOnStartTurn.currentPlayerField

            
            oczekuję tylko aktualnego stanu konta
            {
                money: xxxx
            }
        }*/
            _game.BuyField(objectBuySell.FieldNumber);

            return Json(new { mony = _game.SelectedPlayer.Money } );
        }


     

        public class ObjectBuySell
        { 
            public int FieldNumber { get; set; }
        }

      

    }
}