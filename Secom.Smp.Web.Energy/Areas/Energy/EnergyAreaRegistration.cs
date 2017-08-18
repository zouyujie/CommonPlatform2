using System.Web.Mvc;

namespace Secom.Smp.Web.Energy
{
    public class EnergyAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Energy";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Energy_default",
                "Energy/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "Secom.Smp.Web.Energy.Areas.Energy.Controllers" }
            );
        }
    }
}