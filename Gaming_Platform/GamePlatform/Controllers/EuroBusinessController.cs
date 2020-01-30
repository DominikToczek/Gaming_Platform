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

        Game game = new Game();

   

        public ViewResult EuroBusiness()
        {
            game = new Game();
            return View();
        }

        [HttpPost]
        public JsonResult StartGame(Player[] playersData)
        {
            Player[] a = playersData;
            return Json(game.InitPlayer(playersData));
        }

        public ViewResult AddPlayers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DiceThrow()
        {
            //Tej metody będę używał do wywołania rzutu kostką jako wynik będzie zwracany obiekt z flagami
            game.DiceRoll();
            return Json(game.CreateObjectToView());
        }

        [HttpPost]
        public ActionResult BuyHouse(ObjectBuyHouse objectBuyHouse)
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
            game.SelectPlayer(objectBuyHouse.numer_gracza);
            game.BuyHome(3, objectBuyHouse.numer_pola);

            return Json(new { numer_gracza = objectBuyHouse.numer_gracza , stan_konta = game.SelectedPlayer.Money });
        }

        [HttpPost]
        public ActionResult SellField(ObjectSellField objectSellField)
        {
           
            game.SelectPlayer(objectSellField.numer_gracza);
            game.SellField(objectSellField.numer_pola);
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

            return Json(new {numer_gracza = objectSellField.numer_gracza , stan_konta = game.SelectedPlayer.Money });
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