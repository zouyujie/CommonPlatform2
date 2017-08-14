/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.Extend
* 文件名: Ext_Datetime
* 创建者: 邹琼俊
* 创建时间: 2017/7/10 16:53:52
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.Common
{
    public static class Ext_Datetime
    {
        public static string ToDateStr(this DateTime dt)
        {
            return dt == null ? string.Empty : dt.ToString("yyyy-MM-dd");
        }
        public static string ToDateStr(this DateTime? dt)
        {
            return dt.HasValue == false ? string.Empty : ((DateTime)dt).ToString("yyyy-MM-dd");
        }
        public static string ToDateTimeStr(this DateTime dt)
        {
            return dt == null ? string.Empty : dt.ToString("yyyy-MM-dd hh:MM:ss");
        }
        public static string ToDateTimeStr(this DateTime dt,string format)
        {
            return dt == null ? string.Empty : dt.ToString(format);
        }
    }
}
