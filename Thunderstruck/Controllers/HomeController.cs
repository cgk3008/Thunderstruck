using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thunderstruck.Models;

namespace Thunderstruck.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ThunderstruckViewModel vm = new ThunderstruckViewModel();

            vm.HandleRequest();

            return View(vm);
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