using BM.Common.FileOperate;
using System;
using System.Web;
using BM.BLL;
using BM.Common.Web;
using BM.Models;

namespace BM.Common.Log
{
    public class OperateLog
    {
        private OperateLogBLL cbo = new OperateLogBLL();
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="er">错误实例</param>
        /// <param name="savePath">存储位置（1：存储在txt文件中 2：存储在数据库中 3：存储在数据库和文件中）</param>
        /// <returns></returns>
        public void Operate(tb_OperateLog ol, int savePath = 1)
        {
            if (ol != null)
            {
                switch (savePath)
                {
                    case 1:
                        saveOperateLogFile(ol, "operate");
                        break;
                    case 2:
                        saveOperateLogDB(ol);
                        break;
                    case 3:
                        saveOperateLogDB(ol);
                        saveOperateLogFile(ol, "operate");
                        break;
                }
            }
        }
        private void saveOperateLogFile(tb_OperateLog ol, string pathFile)
        {
            string path = HttpContext.Current.Server.MapPath("/log/" + pathFile + "/");
            string ot = "";
            switch (ol.OperateType)
            {
                case 0:
                    ot = OperateType.删除.ToString();
                    break;
                case 1:
                    ot = OperateType.修改.ToString();
                    break;
                case 2:
                    ot = OperateType.增加.ToString();
                    break;
                case 3:
                    ot = OperateType.创建数据库.ToString();
                    break;
                case 4:
                    ot = OperateType.登录.ToString();
                    break;
            }
            string content = "OperateType：" + ot + "     IP：" + ol.Ip;
            Txt.Write(path, content, ol.DateTime.ToString("yyyyMMdd") + "------" + Guid.NewGuid());
        }
        private void saveOperateLogDB(tb_OperateLog ol)
        {
            try
            {
                cbo.Save(ol);
            }
            catch (Exception e)
            {

                ErrorLog errorLog = new ErrorLog();
                tb_ErrorLog error = new tb_ErrorLog();
                error.DateTime = DateTime.Now;
                error.ErrorName = e.Message;
                error.Ip = Ip.getIp();
                error.OperateTyep = 0;
                error.ErrorContent = e.Message;

                errorLog.SaveError(error, 3);
            }
        }
        public enum OperateType
        {
            增加 = 0,
            删除 = 1,
            修改 = 2,
            创建数据库 = 3,
            登录 = 4,
            获取列表 = 5,
            获取一个实体 = 6
        }

    }
}
