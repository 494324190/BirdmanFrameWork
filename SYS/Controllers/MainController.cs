using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BM.IBLL;
using BM.Models;
using Microsoft.Practices.Unity;
using BM.Common.StringOperate;

namespace SYS.Controllers
{
    public class MainController : Controller
    {
        [Dependency]
        public ICommonBLL<tb_BlogType> ibt { get; set; }
        [Dependency]
        public ICommonBLL<tb_UserGroup> iug { get; set; }
        [Dependency]
        public IBlogTypeBLL btb { get; set; }
        /// <summary>
        /// 管理主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }
        /// <summary>
        /// 综合管理---基础信息管理
        /// </summary>
        /// <returns></returns>
        public ActionResult BaseManage()
        {
            getPageCount();
            return View();
        }

        
        #region 博客类型管理
        /// <summary>
        /// 保存博客类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int BlogTypeSave(string Type)
        {

            if (ibt.getModel(p => p.Type == Type) != null)
            {
                return -1;//已存在
            }
            if (IsNull.Null(Type))
            {
                tb_BlogType bt = new tb_BlogType();
                bt.Type = Type;
                getPageCount();
                return ibt.Save(bt) == true ? 1 : 0;
            }

            return 0;//其他错误
        }
        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="removeId"></param>
        /// <returns></returns>
        public int DeleteBlogType(int removeId)
        {
            try
            {
                getPageCount();
                return btb.deleteBlogType(removeId);
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// 修改博客类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public int EditBlogType(string type, int ID)
        {
            tb_BlogType btModel = new tb_BlogType();
            btModel = ibt.getModel(p => p.Type == type);
            if (btModel != null && btModel.ID != ID)
            {
                return -1;//已存在
            }
            if (IsNull.Null(type))
            {
                tb_BlogType bt = new tb_BlogType();
                bt = ibt.getModel(p => p.ID == ID);
                bt.Type = type;
                getPageCount();
                return ibt.Edit(bt) == true ? 1 : 0;
            }

            return 0;//其他错误
        }
        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="nextPage"></param>
        /// <param name="pageRowCount"></param>
        /// <returns></returns>
        public JsonResult GetBlogType(int nextPage, int pageRowCount)
        {
            List<tb_BlogType> list = ibt.pageByWhere(p => p.ID != 0, p => p.ID, nextPage, pageRowCount);
            var json = new
            {
                page = nextPage,
                rowCount = pageRowCount,
                data = (from e in list
                        select new
                        {
                            ID = e.ID,
                            Type = e.Type
                        }).ToArray()
            };
            return Json(json, "text/html", JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 用户组管理
        /// <summary>
        /// 保存用户组
        /// </summary>
        /// <param name="GroupName"></param>
        /// <returns></returns>
        public int UserGroupSave(string GroupName)
        {
            if (IsNull.Null(GroupName))
            {
                if (iug.getModel(p => p.GroupName == GroupName) != null)
                {
                    return -1;//已存在
                }
                tb_UserGroup ug = new tb_UserGroup();
                ug.GroupName = GroupName;
                getPageCount();
                return iug.Save(ug) == true ? 1 : 0;
            }
            return 0;//其他错误
        }
        /// <summary>
        /// 修改用户组
        /// </summary>
        /// <param name="ug"></param>
        /// <returns></returns>
        public int EditUserGroup(tb_UserGroup ug)
        {
            if (ug != null)
            {
                if (iug.getModel(p => p.GroupName == ug.GroupName && p.ID != ug.ID) != null)
                {
                    return -1;//已存在
                }
                return iug.Edit(ug) == true ? 1 : 0;
            }
            return 0;//其他错误
        }
        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <returns></returns>
        public int DeleteUserGroup(int removeId)
        {
            tb_UserGroup ug = new tb_UserGroup();
            ug = iug.getModel(p => p.ID == removeId);
            ug.isDelete = 0;//删除状态
            getPageCount();
            return iug.Edit(ug)==true ? 1 : 0;
        }
        /// <summary>
        /// 获取分组和分页
        /// </summary>
        /// <param name="nextPage"></param>
        /// <param name="pageRowCount"></param>
        /// <returns></returns>
        public JsonResult GetUserGroup(int nextPage, int pageRowCount)
        {
            List<tb_UserGroup> list = iug.pageByWhere(p => p.ID != 0, p => p.ID, nextPage, pageRowCount);
            var json = new
            {
                page = nextPage,
                rowCount = pageRowCount,
                data = (from e in list
                        select new
                        {
                            ID = e.ID,
                            GroupName = e.GroupName,
                            isDelete=e.isDelete==1?"否":"是"
                        }).ToArray()
            };
            return Json(json, "text/html", JsonRequestBehavior.AllowGet);
        }
        #endregion
        /// <summary>
        /// 获取总页码
        /// </summary>
        private void getPageCount()
        {
            ViewData["BlogType"] = ibt.pageByWhere(p => p.ID != 0, p => p.ID, 1, 5);
            int m = ibt.getList(p => p.ID != 0).Count % 5;
            int blogTypeRow=ibt.getList(p => p.ID != 0).Count;
            int pageCount = blogTypeRow / 5;
            if (m == 0)
            {
                ViewData["TypePage"] = pageCount;
            }
            else
            {
                ViewData["TypePage"] = pageCount + 1;
            }
            int n = iug.getList(p => p.ID != 0).Count % 5;
            int groupRow=iug.getList(p => p.ID != 0).Count;
            int pageCountGroup = groupRow / 5;
            if (n == 0)
            {
                ViewData["userGroupPage"] = pageCountGroup;
            }
            else
            {
                ViewData["userGroupPage"] = pageCountGroup + 1;
            }
        }
    }
}