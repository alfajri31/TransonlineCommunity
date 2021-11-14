using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transonline.Services;

namespace Transonline.Controllers
{
    public class HomeController : Controller
    {
        [CustomAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorization]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [CustomAuthorization]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        
    }
}