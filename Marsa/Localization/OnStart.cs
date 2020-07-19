using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marsa.Localization
{
    public class OnStart : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var language = filterContext.HttpContext.Session["language"] as string; 
            if (string.IsNullOrEmpty(language) || language == "auto")
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
            base.OnActionExecuting(filterContext);
        }
    }
}