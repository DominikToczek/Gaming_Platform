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

        Game game;
   

        public ViewResult EuroBusiness()
        {
            game = new Game();
            return View();
        }

        [HttpPost]
        public JsonResult StartGame(Player[] playersData)
        {
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
            return Json("fdsfasd");
        }

        [HttpPost]
        public ActionResult BuyHouse()
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

            return Json("fdsfasd");
        }

        [HttpPost]
        public ActionResult SellField()
        {
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

            return Json("fdsfasd");
        }
    }
}