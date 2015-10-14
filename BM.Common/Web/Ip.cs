using System.Web;

namespace BM.Common.Web
{
    /// <summary>
    /// 获取Ip
    /// </summary>
    public class Ip
    {
        public static string getIp()
        {
            return HttpContext.Current.Request.UserHostAddress; 
        }
    }
}