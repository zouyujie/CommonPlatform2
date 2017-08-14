/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.WebApiUtil
* 文件名: ValidateModel
* 创建者: 邹琼俊
* 创建时间: 2017/8/3 11:37:27
* 版权所有： 紫衡技术
******************************************************************/

namespace Secom.Smp.Common.WebApiUtil
{
    /// <summary>
    /// WebApi返回的授权数据
    /// </summary>
   public class ValidateModel
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        public string ServerToken { get; set; }
        public string ExpireTime { get; set; }
    }
}
