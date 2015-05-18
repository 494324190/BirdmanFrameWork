using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BM.Common.StringOperate;

namespace BM.Common.FileOperate
{
    /// <summary>
    /// 文本操作公共类
    /// </summary>
    /// <creat>zg 2015/02/05</creat>
    public static class Txt
    {
        /// <summary>
        /// 使用FileStream类进行文件的读取，并转换成char数组
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>char[]</returns>
        public static char[] Read_Char(string filePath)
        {
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            try
            {
                if (!IsNull.Null(filePath))
                {
                    return charData;
                }
                FileStream file = new FileStream(filePath, FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 100);
                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, byData.Length, charData, 0);
                file.Close();
                return charData;
            }
            catch (Exception e)
            {
                return charData;
                throw e;
            }
        }
        /// <summary>
        /// 使用StreamReader类进行文件的读取,返回String
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>string</returns>
        public static string Read_String(string filePath)
        {
            try
            {
                if (!IsNull.Null(filePath))
                {
                    return null;
                }
                StreamReader sr = new StreamReader(filePath, Encoding.Default);
                StringBuilder sb = new StringBuilder();
                foreach (var item in sr.ReadLine())
                {
                    sb.Append(item.ToString());
                }
                return sb.ToString();
            }
            catch (Exception e)
            {
                return null;
                throw e;
            }
        }
        /// <summary>
        /// 写入文本文件并保存
        /// </summary>
        /// <param name="filePath">保存路径(完整路径，如：e:\123\)</param>
        /// <param name="content">文件内容</param>
        ///<param name="fileName">文件名称</param>
        /// <returns></returns>
        public static int Write(string filePath, string content, string fileName)
        {
            try
            {
                if (IsNull.Null(filePath) && IsNull.Null(content) && IsNull.Null(fileName))
                {
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);

                    }
                    FileStream fs = new FileStream(filePath+fileName+".log", FileMode.Create);
                    
                    //获得字节数组
                    byte[] data = System.Text.Encoding.Default.GetBytes(content);
                    //开始写入
                    fs.Write(data, 0, data.Length);
                    //清空缓冲区、关闭流
                    fs.Flush();
                    fs.Close();

                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
                throw e;
            }
        }
    }
}
