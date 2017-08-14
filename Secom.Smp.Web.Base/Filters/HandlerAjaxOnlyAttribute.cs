/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.WebApp.Filters
* 文件名: HandlerAjaxOnlyAttribute
* 创建者: 邹琼俊
* 创建时间: 2017/7/3 17:55:13
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Web.Mvc;

namespace Secom.Smp.Web.Base.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HandlerAjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAjaxOnlyAttribute(bool ignore = false)
        {
            Ignore = ignore;
        }
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            if (Ignore)
                return true;
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}