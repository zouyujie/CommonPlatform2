/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.AreaRegistration
* 文件名: AdminAreaRegistration
* 创建者: 邹琼俊
* 创建时间: 2017/7/4 10:05:44
* 版权所有： 紫衡技术
******************************************************************/
using System.Web.Mvc;

namespace Secom.Smp.Web.SysSet
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "Secom.Smp.Web.SysSet.Areas.Admin.Controllers" }
            );
        }
    }
}
