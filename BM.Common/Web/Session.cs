using System.Web;
namespace BM.Common.Web
{
    public class Session<K>
    {
        /// <summary>
        /// 写入session
        /// <param name="key">session名称</param>
        /// <param name="value">session值</param>
        /// </summary>
        public static void Write(string key, K value)
        {
            HttpContext.Current.Session[key] = value;
        }
        /// <summary>
        /// 读取session
        /// </summary>
        /// <param name="key">session名称</param>
        /// <returns></returns>
        public static object Read(string key)
        {
            return HttpContext.Current.Session[key] ;
        }
        /// <summary>
        /// 清除所有session
        /// </summary>
        public static void Clear()
        {
            HttpContext.Current.Session.Contents.Clear();
        }
        /// <summary>
        /// 清除指定的session
        /// </summary>
        /// <param name="key"></param>
        public static void Clear(string key)
        {
            HttpContext.Current.Session.Contents.Remove(key);
        }
    }
}