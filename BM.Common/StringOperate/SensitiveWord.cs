using BM.IBLL;
using BM.Models;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Common.StringOperate
{
    /// <summary>
    /// 敏感词汇
    /// </summary>
    /// <备注>
    /// 此处不知什么原因ICommonBLL 不能是静态的，
    /// 如果将其设置为静态的，编译时没有错误，但是运行时或出现错误 cb为null
    /// 有知道什么原因的或解决办法，请告诉我，QQ：494324190
    /// </备注>
    public class SensitiveWord
    {
        [Dependency]
        public  ICommonBLL<tb_SensitiveWord> cb { get; set; }
        
        /// <summary>
        /// 将字符串里的敏感词汇替换成**
        /// </summary>
        /// <param name="wordStr">原始字符串</param>
        /// <returns></returns>
        public  string Replace(string wordStr)
        {
            List<tb_SensitiveWord> list = cb.getList(null); 
            for (int i = 0; i < list.Count; i++)
            {
                if (wordStr.Contains(list[i].sensitive))
                {
                    wordStr.Replace(list[i].sensitive, "**");
                }
            }
            return wordStr;
        }
        /// <summary>
        /// 判断是否存在敏感词汇
        /// </summary>
        /// <param name="wordStr"></param>
        /// <returns></returns>
        public  bool Sensitive(string wordStr)
        {
            List<tb_SensitiveWord> list = cb.getList(null);
            for (int i = 0; i < list.Count; i++)
            {
                if (wordStr.Contains(list[i].sensitive))
                {
                    i = list.Count;
                    return true;
                }
            }
            return false;
        }
    }
}
