/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.UIModel
* 文件名: uploadImages
* 创建者: 邹琼俊
* 创建时间: 2017/7/12 13:51:09
* 版权所有： 紫衡技术
******************************************************************/

namespace Secom.Smp.Common.UIModel
{
    public class uploadFile
    {
        /// <summary>
        /// 1：成功 2：失败
        /// </summary>
        public int state { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 图片全每次
        /// </summary>
        public string fullName { get; set; }
    }
}
