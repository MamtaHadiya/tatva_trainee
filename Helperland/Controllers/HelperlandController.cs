using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class HelperlandController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", "_Layout");
        }
        public IActionResult Prices()
        {
            return View("Prices", "_Layout1");
        }
    }
}
