using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BM.IBLL;
using Microsoft.Practices.Unity;
using BM.Models;
using BM.Common;


using BM.Common.Web;namespace BM.Web.Controllers
{
    public class OtherController : BaseController
    {
        [Dependency]
        public ICommonBLL<tb_Users> icb { get; set; }
        /// <summary>
        /// 修改密码第一步
        /// </summary>
        /// <returns></returns>
        public ActionResult FindPwd()
        {
            return View();
        }
        /// <summary>
        /// 修改密码第二步
        /// </summary>
        /// <returns></returns>
        public ActionResult Cord()
        {
            return View();
        }
        /// <summary>
        /// 修改密码第三步
        /// </summary>
        /// <returns></returns>
        public ActionResult EditPwd()
        {
            return View();
        }
        [HttpPost]
        public int EditPwd(string newPwd)
        {
            string email = HttpUtility.UrlDecode(Cookie.Read("email"));
            tb_Users u =icb.getModel(p=>p.Email==email);
            u.Password=newPwd;
            if(icb.Edit(u))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}