using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transonline.Models.Authentication.Dto;
using Transonline.Models.Authentication;
using Transonline.Data;
using Transonline.Services;

namespace Transonline.Controllers.MVC
{
    public class LoginAdministratorController : Controller
    {

        private readonly TransonlineDbContext db = new TransonlineDbContext();

      
        public ActionResult Index()
        {
            if(Session["FriendlyEmail"] == null) {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "username,email,password")] LoginDto loginDto)
        {
            if(ModelState.IsValid)
            {
                Registration byUsername = db.Registration.FirstOrDefault(a => a.Username == loginDto.Username && a.Password == loginDto.password);
                if (byUsername!= null)
                {
                    Session["FriendlyEmail"] = Session.SessionID;
                    return RedirectToAction("Index","Home");
                }
                else if(byUsername==null)
                {
                    Registration byEmail = db.Registration.FirstOrDefault(a => a.Email == loginDto.Email && a.Password == loginDto.password);
                    if(byEmail!=null)
                    {
                        Session["FriendlyEmail"] = Session.SessionID;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View(loginDto);
        }

        [CustomAuthorization]
        public ActionResult Home()
        {
            return View();
        }
    }
}