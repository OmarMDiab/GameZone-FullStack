﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gamezone.Models;

namespace Gamezone.Controllers
{
    public class loginController : Controller
    {
        private GamesDataEntities2 db = new GamesDataEntities2();
        string role = Constants.RoleNames.Admin;
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.user_name == model.user_name && u.user_password == model.user_password);

                if (user != null)
                {
                    // Authenticate the user 
                   

                    return RedirectToAction("Index", "Home"); // Redirect to the home page after successful login
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }

            return View(model);
        }
    }
}
