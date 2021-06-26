using MsOnline.Models;
using MsOnline.Services.Business;
using System;
using System.Web.Mvc;

namespace MsOnline.Controllers
{
    internal class LoginAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
    {
        //Custom filter for page authorization
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            UserBusinessService ubs = new UserBusinessService();
            //grab user object from session
            User usr = (User)filterContext.HttpContext.Session["user"];
            int status = -1;
            if (usr != null)
            {
                //check if session still valid
                status = ubs.Authenticate(usr);
            }

            if (status != -1)
            {
                //success
            }
            else
            {
                //failure
                filterContext.Result = new RedirectResult("/login");
            }

        }
    }
}