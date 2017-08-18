/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Home.Controllers
* 文件名: OverViewController.cs
* 创建者: 邹琼俊
* 创建时间: 08/08/2017 16:45:17
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.ViewModel.Enums;
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.Home.Client;
using System.Web.Mvc;

namespace Secom.Smp.Web.Home.Controllers
{
    public class OverViewController : BaseController
    {
        OverViewService service = new OverViewService();

        [HttpGet]
        public override ActionResult Index()
        {
            ViewBag.RepairOrder= service.GetDataList(); //运维管理基础数据
            var baseInfo = service.GetBaseInfo();
            ViewBag.Introduction = baseInfo.Name0;
            ViewBag.InfoImg = baseInfo.Name1;

            return View();
        }

        #region 运维管理

        /// <summary>
        /// 维修统计/巡检统计/保养统计
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetTotalOptions()
        {
            return service.GetTotalOptions();
        }

        #endregion

        #region 能耗统计

        /// <summary>
        /// 本月总能耗/本年总能耗
        /// </summary>
        /// <param name="type">能耗类型</param>
        /// <returns></returns>
        [HttpPost]
        public string GetECTotalOptions(int? type)
        {
            return service.GetECTotalOptions(GetEnumByValue(type));
        }
        [HttpPost]
        public string GetECTotalOptionsNew(int? type)
        {
            return service.GetECTotalOptionsNew(GetEnumByValue(type));
        }
        /// <summary>
        /// 逐时能耗
        /// </summary>
        /// <param name="type">能耗类型</param>
        /// <returns></returns>
        [HttpPost]
        public string GetHourTotalOptions(int? type)
        {
            return service.GetHourTotalOptions(GetEnumByValue(type));
        }
        /// <summary>
        /// 能耗统计的基本信息
        /// </summary>
        /// <param name="type">能耗类型</param>
        /// <returns></returns>
        public JsonResult GetAlarmTotalInfo(int? type)
        {
            var model = service.GetAlarmTotalInfo(GetEnumByValue(type)); 

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        private AlarmTypeEnum GetEnumByValue(int? type)
        {
           return type == null ? AlarmTypeEnum.Electricity : (AlarmTypeEnum)type;
        }

        #endregion

        #region 安全管理

        /// <summary>
        /// 暖通空调列表
        /// </summary>
        /// <returns></returns>
        public JsonResult AirList()
        {
            var model = service.AirList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        //公共照明
        public JsonResult PublicLighting()
        {
            var model = service.PublicLighting();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 医用冷链列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ColdChains()
        {
            return GetJsonData(service.ColdChains());
        }
        /// <summary>
        /// 变配电列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Transformer()
        {
            return GetJsonData(service.Transformer());
        }
        //构造成Json的格式传递
        private JsonResult GetJsonData(object list)
        {
            var result = new { iTotalRecords = 2, iTotalDisplayRecords = 2, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}