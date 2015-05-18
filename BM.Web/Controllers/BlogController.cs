using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using BM.IBLL;
using BM.Models;
using BM.Common.StringOperate;
using BM.Web.Filter;

namespace BM.Web.Controllers
{
    [LoginFilter]
    public class BlogController : BaseController
    {
        [Dependency]
        public ICommonBLL<tb_SmallEssay> icb { get; set; }
        [Dependency]
        public ISmallEssayBLL iseb { get; set; }

        public ActionResult Main()
        {
            if (user() != null)
            {
                List<main_getEssay_Result> list = iseb.Get(user().Id, 10, 1);
                string[] Count=new string[3]{"0","0","0"};
                //个人主页好友发布信息
                ViewData["Essay"] = list;
                //左上部数字统计
                ViewData["Count"] = icb.getList(p => p.UserID == user().Id).Count;
                
                return View();
            }
            return null;
        }
        public ActionResult MyCenter()
        {
            return View();
        }
        [HttpGet]
        public JsonResult MainData()
        {
            int pageNum = 2;
            int pageRowCount = 10;
            if (Request.QueryString["pageNum"] != null)
            {
                pageNum = int.Parse(Request.QueryString["pageNum"]);
            }
            if (Request.QueryString["pageRowCount"] != null)
            {
                pageRowCount = int.Parse(Request.QueryString["pageRowCount"]);
            }
            if (user() != null)
            {
                List<main_getEssay_Result> list = iseb.Get(user().Id, pageRowCount, pageNum);
                var json = new 
                {
                    data = (from e in list
                            select new
                            {
                                C_Content = e.C_Content,
                                DateTime = e.DateTime,
                                Id=e.Id,
                                Img=e.Img,
                                ImgUrlArray = e.ImgUrlArray,
                                UserID = e.UserID,
                                UserName = e.UserName
                            }).ToArray()
                };
                return Json(json, "text/html", JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        [HttpPost]
        public int Essay(tb_SmallEssay se)
        {
            if (se != null)
            {
                se.DateTime = DateTime.Now;
                se.ImgUrlArray = "";
                se.UserID = user().Id;
                se.Id = Guid.NewGuid().ToString();
                EssayId.id(se.Id);
                if (icb.Save(se))
                {
                    return 1;
                }
            }
            return 0;
        }
        [HttpGet]
        public JsonResult Essay()
        {
            tb_SmallEssay se = icb.getModel(p => p.UserID == user().Id && p.Id == EssayId.id());
            var json = new tb_SmallEssay()
            {
                Id = se.Id,
                C_Content = se.C_Content,
                DateTime = se.DateTime,
                ImgUrlArray = se.ImgUrlArray,
                UserID = se.UserID
            };

            return Json(json, "text/html", JsonRequestBehavior.AllowGet);
        }
    }
    static class EssayId
    {
        static string _id = string.Empty;
        public static void id(string id)
        {
            _id = id;
        }
        public static string id()
        {
            return _id;
        }
    }

}