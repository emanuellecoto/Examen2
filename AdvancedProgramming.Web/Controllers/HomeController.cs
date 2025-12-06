using AdvancedProgramming.Models;
using AdvancedProgramming.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedProgramming.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        [LogActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //TransportationDevice device = new TransportationDevice();
            //device.GetTransportationDevice();
            ViewBag.Message = "Your application description page. TD No.: " + new TransportationDevice().GetTransportationDevice().Id;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}