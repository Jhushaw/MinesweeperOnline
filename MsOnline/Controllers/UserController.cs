using MsOnline.Models;
using MsOnline.Services.Business;
using MsOnline.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsOnline.Controllers
{
    //Stanley Backlund & Jacob Hushaw
    //26 January 2020
    //CST-247
    //This is my own code
    public class UserController : Controller
    {
        private UserBusinessService ubs = new UserBusinessService();
        
        public ActionResult Log()
        {
            return View("Login");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }

        public ActionResult Reg()
        {
            return View("Register");
        }
        [LoginAuthorization]
        public ActionResult Profile()
        {
            User returnedUser = (User) Session["user"];
            return View("Profile", returnedUser);
        }
        //////////////POSTS/////////////////
        [HttpPost]
        public ActionResult Login(User user)
        {
            msLogger.GetInstance().Info("Entering UserController.Login with info: " + user.username);
            int id = ubs.Authenticate(user);
            
            if (id != -1)
            {
               User returnedUser = ubs.findUserInfo(id);
               Session["user"] = returnedUser;
                msLogger.GetInstance().Info("Exiting UserController.Login with Successful login");
                return View("Profile", returnedUser);

            }
            else
            {
                Session.Clear();
                ViewBag.succdMSG = "Failed to login";
                msLogger.GetInstance().Info("Exiting UserController.Login with Failed login");

                return View("login");
            }
           
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            msLogger.GetInstance().Info("Entering UserController.Register with info: " + user.ToString());

            if (ubs.Register(user))
            {
                msLogger.GetInstance().Info("exiting UserController.Register with successful Registration");

                ViewBag.succdMSG = "Successfully created an account!";
                return View("login");
            }
            else
            {
                msLogger.GetInstance().Info("exiting UserController.Register with Failed Registration");

                ViewBag.failedMSG = "Failed to create account";
                return View("Register");
            }

        }

    }
}
