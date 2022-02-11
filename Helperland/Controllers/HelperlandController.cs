using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helperland.Data;
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
            return View("Index");
        }

        public IActionResult Prices()
        {
            return View("Prices");
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
