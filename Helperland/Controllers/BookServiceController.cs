using Helperland.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Helperland.Controllers
{
    public class BookServiceController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        public BookServiceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public bool SerchZipcode(string ZipCode)
        {
            if (ZipCode != null)
            {
                var data = _db.Zipcodes.Where(x => x.ZipcodeValue.Equals(ZipCode)).FirstOrDefault();
                var data2 = _db.Users.Where(x => x.ZipCode.Equals(ZipCode)).FirstOrDefault();
                if (data != null && data2 != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        [HttpGet]
        public IActionResult GetAddress()
        {
            System.Threading.Thread.Sleep(2000);
            Address address = new Address();
            address.Address1 = "Hedge End";
            return View(address);
        }

        [HttpPost]
        public IActionResult SaveBooking([FromBody] ServiceRequestModel booking)
        {
            if (booking == null)
                return Json(new SingeEntity<ServiceRequestModel>() { Result = null, Status = "ERROR", ErrorMessage = "Error in deserializing submitted data into booking object" }
                    , new System.Text.Json.JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = false
                    });
            else
            {
                var result = new System.Dynamic.ExpandoObject();
                return Json(new SingeEntity<ServiceRequestModel>() { Result = booking, Status = "OK" }
                    , new System.Text.Json.JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = false
                    });
            }
        }


    }
    public class BaseList<T> where T : class
    {
        public int TotalCount { get; set; }
        public T Result { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SingeEntity<T> where T : class
    {
        public T Result { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class Address
    {
        public string Address1 { get; set; }
    }
    public class ServiceRequestModel
    {
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("address1")]
        public string Address1 { get; set; }
        [JsonPropertyName("hours")]
        public double Hours { get; set; }
        [JsonPropertyName("bookingStartTime")]
        public string BookingStartTime { get; set; }
        public DateTime ServiceStartDate
        {
            get
            {
                DateTime date = DateTime.MinValue;
                if (!string.IsNullOrEmpty(this.BookingStartTime))
                    DateTime.TryParse(this.BookingStartTime, out date);
                return date;
            }
        }
    }
    //public IActionResult SetupService()
    //{
    //    ViewBag.image1 = "1.png";
    //    ViewBag.image2 = "2.png";
    //    ViewBag.image3 = "3.png";
    //    ViewBag.image4 = "4.png";
    //    ViewBag.image5 = "5.png";
    //    return View("SetupService");
    //}

    //[HttpPost]
    //public IActionResult SetupService(string ZipCode)
    //{
    //    if(ZipCode != null)
    //    {
    //        var data = _db.Zipcodes.Where(x => x.ZipcodeValue.Equals(ZipCode)).FirstOrDefault();
    //        var data2 = _db.Users.Where(x => x.ZipCode.Equals(ZipCode)).FirstOrDefault();
    //        if (data != null && data2 != null)
    //        {
    //            ViewData["Disable1"] = "disabled";
    //            TempData["alert"] = "Zipcode matched Successfully.Now please click Schedule and plan tab to move forword.";
    //            //return new RedirectResult(Url.Action("SetupService") + "#menu1");
    //            return View();
    //        }
    //        else
    //        {
    //            ViewBag.error = "We are not providing service in this area.We'll notify you if any helper would start working near your area.";
    //            return View();
    //        }
    //    }
    //    else
    //    {
    //        ViewBag.error = "please enter valid Postal code.";
    //        return View();
    //    }


    //}

    //public IActionResult SubmitForm1(string datevalue, string timevalue)
    //{
    //    ViewData["Disable1"] = "disabled";
    //    TempData["Date"] = datevalue;
    //    TempData["Time"] = timevalue;
    //    TempData["alert"] = "Date and Time saved successfully.Now please click Schedule and plan tab to move forword.";
    //    return View("SetupService", "BookService");
    //}

    //public IActionResult SubmitForm2(string Hours)
    //{
    //    TempData["Hours"] = Hours;
    //    TempData["alert"] = "Basic Time Duration saved successfully.Now please click Schedule and plan tab to move forword.";
    //    return View("SetupService", "BookService");
    //}

    //public IActionResult Cabinets()
    //{
    //    ViewBag.image3 = "3-green.png";
    //    return View("SetupService", "BookService");
    //}
    //public IActionResult Fridge()
    //{
    //    ViewBag.image1 = "1.png";
    //    ViewBag.image2 = "2.png";
    //    ViewBag.image3 = "3.png";
    //    ViewBag.image4 = "4.png";
    //    ViewBag.image5 = "5-green.png";
    //    return View("SchedulePlan", "BookService");
    //}

    //public IActionResult Oven()
    //{
    //    ViewBag.image1 = "1.png";
    //    ViewBag.image2 = "2.png";
    //    ViewBag.image3 = "3-green.png";
    //    ViewBag.image4 = "4-green.png";
    //    ViewBag.image5 = "5.png";
    //    return View("SchedulePlan", "BookService");
    //}
    //public IActionResult Laundry()
    //{
    //    ViewBag.image1 = "1.png";
    //    ViewBag.image2 = "2.png";
    //    ViewBag.image3 = "3-green.png";
    //    ViewBag.image4 = "4.png";
    //    ViewBag.image5 = "5.png";
    //    return View("SchedulePlan", "BookService");
    //}
    //public IActionResult Windows()
    //{
    //    ViewBag.image1 = "1.png";
    //    ViewBag.image2 = "2.png";
    //    ViewBag.image3 = "3-green.png";
    //    ViewBag.image4 = "4.png";
    //    ViewBag.image5 = "5.png";
    //    return View("SchedulePlan", "BookService");
    //}

    //public IActionResult SchedulePlan()
    //{
    //    ViewBag.image = "3.png";
    //    return View("SchedulePlan");
    //}
}

