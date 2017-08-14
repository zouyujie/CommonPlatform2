/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Base.Filters
* 文件名: LogExceptionAttribute
* 创建者: 邹琼俊
* 创建时间: 2017/7/25 17:30:32
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common;
using Secom.Smp.Common.Log;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.Base.Filters
{
    public class LogExceptionAttribute :HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //1.记录异常日志
                RecordErrorInfo(filterContext);
                //2.获取异常对象
                Exception ex = filterContext.Exception;
                //3.重定向异常处理界面
                if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
                {
                    filterContext.Result = new RedirectResult("~/404.html");
                }
                else
                {
                    GoRedirectError(filterContext);//重定向异常处理界面
                }
                //4.标记异常已处理完毕
                filterContext.ExceptionHandled = true;
            }

            base.OnException(filterContext);
        }
        /// <summary>
        /// 重定向异常处理界面
        /// </summary>
        /// <param name="filterContext"></param>
        public static void GoRedirectError(ExceptionContext filterContext)
        {
            string msg = filterContext.Exception.Message;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new
                {
                    data = string.Empty,
                    state = ResultType.error.ToString(),
                    message = msg
                };
                filterContext.Result = new JsonResult { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                if (SystemConfig.IsShowEx)
                {
                    var view = new ViewResult
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = { ["Error"] = msg }
                    };
                    filterContext.Result = view;
                }
                else
                {
                    filterContext.Result = new RedirectResult("~/error.html");
                }
            }
        }
        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="filterContext"></param>
        private static void RecordErrorInfo(ExceptionContext filterContext)
        {
            StringBuilder error = new StringBuilder();
            var enter = Environment.NewLine;
            error.Append(enter);
            error.Append("发生时间:" + DateTime.Now);
            error.Append(enter);

            error.Append("用户IP:" + WebHelper.GetClientIP());
            error.Append(enter);

            error.Append("发生异常页: " + filterContext.HttpContext.Request.Url);
            error.Append(enter);

            error.Append("区域: " + filterContext.RouteData.DataTokens["area"]);
            error.Append(enter);

            error.Append("控制器: " + filterContext.RouteData.Values["controller"]);
            error.Append(enter);

            error.Append("视图: " + filterContext.RouteData.Values["action"]);
            error.Append(enter);

            Logger.Log(error.ToString(), filterContext.Exception);
        }
    }
}
