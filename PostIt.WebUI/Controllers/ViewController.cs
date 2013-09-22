using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostIt.WebUI.Controllers
{
    public class ViewController : Controller
    {
        //
        // GET: /View/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddFromParams(
            string userLogin,
            string info)
        {
            ViewBag.ul = userLogin;
            ViewBag.info = info;
            return View("Add");
        }

    }
}
