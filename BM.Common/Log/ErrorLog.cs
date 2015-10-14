using BM.Common.FileOperate;
using System;
using System.Web;
using BM.BLL;
using BM.Models;

namespace BM.Common.Log
{
    public class ErrorLog
    {
        private ErrorLogBLL cb = new ErrorLogBLL();
        /// <summary>
        /// 错误页面
        /// </summary>
        /// <param name="er">错误实例</param>
        /// <param name="savePath">存储位置（1：存储在txt文件中 2：存储在数据库中 3：存储在数据库和文件中）</param>
        /// <returns></returns>
        public void SaveError(tb_ErrorLog er, int savePath = 1)
        {
            if (er != null)
            {
                switch (savePath)
                {
                    case 1:
                        saveErrorLogFile(er, "error");
                        break;
                    case 2:
                        saveErrorLogDB(er);
                        break;
                    case 3:
                        saveErrorLogDB(er);
                        saveErrorLogFile(er, "error");
                        break;
                }
            }
        }
        /// <summary>
        /// 存储到文件系统
        /// </summary>
        /// <param name="er"></param>
        private void saveErrorLogFile(tb_ErrorLog er, string pathFile)
        {
            string path = HttpContext.Current.Server.MapPath("/log/" + pathFile + "/");
            string content = "errorName：" + er.ErrorName + "     errorMessage：" + er.ErrorContent;
            Txt.Write(path, content, er.DateTime.ToString("yyyyMMdd") + "------" + Guid.NewGuid());
        }
        /// <summary>
        /// 存储到数据库目录
        /// </summary>
        /// <param name="er"></param>
        private void saveErrorLogDB(tb_ErrorLog er)
        {
            cb.Save(er);
        }
    }
}
