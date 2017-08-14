using Secom.Smp.Common;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web;
using Secom.Smp.Web.Base;

namespace Secom.Smp.Web.Home
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //log4net.Config.XmlConfigurator.Configure();//读取Log4Net配置信息
            MvcHandler.DisableMvcResponseHeader = true; //隐藏ASP.NET MVC版本
            ThemeUtil.ResetRazorViewEngine(string.Empty);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //启用压缩合并
            //BundleTable.EnableOptimizations = true;
        }

    }
}
