using Helperland.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Helperland.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;

namespace Helperland.Controllers
{
    public class AccountController : Controller
    {
        private readonly Data.ApplicationDbContext _db;

        public object Session { get; private set; }

        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult RegisterCostomer()
        {
            return View();
        }

            [HttpPost]
        public IActionResult CustomerSignup(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserTypeId = 1;
                user.IsRegisteredUser = true;
                user.WorksWithPets = true;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = 1;
                user.IsApproved = true;
                user.IsActive = true;
                user.IsDeleted = true;
                _db.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Login", "Account");

            }
            else
            {
                ViewBag.Message = "Requirement Doesn't Matching";
                return RedirectToAction("Login");
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCostomer(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserTypeId = 1;
                user.IsRegisteredUser = true;
                user.WorksWithPets = true;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = 1;
                user.IsApproved = true;
                user.IsActive = true;
                user.IsDeleted = true;
                _db.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index", "Helperland");

            }
            return View(user);
        }

        public IActionResult ProviderSignup()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ProviderSignup(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserTypeId = 2;
                user.IsRegisteredUser = true;
                user.WorksWithPets = true;
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = 2;
                user.IsApproved = true;
                user.IsActive = true;
                user.IsDeleted = true;
                user.ZipCode = "395010";
                _db.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index", "Helperland");

            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Loginclass objUser)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in _db.Users
                               where userlist.Email == objUser.Username && userlist.Password == objUser.Password
                               select new
                               {
                                   userlist.UserId,
                                   userlist.FirstName,
                                   userlist.Email,
                                   userlist.Password

                               }).ToList();
                if (details.FirstOrDefault() != null)
                {
                    //Session["username"] = objUser.Username.ToString();
                    HttpContext.Session.SetString("username", objUser.Username);
                    HttpContext.Session.SetInt32("userid", details.Select(x => x.UserId).FirstOrDefault());
                    ModelState.Clear();
                    return View("Success");
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    ModelState.Clear();
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("userid");
            return RedirectToAction("Login");
        }
        public IActionResult Forgotpass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forgotpass(String email)
        {
            var user = _db.Users.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (user != null)
            {
                var token = Guid.NewGuid().ToString();
                var UserId = user.UserId;
                var passwordResetLink = Url.Action("UpdatePass", "Account", new { ID = UserId, Email = email, Token = token }, Request.Scheme);
                var subject = "Password Reset Request";
                var body = "Hi " + user.FirstName + ", <br/> you recently requested to reset your password for your account." +
                    "Click the link below to reset it. " +
                    "<br/><br/><a href='" + passwordResetLink + "'>Link</a><br/><br/>" +
                    "Thankyou";
                SendEmail(user.Email, body, subject);
                ViewBag.error = "Reset password link has been sent to your email id.";

            }
            else
            {
                ViewBag.error = "Invalid Email";
                return View();
            }
            return View();
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


        //[HttpPost]
        //public IActionResult Forgotpass(String email)
        //{
        //    var data = (from userlist in _db.Users
        //                where userlist.Email == email
        //                select new
        //                {
        //                    userlist.UserId,
        //                    userlist.FirstName,
        //                    userlist.Email,
        //                    userlist.Password

        //                }).ToList();
        //    if (data.FirstOrDefault() != null)
        //    {
        //        ViewBag.Data = email;
        //        return View("UpdatePass");
        //    }
        //    else
        //    {
        //        ViewBag.error = "Invalid Email";
        //        return View();
        //    }
        //}

        public IActionResult UpdatePass(int ID, string Email, string Token)
        {
            if(Email == null || Token == null)
            {
                ViewBag.error = "Invalid Password reset token";
            }
            ViewBag.Email = Email;
            return View();
        }

        [HttpPost]
        public IActionResult UpdatePass(ChangePassClass objuser)
        {
            ViewBag.Email = objuser.Email;
            if (ModelState.IsValid)
            {
                User user = new User();
                var data = (from userlist in _db.Users
                            where userlist.Email == objuser.Email
                            select new
                            {
                                userlist.UserId,
                                userlist.FirstName,
                                userlist.LastName,
                                userlist.Email,
                                userlist.Mobile,
                                userlist.Password

                            }).ToList();
                if (data.FirstOrDefault() != null)
                {
                    user.UserId = data[0].UserId;
                    user.Email = data[0].Email;
                    user.FirstName = data[0].FirstName;
                    user.LastName = data[0].LastName;
                    user.Mobile = data[0].Mobile;
                    user.UserTypeId = 2;
                    user.IsRegisteredUser = true;
                    user.WorksWithPets = true;
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedDate = DateTime.Now;
                    user.ModifiedBy = 2;
                    user.IsApproved = true;
                    user.IsActive = true;
                    user.IsDeleted = true;
                    user.Password = objuser.Password;

                    _db.Users.Update(user);
                    _db.SaveChanges();
                    return View("Login");
                }
                return RedirectToAction("Index", "Helperland");
            }
            return View();
        }
    }
}
