using Helperland.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class BookServiceController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        public BookServiceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult SetupService()
        {
            ViewBag.image1 = "1.png";
            ViewBag.image2 = "2.png";
            ViewBag.image3 = "3.png";
            ViewBag.image4 = "4.png";
            ViewBag.image5 = "5.png";
            return View("SetupService");
        }

        [HttpPost]
        public IActionResult SetupService(string ZipCode)
        {
            if(ZipCode != null)
            {
                var data = _db.Zipcodes.Where(x => x.ZipcodeValue.Equals(ZipCode)).FirstOrDefault();
                var data2 = _db.Users.Where(x => x.ZipCode.Equals(ZipCode)).FirstOrDefault();
                if (data != null && data2 != null)
                {
                    ViewData["Disable1"] = "disabled";
                    TempData["alert"] = "Zipcode matched Successfully.Now please click Schedule and plan tab to move forword.";
                    //return new RedirectResult(Url.Action("SetupService") + "#menu1");
                    return View();
                }
                else
                {
                    ViewBag.error = "We are not providing service in this area.We'll notify you if any helper would start working near your area.";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "please enter valid Postal code.";
                return View();
            }
            
            
        }

        public IActionResult SubmitForm1(string datevalue, string timevalue)
        {
            ViewData["Disable1"] = "disabled";
            TempData["Date"] = datevalue;
            TempData["Time"] = timevalue;
            TempData["alert"] = "Date and Time saved successfully.Now please click Schedule and plan tab to move forword.";
            return View("SetupService", "BookService");
        }

        public IActionResult SubmitForm2(string Hours)
        {
            TempData["Hours"] = Hours;
            TempData["alert"] = "Basic Time Duration saved successfully.Now please click Schedule and plan tab to move forword.";
            return View("SetupService", "BookService");
        }

        public IActionResult Cabinets()
        {
            ViewBag.image3 = "3-green.png";
            return View("SetupService", "BookService");
        }
        public IActionResult Fridge()
        {
            ViewBag.image1 = "1.png";
            ViewBag.image2 = "2.png";
            ViewBag.image3 = "3.png";
            ViewBag.image4 = "4.png";
            ViewBag.image5 = "5-green.png";
            return View("SchedulePlan", "BookService");
        }

        public IActionResult Oven()
        {
            ViewBag.image1 = "1.png";
            ViewBag.image2 = "2.png";
            ViewBag.image3 = "3-green.png";
            ViewBag.image4 = "4-green.png";
            ViewBag.image5 = "5.png";
            return View("SchedulePlan", "BookService");
        }
        public IActionResult Laundry()
        {
            ViewBag.image1 = "1.png";
            ViewBag.image2 = "2.png";
            ViewBag.image3 = "3-green.png";
            ViewBag.image4 = "4.png";
            ViewBag.image5 = "5.png";
            return View("SchedulePlan", "BookService");
        }
        public IActionResult Windows()
        {
            ViewBag.image1 = "1.png";
            ViewBag.image2 = "2.png";
            ViewBag.image3 = "3-green.png";
            ViewBag.image4 = "4.png";
            ViewBag.image5 = "5.png";
            return View("SchedulePlan", "BookService");
        }

        //public IActionResult SchedulePlan()
        //{
        //    ViewBag.image = "3.png";
        //    return View("SchedulePlan");
        //}
    }
}
