/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Base.Filters
* 文件名: PublicAuthorizeAttribute
* 创建者: 邹琼俊
* 创建时间: 2017/8/3 14:32:10
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common;
using System;
using System.Web.Mvc;

namespace Secom.Smp.Web.Base.Filters
{
    /// <summary>
    /// 授权过滤器
    /// </summary>
    public class PublicAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //注释掉父类方法，因为父类里的 OnAuthorization 方法会调用 ASP.NET 的授权验证机制！
            //base.OnAuthorization(filterContext);
            if(OperatorProvider.Provider.GetCurrent()==null)
            {
                filterContext.HttpContext.Response.Redirect("/Home/Login");
            }
        }
    }
}
