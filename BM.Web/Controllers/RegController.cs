using BM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using BM.IBLL;

namespace BM.Web.Controllers
{
    public class RegController : BaseController
    {
        [Dependency]
        public ICommonBLL<tb_Users> icb { get; set; }
        #region 基本信息注册步骤
        /// <summary>
        /// 注册第一步（必填）
        /// </summary>
        /// <returns></returns>
        public ActionResult RegUp()
        {
            return View();
        }
        /// <summary>
        /// 注册第二步（必填）
        /// </summary>
        /// <returns></returns>
        public ActionResult RegEmail()
        {
            return View();
        }
        /// <summary>
        /// 注册第三步（必填）
        /// </summary>
        /// <returns></returns>
        public ActionResult RegEmailCode()
        {
            return View();
        }
        #endregion
        #region 非必填数据注册步骤
        /// <summary>
        /// 注册第四步（非必填）
        /// </summary>
        /// <returns></returns>
        public ActionResult RegInfo()
        {
            return View();
        }
        /// <summary>
        /// 完善信息数据
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        [HttpPost]
        public int RegInfo(tb_Users u)
        {
            string userId = user().Id;
            //string userId = "0cea68a9-c432-49c4-9d43-b669cb5f4bb5";
            tb_Users _u = new tb_Users();
            _u = icb.getModel(p => p.Id == userId);
            if (u != null)
            {
                _u.MPhone = u.MPhone;
                _u.Name = u.Name;
                _u.Sex = u.Sex;
                _u.Birthday = u.Birthday;
                if (icb.Edit(_u))
                {
                    return 1;
                }
            }
            return 0;
        }
        public ActionResult Recommend()
        {
            return View();
        }
        #endregion
    }
}