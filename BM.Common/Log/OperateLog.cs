using BM.Common.FileOperate;
using BM.IBLL;
using BM.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BM.Common.Log
{
    public class OperateLog
    {
        [Dependency]
        public ICommonBLL<tb_OperateLog> cbo { get; set; }
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
            }
            string content = "OperateType：" + ot + "     IP：" + ol.IP;
            Txt.Write(path, content, ol.DateTime.ToString("yyyyMMdd") + "------" + Guid.NewGuid());
        }
        private void saveOperateLogDB(tb_OperateLog ol)
        {
            cbo.Save(ol);
        }
        private enum OperateType
        {
            增加 = 0,
            删除 = 1,
            修改 = 2,
        }
    }
}
