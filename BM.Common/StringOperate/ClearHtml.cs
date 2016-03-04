using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BM.Common.StringOperate
{
    public static class HtmlOperate
    {
        /// <summary>  
        /// 清除文本中Html的标签  
        /// </summary>  
        /// <param name="Content"></param>  
        /// <returns></returns>  
        public static string ClearHtml(string htmlStr)
        {
            string returnStr = "";
            htmlStr = ReplaceHtml("&#[^>]*;", "", htmlStr);
            htmlStr = ReplaceHtml("</?marquee[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?object[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?param[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?embed[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?table[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml(" ", "", htmlStr);
            htmlStr = ReplaceHtml("</?tr[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?th[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?p[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?a[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?img[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?tbody[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?li[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?span[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?div[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?th[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?td[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?script[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("(javascript|jscript|vbscript|vbs):", "", htmlStr);
            htmlStr = ReplaceHtml("on(mouse|exit|error|click|key)", "", htmlStr);
            htmlStr = ReplaceHtml("<\\?xml[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("<\\/?[a-z]+:[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?font[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?b[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?u[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?i[^>]*>", "", htmlStr);
            htmlStr = ReplaceHtml("</?strong[^>]*>", "", htmlStr);
            returnStr = htmlStr.Replace(" ","").Replace("&nbsp;","").Replace("\r","").Replace("\n","");
            return returnStr;
        }
        /// <summary>  
        /// 清除文本中的Html标签  
        /// </summary>  
        /// <param name="patrn">要替换的标签正则表达式</param>  
        /// <param name="strRep">替换为的内容</param>  
        /// <param name="content">要替换的内容</param>  
        /// <returns></returns>  
        private static string ReplaceHtml(string patrn, string strRep, string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                content = "";
            }
            Regex rgEx = new Regex(patrn, RegexOptions.IgnoreCase);
            string strTxt = rgEx.Replace(content, strRep);
            return strTxt;
        }
    }
}
