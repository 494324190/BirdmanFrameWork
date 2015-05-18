using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BM.Web.Filter
{
    /// <summary>
    /// 权限过滤器（contorler）
    /// </summary>
    public class LoginFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["User"]==null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");  
            }
        }
    }
}