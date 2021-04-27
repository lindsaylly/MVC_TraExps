using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLibrary;
using static DataLibrary.BusinessLogic.CustomerProcessor;
using static DataLibrary.BusinessLogic.CountryProcessor;
using static DataLibrary.BusinessLogic.ProvinceProcessor;
using static DataLibrary.BusinessLogic.UserProcessor;
using DataLibrary.Models;
using Scrypt;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}