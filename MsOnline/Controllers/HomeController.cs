using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MsOnline.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This app an super epic online experience for you Minesweeper freaks";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Sike you may not contact us";

            return View();
        }
    }
}