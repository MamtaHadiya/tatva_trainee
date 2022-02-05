using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Contact()
        {
            return View("Contact");
        }

        public IActionResult Faq()
        {
            return View("Faq");
        }

        public IActionResult About()
        {
            return View("About");
        }
    }
}
