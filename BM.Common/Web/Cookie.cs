using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BM.Common.Web
{
    public class Cookie
    {
        /// <summary>
        /// 创建cookie
        /// </summary>
        /// <param name="key">cookie名称</param>
        /// <param name="value">cookie值</param>
        /// <param name="ts">过期时间</param>
        public static void Write(string key, string value, TimeSpan ts)
        {
            HttpCookie cookie = new HttpCookie(key, value);//初使化并设置Cookie的名称
            DateTime dt = DateTime.Now;
            cookie.Expires = dt.Add(ts);//设置过期时间
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        /// <summary>
        /// 读取cookie
        /// </summary>
        /// <param name="cookeName">读取的cookie的名称</param>
        /// <returns></returns>
        public static string Read(string cookeName)
        {
            string value = "";
            if (HttpContext.Current.Request.Cookies[cookeName] != null)
            {
                value = HttpContext.Current.Request.Cookies[cookeName].Value;
            }
            return value;
        }
        /// <summary>
        /// 移除cookie
        /// </summary>
        /// <param name="cookeName">移除的cookie的名称</param>
        public static void Remove(string cookeName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookeName];
            TimeSpan ts = new TimeSpan(-1, 0, 0);
            cookie.Expires = DateTime.Now.Add(ts);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

    }
}
