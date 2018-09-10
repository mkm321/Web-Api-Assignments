using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternAssignmentUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginValidation()
        {
            int id = Convert.ToInt16(Request.Params["loginId"]);
            string password = Request.Params["loginPassword"];
            if (id == 999 && password.Equals("999"))
            {
                return RedirectToAction("LoggedInAsUser");
            }
            else if (id == 1 && password.Equals("1"))
            {
                return RedirectToAction("LoggedInAsAdmin");
            }
            else
            {
                TempData["Error"] = "Invalid ID or Password!!!";
                return RedirectToAction("Index");
            }
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
        public ActionResult LoggedInAsUser()
        {
            ViewBag.Message = "User";
            return View();
        }
        public ActionResult LoggedInAsAdmin()
        {
            ViewBag.Message = "Admin";
            return View();
        }
    }
}