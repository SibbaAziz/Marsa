using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Marsa.Authorization
{
    public class Authorize : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if((string)filterContext.HttpContext.Session["User"] == "sidiaziz" &&
               (string)filterContext.HttpContext.Session["Password"] == "sidiaziz123")
            {
                return;
            }

            return;

            filterContext.Result = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Home",
                        action = "Register",
                    }
                    ));
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}