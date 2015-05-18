using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Common.StringOperate
{
    /// <summary>
    /// 判断是否为空
    /// </summary>
    public  static class IsNull
    {
        //判断是否为空
        public static bool Null(string Str)
        {
            if (!String.IsNullOrEmpty(Str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
