/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.WebApi
* 文件名: ValidateHelper
* 创建者: 邹琼俊
* 创建时间: 2017/7/19 10:37:01
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Linq;
using System.Text;

namespace Secom.Smp.Common.WebApiUtil
{
    /// <summary>
    /// WebApi授权
    /// </summary>
    public class WebApiLicence
    {
        /// <summary>
        /// 生成WebApi授权标识
        /// </summary>
        /// <param name="timeStamp">当前请求的时间戳</param>
        /// <param name="temp">随机数（5位以下)</param>
        /// <param name="userid">用户ID（唯一标识）</param>
        /// <param name="serverToken">WebApi</param>
        /// <param name="requestData">可为空</param>        
        /// <returns>WebApi授权标识</returns>
        public static string UserTokonValidate(string timeStamp, string temp, int userid, string serverToken, string requestData)
        {
            var hash = System.Security.Cryptography.MD5.Create();
            string strValidate = timeStamp + temp + userid + serverToken + requestData;
            string strSort = string.Concat(strValidate.OrderBy(c => c));
            var bytes = Encoding.UTF8.GetBytes(strSort);
            var md5Val = hash.ComputeHash(bytes);//MD5 

            StringBuilder sbServerSignature = new StringBuilder();
            foreach (var c in md5Val)
            {
                sbServerSignature.Append(c.ToString("X2"));
            }
            string strUiSignature=sbServerSignature.ToString().ToUpper();
            return strUiSignature;
        }
        /// <summary>
        /// 获取WebApi授权Model
        /// </summary>
        /// <param name="uerId"></param>
        /// <returns></returns>
        public static ValidateModel GetValidateModel(string uerId)
        {
            ValidateModel result = null;
            if (CacheHelper.GetCache("ValidateModel_" + uerId) != null)
            {
                result = CacheHelper.GetCache("ValidateModel_" + uerId) as ValidateModel;
            }
            else
            {
                result = new BaseService<ValidateModel>().Get(uerId);
                CacheHelper.SetCache("ValidateModel_" + uerId, result, DateTime.Now.AddMinutes(SystemConfig.SysCacheTime), TimeSpan.Zero); //插入cache 缓存30分钟
            }
            return result;
        }
    }
}
