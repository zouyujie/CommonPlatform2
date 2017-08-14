/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Maintain.Areas.EquipMaintain.Controllers
* 文件名: TotalController.cs
* 创建者: 邹琼俊
* 创建时间: 08/09/2017 15:28:05
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.ViewModel.Home;
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.Maintain.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.Maintain.Areas.EquipMaintain.Controllers
{
    public class TotalController  : BaseController
    {
        TotalServices service = new TotalServices();
        #region 工作量统计
        /// <summary>
        /// 工作量统计View界面
        /// </summary>
        /// <returns></returns>
        public ActionResult WorkloadTotal()
        {
            return View();
        }
        /// <summary>
        /// 工作量统计参数
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string GetWorkloadTotalOptions()
        {
            return service.GetOptions();
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WorkloadTotalList()
        {
            var list = new List<TestModel1>() { new TestModel1 { TName = "张明", TName1 = "50", TName2 = "40", TName3 = "10", TName4 = "21",TName5="80%" } ,
             new TestModel1 { TName="李涛",TName1="74",TName2="37",TName3="37",TName4="16",TName5="50%"}};

            //构造成Json的格式传递
            var result = new { iTotalRecords = 2, iTotalDisplayRecords = 2, data = list };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        /// <summary>
        /// 保养成本统计
        /// </summary>
        /// <returns></returns>
        public ActionResult MaintainCostsTotal()
        {
            return View();
        }
        /// <summary>
        /// 维保单位评价
        /// </summary>
        /// <returns></returns>
        public ActionResult MaintenanceUnitAppraise()
        {
            return View();
        }
    }
}