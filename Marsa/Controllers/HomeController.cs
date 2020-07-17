using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }


        public ActionResult Login(string name, string password)
        {
            Session["User"] = name;
            Session["Password"] = password;

            if(name == "sidiaziz" && password == "sidiaziz123")
            {
                return View("Index");
            }

            return View("Register");
        }

        [Marsa.Authorization.Authorize]
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