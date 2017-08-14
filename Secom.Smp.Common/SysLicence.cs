/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common
* 文件名: Licence
* 创建者: 邹琼俊
* 创建时间: 2017/7/3 17:16:30
* 版权所有： 紫衡技术
******************************************************************/
using System.Configuration;
using System.Web;

namespace Secom.Smp.Common
{
    /// <summary>
    /// 系统授权
    /// </summary>
    public sealed class SysLicence
    {
        public static bool IsLicence(string key)
        {
            string host = HttpContext.Current.Request.Url.Host.ToLower();
            if (host.Equals("localhost"))
                return true;
            string licence = ConfigurationManager.AppSettings["LicenceKey"];
            if (licence != null && licence == Md5.Md5Hash(key, 32))
                return true;

            return false;
        }
        public static string GetLicence()
        {
            var licence = Configs.GetValue("LicenceKey");
            if (string.IsNullOrEmpty(licence))
            {
                licence = Common.GuId();
                Configs.SetValue("LicenceKey", licence);
            }
            return Md5.Md5Hash(licence, 32);
        }
    }
}
