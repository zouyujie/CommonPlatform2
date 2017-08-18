using System.Web.Mvc;

namespace Secom.Smp.Web.SysSet
{
    public class BaseInfoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaseInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BaseInfo_default",
                "BaseInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "Secom.Smp.Web.SysSet.Areas.BaseInfo.Controllers" }
            );
        }
    }
}