using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamePlatform.Models.Monopoly;

namespace GamePlatform.Controllers
{
    public class EuroBusinessController : Controller
    {
        Dice dice = new Dice(1, 6);
       

        public IActionResult EuroBusiness()
        {
            
            return View();
        }

        public IActionResult roll()
        {

            TempData["DiceValue"] =  dice.Rol();

            return RedirectToAction("EuroBusiness");
        }
    }
}