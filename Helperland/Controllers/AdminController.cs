using Helperland.Data;
using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                ViewBag.Firstname = user.FirstName + " " + user.LastName;
                return View();
            }
            return RedirectToAction("Login", "Account");
            //return View();
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
            var record = _db.Users.Where(x => x.UserTypeId == 1 || x.UserTypeId == 2).ToList();
            return View(record);
        }

        //public IActionResult Searching(IFormCollection form)
        //{
        //    var provider = _db.Users.Where(x => x.UserId.Equals(HttpContext.Session.GetInt32("userid"))).FirstOrDefault();
        //    List<User> users = _db.Users.ToList();
        //    List<ServiceRequest> requests = _db.ServiceRequests.ToList();
        //    List<ServiceRequestAddress> addresses = _db.ServiceRequestAddresses.ToList();
        //    foreach (var item in requests)
        //    {
        //        _db.Entry(item).Reference(s => s.ServiceProvider).Load();
        //    }
        //    var record = from a in requests
        //                 join b in addresses on a.ServiceRequestId equals b.ServiceRequestId into table1
        //                 from b in table1.ToList()
        //                 join c in users on a.UserId equals c.UserId into table2
        //                 from c in table2.ToList()
        //                 select new ViewModel
        //                 {
        //                     serviceRequest = a,
        //                     requestAddress = b,
        //                     user = c
        //                 };
        //    record = record.Where(x => x.serviceRequest.Status.Equals(2)).ToList();
        //    return RedirectToAction("Index", record);
        //}


        public IActionResult EditModel(int? Id)
        {
            var service = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var AddressData = _db.ServiceRequestAddresses.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            ViewBag.Date = service.ServiceStartDate;
            AdminEditClass record = new AdminEditClass();
            record.BookingStartTime = service.ServiceStartDate.ToString();
            record.ServiceRequestId = AddressData.ServiceRequestId;
            record.AddressLine1 = AddressData.AddressLine1;
            record.AddressLine2 = AddressData.AddressLine2;
            record.City = AddressData.City;
            record.PostalCode = AddressData.PostalCode;
            return View(record);
        }

        public IActionResult getRating(int? Id)
        {
            if(Id != null)
            {
                var ratingdata = _db.Ratings.Where(x => x.RatingTo.Equals(Id)).ToList();
                if (ratingdata != null)
                {
                    var avg = ratingdata.Average(i => i.Ratings);
                    return Json(avg);
                }

            }
            return Json(null);
        }

        public IActionResult EditDetails(AdminEditClass objuser)
        {
            
            if (ModelState.IsValid)
            {
                var service = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(objuser.ServiceRequestId)).FirstOrDefault();
                var provider = _db.Users.Where(x => x.UserId.Equals(service.ServiceProviderId)).FirstOrDefault();
                var customer = _db.Users.Where(x => x.UserId.Equals(service.UserId)).FirstOrDefault();
                if (objuser.BookingStartTime != null)
                {
                    service.ServiceStartDate = objuser.ServiceStartDate;
                    service.ModifiedDate = DateTime.Now;
                    service.ModifiedBy = 3;
                    _db.ServiceRequests.Update(service);
                    _db.SaveChanges();
                    
                    
                }
                var Address = _db.ServiceRequestAddresses.Where(x => x.ServiceRequestId.Equals(objuser.ServiceRequestId)).FirstOrDefault();
                Address.AddressLine1 = objuser.AddressLine1;
                Address.AddressLine2 = objuser.AddressLine2;
                Address.City = objuser.City;
                Address.PostalCode = objuser.PostalCode;
                _db.ServiceRequestAddresses.Update(Address);
                _db.SaveChanges();
                var subject = "Service Request Edited by Admin";
                var body = "Hi " + provider.FirstName + " Service Request " + service.ServiceRequestId +
                    " has been Edited by Admin.<br>" +
                    "Thankyou";
                SendEmail(provider.Email, body, subject);
                var subject2 = "Service Request Edited by Admin";
                var body2 = "Hi " + customer.FirstName + " Service Request " + service.ServiceRequestId +
                    " has been Edited by Admin.<br>" +
                    "Thankyou";
                SendEmail(customer.FirstName, body2, subject2);

                return Json(true);
            }
            return Json(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());
        }

        public IActionResult CancelService(int Id)
        {
            var service = _db.ServiceRequests.Where(x => x.ServiceRequestId.Equals(Id)).FirstOrDefault();
            var provider = _db.Users.Where(x => x.UserId.Equals(service.ServiceProviderId)).FirstOrDefault();
            var customer = _db.Users.Where(x => x.UserId.Equals(service.UserId)).FirstOrDefault();
            if(service != null)
            {
                service.Status = 2;
                service.ModifiedDate = DateTime.Now;
                service.ModifiedBy = 3;
                _db.ServiceRequests.Update(service);
                _db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        public IActionResult ActivateUser(int Id)
        {
            var userdata = _db.Users.Where(x => x.UserId.Equals(Id)).FirstOrDefault();
            if(userdata != null)
            {
                if(userdata.IsActive == false)
                {
                    userdata.IsActive = true;
                    userdata.ModifiedDate = DateTime.Now;
                    userdata.ModifiedBy = 3;
                    _db.Users.Update(userdata);
                    _db.SaveChanges();
                    return Json(true);
                }
                else
                {
                    userdata.IsActive = false;
                    userdata.ModifiedDate = DateTime.Now;
                    userdata.ModifiedBy = 3;
                    _db.Users.Update(userdata);
                    _db.SaveChanges();
                    return Json(false);
                }
            }
           
            return Json("Error");
        }

        public IActionResult ApprooveUser(int Id)
        {
            var userdata = _db.Users.Where(x => x.UserId.Equals(Id)).FirstOrDefault();
            if(userdata != null)
            {
                userdata.IsApproved = true;
                userdata.ModifiedDate = DateTime.Now;
                userdata.ModifiedBy = 3;
                _db.Users.Update(userdata);
                _db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        public FileResult DownloadExcel()
        {
            var record = _db.Users.Where(x => x.UserTypeId == 1 || x.UserTypeId == 2).ToList();

            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "User Name";
            Sheet.Cells["B1"].Value = "Role";
            Sheet.Cells["C1"].Value = "Date of registration";
            Sheet.Cells["D1"].Value = "User Type";
            Sheet.Cells["E1"].Value = "Postal code";
            Sheet.Cells["F1"].Value = "Phone";
            Sheet.Cells["G1"].Value = "Status";
            int row = 2;
            foreach (var item in record)
            {
                Sheet.Cells[String.Format("A{0}", row)].Value = item.FirstName + " " + item.LastName;
                Sheet.Cells[String.Format("B{0}", row)].Value = " ";
                Sheet.Cells[String.Format("C{0}", row)].Value = item.CreatedDate.ToShortDateString();
                if(item.UserTypeId == 1)
                {
                    Sheet.Cells[String.Format("D{0}", row)].Value = "Customer";
                }
                if (item.UserTypeId == 2)
                {
                    Sheet.Cells[String.Format("D{0}", row)].Value = "Service provider";
                }
                else
                {
                    Sheet.Cells[String.Format("D{0}", row)].Value = " ";
                }
                Sheet.Cells[String.Format("E{0}", row)].Value = item.ZipCode;
                Sheet.Cells[String.Format("F{0}", row)].Value = item.Mobile;
                Sheet.Cells[String.Format("G{0}", row)].Value = "Active";
                row++;
            }

            Sheet.Cells["A:AZ"].AutoFitColumns();
            using (MemoryStream stream = new MemoryStream())
            {
                Ep.SaveAs(stream);
                return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "AdminUserData.xlsx");
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
