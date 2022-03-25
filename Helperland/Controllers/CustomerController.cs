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
using OfficeOpenXml;
using System.IO;

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
            //return View();
            return RedirectToAction("Login", "Account");
        }
        
        public IActionResult Dashboard()
        {
            System.Threading.Thread.Sleep(300);
            List<ServiceRequest> record = _db.ServiceRequests.Where(x => x.ServiceStartDate >= DateTime.Now && x.Status != 1 && x.Status != 2 && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList();
            foreach (var item in record)
            {
                _db.Entry(item).Reference(s => s.ServiceProvider).Load();
            }
            return View(record);
        }
        
        public IActionResult ServiceHistory()
        {
            System.Threading.Thread.Sleep(300);
            List<ServiceRequest> record = _db.ServiceRequests.Where(x => x.ServiceStartDate < DateTime.Now && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList();
            foreach(var item in record)
            {
                _db.Entry(item).Reference(s => s.ServiceProvider).Load();
            }
            return View(record);

            //return View(_db.ServiceRequests.Where(x => x.ServiceStartDate < DateTime.Now && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList());
        }

        public IActionResult FavPros()
        {
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
           foreach(var item in requests)
            {
                _db.Entry(item).Collection(s => s.Ratings).Load();
            }
            var record = from a in requests
                         join b in users on a.ServiceProviderId equals b.UserId into table2
                         from b in table2.Where(x => a.UserId.Equals(HttpContext.Session.GetInt32("userid")) && a.Status.Equals(1)).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             user = b
                         };
            return View(record);
        }

        public IActionResult BlockProvider(int Id)
        {
            var id = HttpContext.Session.GetInt32("userid");
            var FBdata = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(Id) && x.UserId.Equals(id)).FirstOrDefault();
            FavoriteAndBlocked favoriteAndBlocked = new FavoriteAndBlocked();

            if (FBdata != null && FBdata.IsBlocked == true)
            {
                FBdata.IsBlocked = false;

                _db.FavoriteAndBlockeds.Update(FBdata);
                _db.SaveChanges();
                return Json(false);
            }
            else if (FBdata != null && FBdata.IsBlocked == false)
            {
                FBdata.IsBlocked = true;

                _db.FavoriteAndBlockeds.Update(FBdata);
                _db.SaveChanges();
                return Json(true);
            }
            else
            {
                favoriteAndBlocked.UserId = (int)id;
                favoriteAndBlocked.TargetUserId = Id;
                favoriteAndBlocked.IsFavorite = false;
                favoriteAndBlocked.IsBlocked = true;

                _db.FavoriteAndBlockeds.Add(favoriteAndBlocked);
                _db.SaveChanges();
                return Json(true);
            }

        }

        public IActionResult FavProvider(int Id)
        {
            var id = HttpContext.Session.GetInt32("userid");
            var FBdata = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(Id) && x.UserId.Equals(id)).FirstOrDefault();
            FavoriteAndBlocked favoriteAndBlocked = new FavoriteAndBlocked();

            if (FBdata != null && FBdata.IsFavorite == true)
            {
                FBdata.IsFavorite = false;

                _db.FavoriteAndBlockeds.Update(FBdata);
                _db.SaveChanges();
                return Json(false);
            }
            else if (FBdata != null && FBdata.IsFavorite == false)
            {
                FBdata.IsFavorite = true;

                _db.FavoriteAndBlockeds.Update(FBdata);
                _db.SaveChanges();
                return Json(true);
            }
            else
            {
                favoriteAndBlocked.UserId = (int)id;
                favoriteAndBlocked.TargetUserId = Id;
                favoriteAndBlocked.IsFavorite = true;
                favoriteAndBlocked.IsBlocked = false;

                _db.FavoriteAndBlockeds.Add(favoriteAndBlocked);
                _db.SaveChanges();
                return Json(true);
            }

        }

        public IActionResult CheckBlock(int Id)
        {
            var buser = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(Id)).FirstOrDefault();
            if (buser != null && buser.IsBlocked == true)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public IActionResult CheckFav(int Id)
        {
            var buser = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(Id)).FirstOrDefault();
            if (buser != null && buser.IsFavorite == true)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public FileResult DownloadExcel()
        {
            List<ServiceRequest> record = _db.ServiceRequests.Where(x => x.ServiceStartDate < DateTime.Now && x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).ToList();
            foreach (var item in record)
            {
                _db.Entry(item).Reference(s => s.ServiceProvider).Load();
            }

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Service Id";
            Sheet.Cells["B1"].Value = "Service Date";
            Sheet.Cells["C1"].Value = "Service Provider";
            Sheet.Cells["D1"].Value = "Payment";
            Sheet.Cells["E1"].Value = "Status";
            int row = 2;
            foreach (var item in record)
            {
                Sheet.Cells[String.Format("A{0}", row)].Value = item.ServiceRequestId;
                Sheet.Cells[String.Format("B{0}", row)].Value = item.ServiceStartDate.ToShortDateString() + "\n" + item.ServiceStartDate.ToShortTimeString() + " - " + item.ServiceStartDate.AddHours(Convert.ToDouble(item.SubTotal)).ToShortTimeString();
                if(item.ServiceProviderId != null)
                {
                    Sheet.Cells[String.Format("C{0}", row)].Value = item.ServiceProvider.FirstName + " " + item.ServiceProvider.LastName;

                }
                else
                {
                    Sheet.Cells[String.Format("C{0}", row)].Value = " ";

                }
                Sheet.Cells[String.Format("D{0}", row)].Value = item.TotalCost + " $";
                if(item.Status == 1)
                {
                    Sheet.Cells[String.Format("E{0}", row)].Value = "Completed";
                }
                else if (item.Status == 2)
                {
                    Sheet.Cells[String.Format("E{0}", row)].Value = "Cancelled";
                }
                else if(item.Status == 1)
                {
                    Sheet.Cells[String.Format("E{0}", row)].Value = "Accepted";
                }
                else
                {
                    Sheet.Cells[String.Format("E{0}", row)].Value = "Booked";
                }
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            using (MemoryStream stream = new MemoryStream())
            {
                Ep.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "UserServiceHistory.xlsx");
            }


        }

        public JsonResult getSpName(int Id)
        {
            var Service = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var Provider = _db.Users.Where(x => x.UserId.Equals(Service.ServiceProviderId)).FirstOrDefault();
            if (Provider != null)
            {
                var sprating = _db.Ratings.Where(x => x.RatingTo.Equals(Provider.UserId)).ToList();
                var fullname = Provider.FirstName + " " + Provider.LastName;
                var profile = Provider.UserProfilePicture;
                if(sprating != null)
                {
                    var avg = sprating.Average(i => i.Ratings);
                    return Json(new
                    {
                        full = fullname,
                        photo = profile,
                        ratings = avg
                    });
                }
                else
                {
                    return Json(new
                    {
                        full = fullname,
                        photo = profile
                    });
                }
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
            var provider = _db.Users.Where(x => x.UserId.Equals(ServiceRequest.ServiceProviderId)).FirstOrDefault();
            ServiceRequest.ServiceStartDate = ServiceDate;
            _db.ServiceRequests.Update(ServiceRequest);
            _db.SaveChanges();
            
            var subject = "Service Request reschedule by Customer";
            var body = "Hi " + provider.FirstName + "Service Request " + ServiceRequest.ServiceRequestId +
                " has been reschedule by customer.<br>" +
                "Thankyou";
            SendEmail(provider.Email, body, subject);
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
            return View(_db.UserAddresses.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid")) && x.IsDeleted.Equals(false)).ToList());
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
            Address.IsDeleted = true;
            _db.UserAddresses.Update(Address);
            _db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public IActionResult RateSp(Rating rating)
        {
            var requests = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(rating.ServiceRequestId)).FirstOrDefault();
            var customerdata = _db.Users.Where(x => x.UserId.Equals(requests.UserId)).FirstOrDefault();
            var spdata = _db.Users.Where(x => x.UserId.Equals(requests.ServiceProviderId)).FirstOrDefault();
            if(requests != null && customerdata != null && spdata != null)
            {
                rating.RatingFrom = customerdata.UserId;
                rating.RatingTo = spdata.UserId;
                if (ModelState.IsValid)
                {
                    rating.Ratings = (rating.OnTimeArrival + rating.Friendly + rating.QualityOfService)/ 3;
                    rating.RatingDate = DateTime.Now;
                    _db.Ratings.Add(rating);
                    _db.SaveChanges();
                    return Json(true);
                }
                return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
            }
            return Json(false);
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
