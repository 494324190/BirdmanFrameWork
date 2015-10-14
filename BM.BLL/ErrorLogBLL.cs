using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BM.BLL
{
    /// <summary>
    /// 不进行注入
    /// </summary>
    public class ErrorLogBLL
    {
        public void Save(Models.tb_ErrorLog er)
        {
            throw new NotImplementedException();
        }
    }
}
