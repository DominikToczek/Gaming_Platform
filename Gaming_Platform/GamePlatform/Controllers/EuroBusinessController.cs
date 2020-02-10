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

        [HttpPost]
        public JsonResult StartGame(Player[] playersData)
        {
            List<Player> a = _game.InitPlayer(playersData);
            return Json(a);
        }

        public ViewResult AddPlayers()
        {

            
          
            return View();
        }

        [HttpPost]
        public JsonResult DiceThrow()
        {
            //Tej metody będę używał do wywołania rzutu kostką jako wynik będzie zwracany obiekt z flagami
            _game.DiceRoll();
            return Json(_game.CreateObjectToView());
        }

        [HttpPost]
        public JsonResult BuyHouse(ObjectBuyHouse objectBuyHouse)
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
            _game.SelectPlayer(objectBuyHouse.numer_gracza);
            _game.BuyHome(3, objectBuyHouse.numer_pola);

            return Json(new { numer_gracza = objectBuyHouse.numer_gracza, stan_konta = _game.SelectedPlayer.Money });
        }

        [HttpPost]
        public JsonResult SellField(ObjectSellField objectSellField)
        {

            _game.SelectPlayer(objectSellField.numer_gracza);
            _game.SellField(objectSellField.numer_pola);
            //w przypadku gdy player może zostać bankrutem może sprzedać swoje pola i do tego służy ta metoda 
            /*
                Przesyłany obiekt:
                {
                    numer_gracza: 1,
                    numer_pola: 21
                }

                w odpowiedzi oczekuję
                {
                    numer_gracza: 1,
                    stan_konta: 34212
                }
             */

            return Json(new { numer_gracza = objectSellField.numer_gracza, stan_konta = _game.SelectedPlayer.Money });
        }


        public class ObjectBuyHouse
        {
            public int numer_gracza { get; set; }
            public int ilosc_domkow { get; set; }
            public int numer_pola { get; set; }
        }

        public class ObjectSellField
        {
            public int numer_gracza { get; set; }
            public int numer_pola { get; set; }
        }

    }
}