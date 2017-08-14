/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.SysSet.Areas.Admin.Controllers
* 文件名: EchartsController.cs
* 创建者: 邹琼俊
* 创建时间: 07/20/2017 11:11:33
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.SysSet.Client.ECharts;
using System.Web.Mvc;

namespace Secom.Smp.Web.SysSet.Areas.Admin.Controllers
{
    public class EChartsController : BaseController
    {
        IEChartsServices _LineServices = new LineServices();
        IEChartsServices _BarServices = new BarServices();

        public ActionResult Line()
        {
            ViewBag.HeadString = HeadString;
            return View();
        }
        [AcceptVerbs("GET", "POST")]
        public string GetLineOptions()
        {
            return _LineServices.GetOptions();
        }
        public ActionResult Bar()
        {
            return View();
        }
        [AcceptVerbs("GET", "POST")]
        public string GetBarOptions()
        {
            return _BarServices.GetOptions();
        }
    }
}