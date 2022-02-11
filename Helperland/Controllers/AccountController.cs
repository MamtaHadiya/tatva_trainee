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
                    ModelState.Clear();
                    return View("Success");
                }
                else
                {
                    ViewBag.error = "Invalid Account";
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Login");
        }
        public IActionResult Forgotpass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Forgotpass(String email)
        {
            var data = (from userlist in _db.Users
                        where userlist.Email == email
                        select new
                        {
                            userlist.UserId,
                            userlist.FirstName,
                            userlist.Email,
                            userlist.Password

                        }).ToList();
            if (data.FirstOrDefault() != null)
            {
                ViewBag.Data = email;
                return View("UpdatePass");
            }
            else
            {
                ViewBag.error = "Invalid Email";
                return View();
            }
        }

        [HttpPost]
        public IActionResult UpdatePass(string Email, string Password, string Cfrmpwd)
        {
            if (Password != null && Cfrmpwd != null && Password.Equals(Cfrmpwd))
            {
                User user = new User();
                var data = (from userlist in _db.Users
                            where userlist.Email == Email
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
                    user.Password = Password;

                    _db.Users.Update(user);
                    _db.SaveChanges();
                    return View("Login");
                }
                return View("Index", "Helperland");
            }
            return RedirectToAction("Index", "Helperland");
        }
    }
}
