using System.Web.Mvc;

namespace Secom.Smp.Web.Maintain
{
    /// <summary>
    /// 设备保养 区域注册
    /// </summary>
    public class EquipMaintainAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "EquipMaintain";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "EquipMaintain_default",
                "EquipMaintain/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new string[1] { "Secom.Smp.Web.Maintain.Areas.EquipMaintain.Controllers" }
            );
        }
    }
}