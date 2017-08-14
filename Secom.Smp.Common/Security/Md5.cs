/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Security
* 文件名: Md5
* 创建者: 邹琼俊
* 创建时间: 2017/7/3 15:13:48
* 版权所有： 紫衡技术
******************************************************************/

using System.Security.Cryptography;
using System.Text;

namespace Secom.Smp.Common
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class Md5
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string Md5Hash(string str, int code=32)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return code==32? sBuilder.ToString(): sBuilder.ToString().Substring(8, code);
        }
        #region 已过时
        ///// <summary>
        ///// MD5加密
        ///// </summary>
        ///// <param name="str">加密字符</param>
        ///// <param name="code">加密位数16/32</param>
        ///// <returns></returns>
        //public static string md5(string str, int code)
        //{
        //    string strEncrypt = string.Empty;
        //    if (code == 16)
        //    {
        //        strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
        //    }

        //    if (code == 32)
        //    {
        //        strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        //    }

        //    return strEncrypt;
        //}
        #endregion
    }
}
