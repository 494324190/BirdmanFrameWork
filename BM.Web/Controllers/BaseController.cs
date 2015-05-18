using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using BM.IBLL;
using BM.Models;
using BM.Common.FileOperate;
using BM.Common.Web;
using BM.Common.StringOperate;

namespace BM.Web.Controllers
{
    public class BaseController : Controller
    {
        [Dependency]
        public ICommonBLL<tb_Users> bll { get; set; }
        public int isExistence()
        {
            tb_Users u = new tb_Users();
            string para = Request.Form["para"];
            if (para.Contains("@"))
            {
                u = bll.getModel(p => p.Email == para);
                if (u == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                u = bll.getModel(p => p.UserName == para);
                if (u == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        }
        /// <summary>
        /// 登录
        /// </summary>
        public int Login(tb_Users u)
        {
            if (u != null)
            {
                Func<tb_Users, bool> func = p => p.UserName == u.UserName && p.Password == u.Password;
                tb_Users user = bll.getModel(func);
                if (user != null)
                {
                    Session.Add("User", user);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="u">用户信息</param>
        public int RegisterCommon(tb_Users u)
        {
            u.Id = Guid.NewGuid().ToString();
            u.RegisterDateTime = DateTime.Now;
            if (u != null)
            {
                if (bll.Save(u))
                {
                    sessionWrite(u);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
        public int SendEmail(string address)
        {
            string cod = Guid.NewGuid().ToString();
            tb_Email em = new tb_Email();
            em.Title = "验证码";
            em.SendAddress = address;
            em.ContentStr = "您的验证码是：" + cod;
            Email.Send(em);
            string md5Ency = Encryption.MD5(cod);
            //5分钟后过期
            Cookie.Write("emailKey", md5Ency, new TimeSpan(0, 5, 0));
            return 1;
        }
        public  tb_Users user()
        {
            if(Session["User"]!=null)
            {
                return Session["User"] as tb_Users;
            }
            return null;
        }
        public void sessionWrite(tb_Users u)
        {
            Session["User"] = u;
        }
    }

}