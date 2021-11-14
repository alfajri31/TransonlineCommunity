using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Transonline.Controllers.MVC
{
    public class LogoutController : Controller
    {
        [HttpPost]
        public ActionResult Index()
        {
            Session["FriendlyEmail"] = null;
            return RedirectToAction("Index", "Home");
        }

    }
}