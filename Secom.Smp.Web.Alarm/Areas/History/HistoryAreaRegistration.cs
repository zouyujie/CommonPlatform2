/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.AreaRegistrations
* 文件名: HistoryAreaRegistration
* 创建者: 邹琼俊
* 创建时间: 2017/7/4 10:09:46
* 版权所有： 紫衡技术
******************************************************************/
using System.Web.Mvc;

namespace Secom.Smp.Web.Alarm
{
    public class HistoryAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "History";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "History_default",
                "History/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "Secom.Smp.Web.Alarm.Areas.History.Controllers" }
            );
        }
    }
}
