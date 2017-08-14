/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Maintain.Areas.EquipMaintain.Controllers
* 文件名: MaintainStandardController.cs
* 创建者: 邹琼俊
* 创建时间: 08/10/2017 09:48:38
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common.UIModel;
using Secom.Smp.Web.Maintain.Filters;
using Secom.Smp.ViewModel.Home;
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Web.Maintain.Client;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Secom.Smp.Web.Maintain.Client.EquipMaintain;

namespace Secom.Smp.Web.Maintain.Areas.EquipMaintain.Controllers
{
    public class MaintainStandardController : BaseController
    {
        MaintainBaseServices baseServices = new MaintainBaseServices();
        MaintainStandardServices _MaintainStandardServices = new MaintainStandardServices();
        [HttpGet]
        public override ActionResult Index()
        {
            ViewBag.equTypeList = baseServices.GetEquTypeList();

            return base.Index();
        }
        /// <summary>
        /// 保养标准列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult List(MaintainStandardFilters filter)
        {
            var dataSource = _MaintainStandardServices.DataSource();
             DataTablesRequest parm = new DataTablesRequest(this.Request);    //处理对象
            Dictionary<int, string> dicSort = new Dictionary<int, string>();
            //dicSort.Add(2, "Name");
            //dicSort.Add(3, "Msg");
            //dicSort.Add(4, "CreateTime");

            //1.0 首先获取datatable提交过来的参数
            int dataStart = parm.iDisplayStart;//要请求的该页第一条数据的序号
            int pageSize = parm.iDisplayLength == -1 ? dataSource.Count() : parm.iDisplayLength;//每页容量（=-1表示取全部数据）

            IList<TestModel1> data = null;

            //2.0 根据参数(起始序号、每页容量、参训参数)查询数据
            if (!string.IsNullOrEmpty(filter.TName1))
            {
                dataSource = dataSource.FindAll(a => a.TName1==filter.TName1);
            }
            if (parm.iSortingCols > 0 && parm.SortColumns[0].Index != 0)
            {
                string sortFiled = dicSort.Where(x => x.Key == parm.SortColumns[0].Index).FirstOrDefault().Value;
                //dataSource = dataSource.OrderByEx<TestModel1>(parm.SortColumns[0].Direction.ToString(), sortFiled);
            }
            data = dataSource.Skip<TestModel1>(dataStart).Take(pageSize).ToList();

            //构造成Json的格式传递
            return Json(new { iTotalRecords = dataSource.Count(), iTotalDisplayRecords = dataSource.Count(), data = dataSource }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Read(int Id)
        {
            var model = _MaintainStandardServices.DataSource().Find(x => x.ID == Id);
            return View(model);
        }
    }
}