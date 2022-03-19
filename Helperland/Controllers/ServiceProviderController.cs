
using Helperland.Data;
using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Drawing;


namespace Helperland.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        public ServiceProviderController(ApplicationDbContext db)
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

        public IActionResult Tab2Content()
        {
            var provider = _db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
            var record = from a in requests
                         join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.Where(x => a.ServiceStartDate > DateTime.Now && a.Status != 3 && a.Status != 2 && a.ZipCode.Equals(provider.ZipCode)).ToList()
                         select new ViewModel
                         { 
                             serviceRequest=a,
                             requestAddress=b,
                             user=c
                         };
            
            return View(record);
        }

        public IActionResult Tab3Content()
        {
            var provider = _db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
            var record = from a in requests
                         join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.Where(x => a.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid")) && a.Status == 3).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             requestAddress = b,
                             user = c
                         };
            return View(record);
        }

        public IActionResult Tab5Content()
        {
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
            var record = from a in requests
                         join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.Where(x => a.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid")) && a.ServiceStartDate < DateTime.Now.AddHours(Convert.ToDouble(a.SubTotal))).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             requestAddress = b,
                             user = c
                         };
            return View(record);
        }

        public FileResult DownloadExcel()
        {
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
            var record = from a in requests
                         join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.Where(x => a.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid")) && a.ServiceStartDate < DateTime.Now.AddHours(Convert.ToDouble(a.SubTotal))).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             requestAddress = b,
                             user = c
                         };

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Service Id";
            Sheet.Cells["B1"].Value = "Service Date";
            Sheet.Cells["C1"].Value = "Customer Details";
            int row = 2;
            foreach(var item in record)
            {
                Sheet.Cells[String.Format("A{0}", row)].Value = item.serviceRequest.ServiceRequestId;
                Sheet.Cells[String.Format("B{0}", row)].Value = item.serviceRequest.ServiceStartDate.ToShortDateString() + "\n" + item.serviceRequest.ServiceStartDate.ToShortTimeString() +" - " + item.serviceRequest.ServiceStartDate.AddHours(Convert.ToDouble(item.serviceRequest.SubTotal)).ToShortTimeString();
                Sheet.Cells[String.Format("C{0}", row)].Value = item.user.FirstName + " " + item.user.LastName + "\n"
                    + item.requestAddress.AddressLine1 +" "+ item.requestAddress.AddressLine2 + "\n" + item.requestAddress.PostalCode +" "+ item.requestAddress.City;
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            using (MemoryStream stream = new MemoryStream())
            {
                Ep.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "ServiceHistory.xlsx");
            }
            
            
        }

        public IActionResult Tab6Content()
        {

            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            List<Rating> ratings = _db.Ratings.ToList();
            var record = from a in requests
                         join b in ratings on a.ServiceRequestId equals b.ServiceRequestId into table1
                         from b in table1.ToList()
                         join c in users on a.UserId equals c.UserId into table2
                         from c in table2.Where(x => a.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid"))).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             rating = b,
                             user = c
                         };
            return View(record);
        }

        public IActionResult Tab7Content()
        {
            List<User> users = _db.Users.ToList();
            List<ServiceRequest> requests = _db.ServiceRequests.ToList();
            var record = from a in requests
                         join b in users on a.UserId equals b.UserId into table2
                         from b in table2.Where(x => a.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid")) && a.Status.Equals(1)).ToList()
                         select new ViewModel
                         {
                             serviceRequest = a,
                             user = b
                         };
            return View(record); 
        }
        
        public IActionResult MySetting()
        {
            return View(_db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault());
        }

        public JsonResult Service(int Id)
        {
            var datas = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var user = _db.Users.Where(x => x.UserId.Equals(datas.UserId)).FirstOrDefault();
            var Name = user.FirstName + " " + user.LastName;
            var AddressData = _db.ServiceRequestAddresses.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var address = AddressData.AddressLine1 + " " + AddressData.AddressLine2 + ", " + AddressData.PostalCode + " " + AddressData.City;
            var Extra = _db.ServiceRequestExtras.Where(x => x.ServiceRequestId.Equals(Id)).ToList();
            var AllExtra = "";
            foreach (var item in Extra)
            {
                AllExtra = AllExtra + GetExtraName(item.ServiceExtraId);
            }
            return Json(new
            {
                serviceid = datas.ServiceRequestId,
                servicedate = datas.ServiceStartDate.ToString(),
                subtotal = datas.SubTotal,
                extra = AllExtra,
                addresses = address,
                duration = datas.ServiceHours,
                cname = Name,
                distance = datas.Distance,
                total = datas.TotalCost,
                cmnt = datas.Comments
            });
        }

        public JsonResult ServiceAccept(int Id)
        {
            var userServices = _db.ServiceRequests.Where(x => x.ServiceProviderId.Equals(HttpContext.Session.GetInt32("userid")) && x.Status.Equals(3)).ToList();
            var ServiceRequest = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var Providers = _db.Users.Where(x => x.ZipCode.Equals(ServiceRequest.ZipCode) && x.UserTypeId.Equals(2) && x.UserId != (ServiceRequest.ServiceProviderId)).ToList();
            var Blocked = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(ServiceRequest.UserId) && x.IsBlocked.Equals(true)).FirstOrDefault();

            if(Blocked != null)
            {
                return Json("You Have Blocked this User. if you want to Accept this service then unblock this user.");
            }
            else
            {
                if (userServices != null)
                {
                    foreach (var item in userServices)
                    {
                        if (item.ServiceStartDate.ToLongDateString() == ServiceRequest.ServiceStartDate.ToLongDateString())
                        {
                            int result = DateTime.Compare(item.ServiceStartDate.AddHours(Convert.ToDouble(item.SubTotal + 1)), ServiceRequest.ServiceStartDate);
                            if (result > 0)
                            {
                                return Json(false);
                            }
                            else
                            {
                                ServiceRequest.Status = 3;
                                ServiceRequest.ServiceProviderId = HttpContext.Session.GetInt32("userid");
                                _db.ServiceRequests.Update(ServiceRequest);
                                _db.SaveChanges();


                                foreach (var provider in Providers)
                                {
                                    var subject = "Service Accepted by Another Service Provider";
                                    var body = "Hi " + provider.FirstName + "<br>Service Id = " + ServiceRequest.ServiceRequestId +
                                        " This service request is no more available. It has been assigned to another provider." +
                                        "Thankyou";
                                    SendEmail(provider.Email, body, subject);
                                }

                                return Json(true);
                            }
                        }
                    }

                }
                ServiceRequest.Status = 3;
                ServiceRequest.ServiceProviderId = HttpContext.Session.GetInt32("userid");
                _db.ServiceRequests.Update(ServiceRequest);
                _db.SaveChanges();


                foreach (var provider in Providers)
                {
                    var subject = "Service Accepted by Another Service Provider";
                    var body = "Hi " + provider.FirstName + "<br>Service Id = " + ServiceRequest.ServiceRequestId +
                        " This service request is no more available. It has been assigned to another provider." +
                        "Thankyou";
                    SendEmail(provider.Email, body, subject);
                }

                return Json(true);
            }
            
        }

        public JsonResult ServiceCancel(int Id)
        {
            var ServiceRequest = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            ServiceRequest.Status = null;
            ServiceRequest.ServiceProviderId = null;
            _db.ServiceRequests.Update(ServiceRequest);
            _db.SaveChanges();

            return Json(true);
        }

        public JsonResult ServiceComplete(int Id)
        {
            var ServiceRequest = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            ServiceRequest.Status = 1;
            _db.ServiceRequests.Update(ServiceRequest);
            _db.SaveChanges();

            return Json(true);
        }

        public IActionResult MyDetails()
        {
            var id = HttpContext.Session.GetInt32("userid");
            var userDetails = _db.Users.Where(x => x.UserId.Equals(id)).FirstOrDefault();
            SpProfileClass spProfile = new SpProfileClass();
            if(userDetails != null)
            {
                spProfile.UserId = userDetails.UserId;
                spProfile.FirstName = userDetails.FirstName;
                spProfile.LastName = userDetails.LastName;
                spProfile.Mobile = userDetails.Mobile;
                spProfile.Email = userDetails.Email;
                spProfile.DateOfBirth = userDetails.DateOfBirth;
                spProfile.NationalityId = userDetails.NationalityId;
                spProfile.Gender = userDetails.Gender;
                spProfile.UserProfilePicture = userDetails.UserProfilePicture;
                var userAddress = _db.UserAddresses.Where(x => x.UserId.Equals(id)).FirstOrDefault();

                if (userAddress != null)
                {
                    spProfile.AddressLine1 = userAddress.AddressLine1;
                    spProfile.AddressLine2 = userAddress.AddressLine2;
                    spProfile.PostalCode = userAddress.PostalCode;
                    spProfile.City = userAddress.City;
                    return View(spProfile);
                }
                return View(spProfile);
            }
            return View(spProfile);
        }

        [HttpPost]
        public IActionResult MyDetails(SpProfileClass objuser)
        {
            if (ModelState.IsValid)
            {
                var getuser = _db.Users.Where(x => x.UserId.Equals(objuser.UserId)).FirstOrDefault();
                getuser.FirstName = objuser.FirstName;
                getuser.LastName = objuser.LastName;
                getuser.Mobile = objuser.Mobile;
                getuser.DateOfBirth = objuser.DateOfBirth;
                getuser.NationalityId = objuser.NationalityId;
                getuser.Gender = objuser.Gender;
                getuser.UserProfilePicture = objuser.UserProfilePicture;
                _db.Users.Update(getuser);
                _db.SaveChanges();

                var getAddress = _db.UserAddresses.Where(x => x.UserId.Equals(objuser.UserId)).FirstOrDefault();
                if(getAddress != null)
                {
                    getAddress.AddressLine1 = objuser.AddressLine1;
                    getAddress.AddressLine2 = objuser.AddressLine2;
                    getAddress.City = objuser.City;
                    getAddress.PostalCode = objuser.PostalCode;
                    _db.UserAddresses.Update(getAddress);
                    _db.SaveChanges();
                }
                else
                {
                    UserAddress userAddress = new UserAddress();
                    userAddress.UserId = objuser.UserId;
                    userAddress.AddressLine1 = objuser.AddressLine1;
                    userAddress.AddressLine2 = objuser.AddressLine2;
                    userAddress.City = objuser.City;
                    userAddress.PostalCode = objuser.PostalCode;
                    userAddress.Email = objuser.Email;
                    userAddress.Mobile = objuser.Mobile;

                    _db.UserAddresses.Add(userAddress);
                    _db.SaveChanges();
                }
                return Json(true);
            }
            return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
        }

        public IActionResult BlockCustomer(int Id)
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
            else if(FBdata != null && FBdata.IsBlocked == false)
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

        public IActionResult CheckBlock(int Id)
        {
            var buser = _db.FavoriteAndBlockeds.Where(x => x.TargetUserId.Equals(Id)).FirstOrDefault();
            if(buser != null && buser.IsBlocked == true)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        private string GetExtraName(int serviceExtraId)
        {
            if (serviceExtraId == 1)
            {
                return " Inside Cabinets,";
            }
            else if (serviceExtraId == 2)
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
