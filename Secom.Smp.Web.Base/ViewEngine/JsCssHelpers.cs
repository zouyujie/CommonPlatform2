/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.WebApp.Helper
* 文件名: RequireJsHelpers
* 创建者: 邹琼俊
* 创建时间: 2017/6/28 18:23:14
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.Base
{
    /// <summary>
    /// RequireJs模块化 和JS、Css请求路径封装
    /// </summary>
    public static class JsCssHelpers
    {

        /// <summary>
        /// 根据mvc路由自动加载js文件（如果不村咋则不加载）
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString AutoLoadPageJs(this HtmlHelper helper)
        {
            var areas = helper.ViewContext.RouteData.DataTokens["area"];
            var action = helper.ViewContext.RouteData.Values["action"];
            var controller = helper.ViewContext.RouteData.Values["controller"];
            string url = areas == null ? string.Format("views/{0}/{1}", controller, action) : string.Format("views/areas/{2}/{0}/{1}", controller, action, areas);

            return LoadJsString(helper,url);
        }
        public static MvcHtmlString AutoLoadPageJs(this HtmlHelper helper, string controller, string action, string areas)
        {
            string url = areas == null ? string.Format("views/{0}/{1}", controller, action) : string.Format("views/areas/{2}/{0}/{1}", controller, action, areas);

            return LoadJsString(helper, url);
        }
        /// <summary>
        /// 构造js加载的html字符串
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="url">js文件路径</param>
        /// <returns></returns>
        public static MvcHtmlString LoadJsString(HtmlHelper helper, string url)
        {
            var jsBuilder = new StringBuilder();
            string jsLocation = "/content/release-js/";
#if DEBUG
            jsLocation = "/content/js/";
#endif
            string jsFullUrl = Path.Combine(jsLocation, url + ".js");

            if (File.Exists(helper.ViewContext.HttpContext.Server.MapPath(jsFullUrl)))
            {
                jsBuilder.AppendFormat("<script src=\"{0}\"></script>", jsFullUrl);
            }
            return new MvcHtmlString(jsBuilder.ToString());
        }
        public static string StylesPath(this HtmlHelper helper, string pathWithoutStyles)
        {
#if (DEBUG)
            var stylesPath = "~/content/css/";
#else
            var stylesPath =  "~/content/release-css/";
#endif
            return VirtualPathUtility.ToAbsolute(stylesPath + pathWithoutStyles);
        }
        public static string ScriptsPath(this HtmlHelper helper, string pathWithoutStyles)
        {
#if (DEBUG)
            var stylesPath = "~/content/js/";
#else
            var stylesPath = "~/content/release-js/";
#endif
            return VirtualPathUtility.ToAbsolute(stylesPath + pathWithoutStyles);
        }
        /// <summary>
        /// 根据主题名称加载主题样式
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static string ThemesStylesPath(this HtmlHelper helper)
        {
            string themesName = Configs.GetValue("ThemesName");
            var stylesPath = string.Format("~/Content/css/themes/{0}.css", themesName);

            return VirtualPathUtility.ToAbsolute(stylesPath);
        }
        #region old code RequireJs 模块化加载用
        public static MvcHtmlString RequireJs(this HtmlHelper helper, string config, string module)
        {
            var require = new StringBuilder();
            string jsLocation = "/content/release-js/";
#if DEBUG
            jsLocation = "/content/js/";
#endif

            if (File.Exists(helper.ViewContext.HttpContext.Server.MapPath(Path.Combine(jsLocation, module + ".js"))))
            {
                //取消模块注册 （解决ajax load 重复加载同一界面时，不再次访问的问题）
                require.AppendLine("requirejs.undef(\"" + jsLocation + config + "\")");
                require.AppendLine("requirejs.undef(\"" + module + "\")");

                //require.AppendLine("jQuery(document).ready(function() {");
                require.AppendLine("require( [ \"" + jsLocation + config + "\" ], function() {");
                require.AppendLine("    require( [ \"" + module + "\"] ); ");//",\"domReady!\
                require.AppendLine("});");
                //require.AppendLine("});");
            }

            return new MvcHtmlString(require.ToString());
        }

        public static MvcHtmlString ViewSpecificRequireJS(this HtmlHelper helper)
        {
            var areas = helper.ViewContext.RouteData.DataTokens["area"];
            var action = helper.ViewContext.RouteData.Values["action"];
            var controller = helper.ViewContext.RouteData.Values["controller"];

            string url = areas == null ? string.Format("views/{0}/{1}", controller, action) : string.Format("views/areas/{2}/{0}/{1}", controller, action, areas);

            return helper.RequireJs("config.js", url);
        }
        public static MvcHtmlString ViewSpecificRequireJS(this HtmlHelper helper, string controller, string action, string areas)
        {
            string url = areas == null ? string.Format("views/{0}/{1}", controller, action) : string.Format("views/areas/{2}/{0}/{1}", controller, action, areas);

            return helper.RequireJs("config.js", url);
        }

        #endregion
    }
}