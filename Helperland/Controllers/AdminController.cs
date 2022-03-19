using Helperland.Data;
using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland.Controllers
{
    public class AdminController : Controller
    {
        private readonly Data.ApplicationDbContext _db;
        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                var user = _db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
                ViewBag.Firstname = user.FirstName;
                return View();
            }
            //return RedirectToAction("Login", "Account");
            return View();
        }
        public IActionResult Tab1Content()
        {
            var provider = _db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
            foreach (var item in requests)
            {
                _db.Entry(item).Reference(s => s.ServiceProvider).Load();
            }
            var record = from a in requests
                         join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             requestAddress = b,
                             user = c
                         };
            

            return View(record);
        }
        public IActionResult Tab2Content()
        {
            var record = _db.Users.ToList();
            return View(record);
        }

        public IActionResult EditModel(int? Id)
        {
            return View(_db.ServiceRequestAddresses.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault());
        }

        public IActionResult getRating(int? Id)
        {
            var ratingdata = _db.Ratings.Where(x => x.RatingTo.Equals(Id)).ToList();
            if(ratingdata != null)
            {
                var avg = ratingdata.Average(i => i.Ratings);
                return Json(avg);
            }
            
            return Json(null);
        }
    }
}
