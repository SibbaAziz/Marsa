using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
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

        public ActionResult SetLanguage(string language)
        {
            

            if(language == "auto")
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.InstalledUICulture;
            }
            else
            {
                var ar = new System.Globalization.CultureInfo(language);
                System.Threading.Thread.CurrentThread.CurrentCulture = ar;
                System.Threading.Thread.CurrentThread.CurrentUICulture = ar;

            }

            return View("Index");
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