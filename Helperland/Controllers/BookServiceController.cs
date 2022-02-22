using Helperland.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Helperland.Models;
using System.Net.Mail;
using System.Net;

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
        public string SerchZipcode(string ZipCode)
        {
            if (HttpContext.Session.GetInt32("userid") != null)
            {
                if (ZipCode != null)
                {
                    var data = _db.Zipcodes.Where(x => x.ZipcodeValue.Equals(ZipCode)).FirstOrDefault();
                    var data2 = _db.Users.Where(x => x.ZipCode.Equals(ZipCode) && x.UserTypeId.Equals(2)).FirstOrDefault();
                    if (data != null && data2 != null)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }
                }
                return "false";
            }
            return "login";
        }

        [HttpGet]
        public IActionResult GetAddress()
        {
            System.Threading.Thread.Sleep(2000);
            return View(_db.UserAddresses.ToList());
            //Address address = new Address();
            //address.Address1 = "Hedge End";
            //return View(address);
        }

        [HttpPost]
        public IActionResult AddAddress(UserAddress objuser)
        {
            if (ModelState.IsValid)
            {
                _db.UserAddresses.Add(objuser);
                _db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        public JsonResult AddRequest(ServiceRequestModel booking)
        {
            if(booking != null)
            {
                ServiceRequest request = new ServiceRequest
                {
                    UserId = booking.UserId,
                    ServiceStartDate = booking.ServiceStartDate,
                    ZipCode = booking.ZipCode,
                    ServiceHourlyRate = booking.ServiceHourlyRate,
                    ExtraHours = booking.ExtraHours,
                    SubTotal = booking.SubTotal,
                    TotalCost = booking.TotalCost,
                    Comments = booking.Comments,
                    HasPets = booking.HasPets,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Distance = 0
                };
                _db.ServiceRequests.Add(request);
                _db.SaveChanges();
                var requestId = request.ServiceRequestId;
                return Json(new { id = requestId.ToString() });
            }
            return Json(false);
        }

        public JsonResult AddExtra(int ServiceId, int ExtraId)
        {
            ServiceRequestExtra requestExtra = new ServiceRequestExtra
            {
                ServiceRequestId = ServiceId,
                ServiceExtraId = ExtraId
            };
            _db.ServiceRequestExtras.Add(requestExtra);
            _db.SaveChanges();
            return Json(true);
        }


        public JsonResult AddServiceAddress(int ServiceId, int AddressId)
        {
            var AddressData = _db.UserAddresses.Where(x => x.AddressId.Equals(AddressId)).FirstOrDefault();
            ServiceRequestAddress requestAddress = new ServiceRequestAddress
            {
                ServiceRequestId = ServiceId,
                AddressLine1 = AddressData.AddressLine1,
                AddressLine2 = AddressData.AddressLine2,
                City = AddressData.City,
                State = AddressData.State,
                PostalCode = AddressData.PostalCode,
                Mobile = AddressData.Mobile,
                Email = AddressData.Email
            };
            _db.ServiceRequestAddresses.Add(requestAddress);
            _db.SaveChanges();
            var Providers = _db.Users.Where(x => x.ZipCode.Equals(AddressData.PostalCode) && x.UserTypeId.Equals(2)).ToList();

            
            foreach(var provider in Providers)
            {
                var subject = "Service Request from Helperland";
                var body = "Hi " + provider.FirstName + "Customer has booked Service at your Area. <br> You can take that service " +
                    "by login in helperland account.<br>" +
                    "Thankyou";
                SendEmail(provider.Email, body, subject);
            }


            return Json(true);
        }

        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("mmthadiya@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential networkCred = new NetworkCredential("mmthadiya@gmail.com", "MMta00Hdya");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }

    } 
}

