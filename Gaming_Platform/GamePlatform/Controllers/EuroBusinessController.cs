using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GamePlatform.Controllers
{
    public class EuroBusinessController : Controller
    {
        public IActionResult EuroBusiness()
        {
            return View();
        }
    }
}