using BM.Common.FileOperate;
using BM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BM.Web.Controllers
{
    public class ErrorController : BaseController
    {
        /// <summary>
        /// 错误页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SysErrorPage(tb_error er)
        {

            //  SysError(er, 2);
            //XML读取内容读取例子
            //List<string> a = Xml.Read(Server.MapPath("/log/error/t.xml"), "person", 1, "name");


            //XML创建只有根节点的例子
            //Xml.Write(Server.MapPath("/log/error/t.xml"),"root1");

            //新增节点例子
            //string[,] a=new string[2,2]{{"name","1"},{"ac","2"}};
            //Xml.Insert(Server.MapPath("/log/error/t.xml"), "root1","a", a,a);

            //删除节点的例子
            Xml.Delete(Server.MapPath("/log/error/t.xml"), "root1", "name", "1");
            return View();
        }
    }
}