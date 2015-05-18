using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using BM.Core;
using BM.Models;

namespace BM.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new UnityContainer();
            DependencyRegisterType.Container_Sys(ref container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
        protected void Application_Error()
        {
            tb_error error = new tb_error();
            Exception objErr = Server.GetLastError().GetBaseException();
            int count = Request.Url.ToString().Split('/').Count();
            error.ErrorAction = "/" + Request.Url.ToString().Split('/')[count - 2] + "/" + Request.Url.ToString().Split('/')[count - 1];
            error.ErrorDate = DateTime.Now;
            error.ErrorName = objErr.Source;
            error.ErrorMessage = objErr.Message;
            error.ID = Guid.NewGuid().ToString();
            Server.ClearError();
            var routes = new RouteValueDictionary();
            //routes.Add("er", error);
            //Response.RedirectToRoute("ErrorPage", error);
        }
    }
}
