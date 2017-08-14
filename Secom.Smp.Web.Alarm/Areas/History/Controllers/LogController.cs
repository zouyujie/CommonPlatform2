/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Alarm.Controllers
* 文件名: HomeController
* 创建者: 邹琼俊
* 创建时间: 2017/6/26 14:59:54
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Data.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Secom.Smp.Common;
using Secom.Smp.Data;
using System.Data.Entity;
using Secom.Smp.Common.UIModel;

namespace Secom.Smp.Web.Alarm.Areas.History.Controllers
{
    public class LogController : BaseController
    {
        private MyContext db = new MyContext();

        /// <summary>
        /// 日志列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult List(OperatorLogParams filter)
        {
            IQueryable<OperatorLog> dataSource = db.OperatorLogs;
            DataTablesRequest parm = new DataTablesRequest(this.Request);    //处理对象
            Dictionary<int, string> dicSort = new Dictionary<int, string>();
            dicSort.Add(2, "Name");
            dicSort.Add(3, "Msg");
            dicSort.Add(4, "CreateTime");

            //1.0 首先获取datatable提交过来的参数
            int dataStart = parm.iDisplayStart;//要请求的该页第一条数据的序号
            int pageSize = parm.iDisplayLength == -1 ? dataSource.Count() : parm.iDisplayLength;//每页容量（=-1表示取全部数据）

            IList<OperatorLog> data = null;

            //2.0 根据参数(起始序号、每页容量、参训参数)查询数据
            if (!string.IsNullOrEmpty(filter.LogName))
            {
                dataSource = dataSource.Where(a => a.Name.Contains(filter.LogName));
            }
            if(parm.iSortingCols>0&& parm.SortColumns[0].Index!=0)
            {
                string sortFiled = dicSort.Where(x => x.Key == parm.SortColumns[0].Index).FirstOrDefault().Value;
                dataSource = dataSource.OrderByEx<OperatorLog>(parm.SortColumns[0].Direction.ToString(), sortFiled);
            }
            else
            {
                dataSource = dataSource.OrderByDescending(x => x.CreateTime);
            }
            data = dataSource.Skip<OperatorLog>(dataStart).Take(pageSize).ToList();
            var result = data.Select(u => new
            {
                ID = u.Id,
                Name = u.Name,
                CreateTime = u.CreateTime.ToDateStr(),
                Msg = u.Msg
            });
            //构造成Json的格式传递
            return Json(new { iTotalRecords = dataSource.Count(), iTotalDisplayRecords = dataSource.Count(), data = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,CreateTime,Msg")] OperatorLog _OperatorLog)
        {
            AjaxResult _AjaxResult = null;
            if (ModelState.IsValid)
            {
                db.OperatorLogs.Add(_OperatorLog);
                _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", CText)) : ErrorTip(string.Format("{0}失败！", CText)); ;
            }
            else
            {
                _AjaxResult = ErrorTip(VoidText);
             }
            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Read(int Id)
        {
            var model = db.OperatorLogs.Where(x => x.Id == Id).FirstOrDefault();
            return View(model);
        }
        [HttpGet]
        public ActionResult Update(int Id)
        {
            var model = db.OperatorLogs.Where(x => x.Id == Id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public JsonResult Update([Bind(Include = "Id,Name,CreateTime,Msg")]  OperatorLog _OperatorLog)
        {
            AjaxResult _AjaxResult = null;
            if (ModelState.IsValid)
            {
                db.Entry(_OperatorLog).State = EntityState.Modified;
                _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", UText)) : ErrorTip(string.Format("{0}失败！", UText));
            }
            else
            {
                _AjaxResult = ErrorTip(VoidText);
            }
            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var model = db.OperatorLogs.Where(x => x.Id == Id).FirstOrDefault();
            db.OperatorLogs.Remove(model);
            AjaxResult _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", DText)) : ErrorTip(string.Format("{0}失败！", DText));

            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetLogNameByField(string query)
        {
           var result = db.OperatorLogs.Where(x => x.Name.Contains(query)).Select(s => new { s.Id, s.Name }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}