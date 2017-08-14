using Secom.Smp.Web.Base.Filters;
using System.Web.Mvc;

namespace Secom.Smp.Web.Home
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new LogExceptionAttribute()); //添加全局异常处理过滤器
        }
    }
}
