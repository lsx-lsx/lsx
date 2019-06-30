using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseManager.Filters
{
    public class RequireAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session != null && filterContext.HttpContext.Session["user"] != null && filterContext.HttpContext.Request.Cookies["user"] != null)
            {
                var user = filterContext.HttpContext.Session["user"].ToString();
                if (!string.IsNullOrWhiteSpace(user))
                {
                    return;
                }

                var cookie = filterContext.HttpContext.Request.Cookies["user"].ToString();
                if (!string.IsNullOrWhiteSpace(cookie))
                {
                    return;
                }else
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                }

            }
        }
    }
}