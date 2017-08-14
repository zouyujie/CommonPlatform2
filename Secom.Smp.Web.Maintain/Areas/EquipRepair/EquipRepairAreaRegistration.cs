using System.Web.Mvc;

namespace Secom.Smp.Web.Maintain
{
    /// <summary>
    /// 设备维修 区域注册
    /// </summary>
    public class EquipRepairAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EquipRepair";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EquipRepair_default",
                "EquipRepair/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
               namespaces: new string[1] { "Secom.Smp.Web.Maintain.Areas.EquipRepair.Controllers" }
            );
        }
    }
}