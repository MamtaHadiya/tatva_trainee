using Helperland.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Helperland.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mail;
using System.Net;

namespace Helperland.Controllers
{
    public class CustomerController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        dynamic mymodel = new ExpandoObject();

        public CustomerController(ApplicationDbContext db)
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
            return RedirectToAction("Login", "Account");
        }
        public IActionResult Dashboard()
        {
            System.Threading.Thread.Sleep(300);
            return View(_db.ServiceRequests.Where(x => x.ServiceStartDate >= DateTime.Now && x.Status == null && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList());
        }
        public IActionResult ServiceHistory()
        {
            System.Threading.Thread.Sleep(300);
            //var serviceList = from a in _db.ServiceRequests
            //              join b in _db.Users
            //              on a.ServiceProviderId equals b.UserId
            //              into userlist
            //              from b in userlist.DefaultIfEmpty()

            //              select new ServiceRequest
            //              {
            //                  ServiceRequestId = a.ServiceRequestId,
            //                  ServiceStartDate = a.ServiceStartDate,
            //                  TotalCost = a.TotalCost,
            //                  Status = a.Status,
            //                  ServiceProviderId = a.ServiceProviderId,
            //              };
            return View(_db.ServiceRequests.Where(x => x.ServiceStartDate < DateTime.Now && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList());
        }

        public string ServiceProviderName(int Id)
        {
            var Provider = _db.Users.Where(x => x.UserId.Equals(Id)).FirstOrDefault();
            if(Provider != null)
            {
                return Provider.FirstName;
            }
            return null;
        }


        public IActionResult MySetting()
        {
            return View(_db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault());
        }

        public JsonResult Service(int Id)
        {
            var datas = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var AddressData = _db.ServiceRequestAddresses.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var address = AddressData.AddressLine1 + " " + AddressData.AddressLine2 + ", " + AddressData.PostalCode + " " + AddressData.City;
            var Extra = _db.ServiceRequestExtras.Where(x => x.ServiceRequestId.Equals(Id)).ToList();
            var AllExtra = "";
            foreach(var item in Extra)
            {
                AllExtra = AllExtra + GetExtraName(item.ServiceExtraId);
            }
            return Json(new { serviceid = datas.ServiceRequestId, servicedate = datas.ServiceStartDate.ToString(), extra = AllExtra,
                addresses = address, phone = AddressData.Mobile, duration = datas.ServiceHours, email = AddressData.Email, total = datas.TotalCost, cmnt = datas.Comments
            });
        }

        public JsonResult ServiceUpdate(int Id, string StartDateTime)
        {
            DateTime ServiceDate = DateTime.Parse(StartDateTime);
            var ServiceRequest = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            ServiceRequest.ServiceStartDate = ServiceDate;
            _db.ServiceRequests.Update(ServiceRequest);
            _db.SaveChanges();
            return Json(true);
        }

        public JsonResult ServiceCancel(int Id)
        {
            var ServiceRequest = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var provider = _db.Users.Where(x => x.UserId.Equals(ServiceRequest.ServiceProviderId)).FirstOrDefault();
            ServiceRequest.Status = 2;
            _db.ServiceRequests.Update(ServiceRequest);
            _db.SaveChanges();

            var subject = "Service Request Canceled by Customer";
            var body = "Hi " + provider.FirstName + "Service Request " + ServiceRequest.ServiceRequestId +
                "has been cancelled by customer.<br>" +
                "Thankyou";
            SendEmail(provider.Email, body, subject);
            return Json(true);
        }

        public IActionResult MyDetails()
        {
            var id = HttpContext.Session.GetInt32("userid");
            User UserDetails = _db.Users.Where(x => x.UserId.Equals(id)).FirstOrDefault();
            return View(UserDetails);
        }

        [HttpPost]
        public IActionResult MyDetails(User objuser)
        {
            if(objuser.FirstName != "" || objuser.LastName != "" || objuser.Mobile != "")
            {
                var user = _db.Users.Where(x => x.UserId.Equals(objuser.UserId)).FirstOrDefault();
                if (user != null)
                {
                    user.FirstName = objuser.FirstName;
                    user.LastName = objuser.LastName;
                    user.Mobile = objuser.Mobile;
                    user.DateOfBirth = objuser.DateOfBirth;
                    user.LanguageId = objuser.LanguageId;
                    _db.Update(user);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return new ContentResult() { Content = "<script language='javascript' type='text/javascript'>alert('FirstName,LastName and mobile are Required Field.');</script>" };
           
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword objuser)
        {
            if (ModelState.IsValid)
            {
                var user = _db.Users.Where(x => x.Password.Equals(objuser.OldPassword) && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
                if(user != null)
                {
                    user.Password = objuser.Password;
                    _db.Update(user);
                    _db.SaveChanges();
                    return Json(true);
                }
                return Json(false);
            }
            return Json(ModelState.Values.SelectMany(v=>v.Errors).Select(e=>e.ErrorMessage).ToList());
        }

        public IActionResult GetAddress()
        {
            return View(_db.UserAddresses.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList());
        }

        public IActionResult EditAddress(int Id)
        {
            var Address = _db.UserAddresses.Where(x => x.AddressId.Equals(Id)).FirstOrDefault();
            return Json(Address);
        }

        [HttpPost]
        public IActionResult ChangeAddressData(UserAddress objuser)
        {
            if (ModelState.IsValid)
            {
                var Address = _db.UserAddresses.Where(x => x.AddressId.Equals(objuser.AddressId)).FirstOrDefault();
                if(Address != null)
                {
                    Address.AddressLine1 = objuser.AddressLine1;
                    Address.AddressLine2 = objuser.AddressLine2;
                    Address.City = objuser.City;
                    Address.PostalCode = objuser.PostalCode;
                    Address.Mobile = objuser.Mobile;

                    _db.UserAddresses.Update(Address);
                    _db.SaveChanges();
                    return Json(true);
                }
                return Json(false);
            }
            return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
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
            return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
        }

        [HttpPost]
        public IActionResult DeleteAddress(int? Id)
        {
            if(Id == null)
            {
                return Json(false);
            }
            var Address = _db.UserAddresses.Where(x => x.AddressId.Equals(Id)).FirstOrDefault();
            _db.UserAddresses.Remove(Address);
            _db.SaveChanges();
            return Json(true);
        }
        private string GetExtraName(int serviceExtraId)
        {
            if(serviceExtraId == 1)
            {
                return " Inside Cabinets,";
            }
            else if(serviceExtraId == 2)
            {
                return " Inside Fridge,";
            }
            else if (serviceExtraId == 3)
            {
                return " Inside Oven,";
            }
            else if (serviceExtraId == 4)
            {
                return " Laundry wash & dry,";
            }
            else
            {
                return " Interior Windows,";
            }
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
