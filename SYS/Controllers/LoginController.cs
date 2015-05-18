using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using BM.IBLL;
using BM.Models;

namespace SYS.Controllers
{
    public class LoginController : Controller
    {
        [Dependency]
        public ICommonBLL<tb_Users> icb_u { get; set; }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            string userName = Request.Form["UserName"]==null?"":Request.Form["UserName"];
            string password = Request.Form["Password"] == null ? "" : Request.Form["Password"];
            if(userName !="" && password !="")
            {
                if (icb_u.getModel(p => p.UserName == userName && p.Password == password) != null)
                {
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    return Redirect("/Login/Index?login=f"); 
                }
            }
            else
            {
                return Redirect("/Login/Index?login=f"); 
            }
        }
    }
}