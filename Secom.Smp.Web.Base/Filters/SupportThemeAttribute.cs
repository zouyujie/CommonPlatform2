/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.WebApp.Filters
* 文件名: SupportTheme
* 创建者: 邹琼俊
* 创建时间: 2017/6/23 15:36:00
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Web;
using System.Web.Mvc;
using Secom.Smp.Common;

namespace Secom.Smp.Web.Base.Filters
{
    public class SupportThemeAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //ViewEngines.Engines.Clear();

            var viewResult = filterContext.Result as ViewResult;
            string themeCookieName = "Theme";
            string themeName =(filterContext.RequestContext.HttpContext.Request.Cookies[themeCookieName].Value ?? "").Trim();// Utils.ThemeName;

            if (viewResult != null)
            {
                if (!string.IsNullOrEmpty(themeName))
                {
                    filterContext.RequestContext.HttpContext.Response.Cookies.Set(new HttpCookie(themeCookieName, themeName) { Expires = DateTime.Now.AddYears(1) });
                }

                //ViewEngineCollection viewEngines = new ViewEngineCollection() { new CustomRazorViewEngine(themeName) };
                //foreach (var item in ViewEngines.Engines)
                //{
                //    viewEngines.Add(item);
                //}

                //viewResult.ViewEngineCollection = viewEngines;
                ////viewResult.ViewEngineCollection = new ViewEngineCollection(new List<IViewEngine> { new CustomViewEngine(themeName) });//这里是只用自定义视图引擎

                ThemeUtil.ResetRazorViewEngine(themeName);
            }
            base.OnResultExecuting(filterContext);
        }
    }
}