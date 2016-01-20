using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFS_CI_WEB_Razor.Models;

namespace TFS_CI_WEB_Razor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ClickSubmitSuma(ModelSuma Sumamodel) {

            ViewBag.ResultadoSuma = (Sumamodel.NumeroA + Sumamodel.NumeroB).ToString();
            return View("ViewResultSuma");
        }
    }
}
