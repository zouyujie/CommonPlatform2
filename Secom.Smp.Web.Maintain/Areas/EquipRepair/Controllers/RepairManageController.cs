/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Maintain.Areas.EquipRepair.Controllers
* 文件名: RepairManageController.cs
* 创建者: 邹琼俊
* 创建时间: 07/31/2017 14:46:46
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.Maintain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.Maintain.Areas.EquipRepair.Controllers
{
    public class RepairManageController : BaseController
    {
        // GET: EquipRepair/RepairManage
        [HttpGet]
        public override ActionResult Index()
        {
            //从数据库中读取
            var depList = new List<RepairDept>() {
                new RepairDept(){DeptId=1,DeptName="空调部门"},
                new RepairDept(){DeptId=2,DeptName="水电部门"}
            };
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="全部",Selected=true}
            };
            var selectList = new SelectList(depList, "DeptId", "DeptName");
            selectItemList.AddRange(selectList);
            ViewBag.depList = selectItemList;

            return base.Index();
        }
    }
}