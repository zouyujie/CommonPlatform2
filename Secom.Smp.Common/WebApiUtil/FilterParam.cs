/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Clients.Admin.Util
* 文件名: filterParam
* 创建者: 邹琼俊
* 创建时间: 2017/7/20 15:04:40
* 版权所有： 紫衡技术
******************************************************************/

namespace Secom.Smp.Common.WebApiUtil
{
    public class FilterParam
    {
        public int pageindex { get; set; }
        public int pagesize { get; set; }
        public virtual string GetFilter()
        {
            return string.Format("pageindex={0}&pagesize={1}", pageindex, pagesize);
        }
    }
}
