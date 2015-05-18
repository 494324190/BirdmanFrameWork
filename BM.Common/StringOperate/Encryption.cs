using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace BM.Common.StringOperate
{
    /// <summary>
    /// 字符串加密解密类
    /// 提供DESC加密解密、MD5加密
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// MD5加密，加密不可逆
        /// </summary>
        /// <param name="str">明文</param>
        /// <returns>密文，若加密失败返回空</returns>
        public static string MD5(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.Default.GetBytes(str);
                byte[] md5data = md5.ComputeHash(data);
                md5.Clear();
                string strMd5 = "";
                for (int i = 0; i < md5data.Length; i++)
                {
                    strMd5 += md5data[i].ToString("x").PadLeft(2, '0');
                }
                return strMd5;
            }
            return "";
        }
        /// <summary> 
        /// DES解密 
        /// </summary> 
        /// <param name="DesString">密文</param> 
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param> 
        /// <returns>明文，若揭秘失败，返回密文</returns>
        public static string DecryptDES(string desString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(decryptKey.Substring(0, 8));
                byte[] inputByteArray = Convert.FromBase64String(desString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch (Exception ex)
            {
                return desString;
            }
        }
        /// <summary> 
        /// DES加密,可逆加密
        /// </summary> 
        /// <param name="encryptString">待加密的字符串</param> 
        /// <param name="encryptKey">加密密钥,要求为8位</param> 
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns> 
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }
    }
}
