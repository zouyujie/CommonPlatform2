/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Data.Areas.Base.Controllers
* 文件名: DefaultController
* 创建者: 邹琼俊
* 创建时间: 2017/6/23 10:02:24
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Data.Models;
using System.Linq;
using System.Web.Mvc;
using Secom.Smp.Web.Base.Filters;
using Secom.Smp.Common;
using System.Collections.Generic;
using System.Data.Entity;
using Secom.Smp.Common.Excel;
using System.Web;
using System.IO;
using Secom.Smp.Common.UIModel;
using System;

namespace Secom.Smp.Web.SysSet.Areas.Admin.Controllers
{
    [LogException]
    public class DefaultController : BaseController
    {
        private MyContext db = new MyContext();
        /// <summary>
        /// 客户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult List(Customer filter)
        {
            //filter.PageSize = int.MaxValue;
            IQueryable<Customer> dataSource = db.Customers;

            if (!string.IsNullOrEmpty(filter.Name))
            {
                dataSource = dataSource.Where(x => x.Name == filter.Name).OrderBy(x => x.CreateTime);
            }

            List<Customer> queryData = dataSource.ToList();

            var data = queryData.Select(u => new
            {
                ID = u.Id,
                Name = u.Name,
                CreateTime = u.CreateTime.ToDateStr(),
                Address = u.Address
            });

            //构造成Json的格式传递
            var result = new { iTotalRecords = queryData.Count, iTotalDisplayRecords = 10, data = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #region CRUD
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create([Bind(Include = "Name,Address,CreateTime,Msg,HeadsUrl")] Customer _Customer)
        {
            AjaxResult _AjaxResult = null;
            if (ModelState.IsValid)
            {
                db.Customers.Add(_Customer);
                _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", CText)) : ErrorTip(string.Format("{0}失败！", CText)); ;
            }
            else
            {
                _AjaxResult = ErrorTip(VoidText);
            }
            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var model = db.Customers.Where(x => x.Id == Id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public JsonResult Update([Bind(Include = "Id,Name,Address,CreateTime,Msg,HeadsUrl")] Customer _Customer)
        {
            AjaxResult _AjaxResult = null;
            if (ModelState.IsValid)
            {
                db.Entry(_Customer).State = EntityState.Modified;
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
            var model = db.Customers.Where(x => x.Id == Id).FirstOrDefault();
            db.Customers.Remove(model);
            AjaxResult _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", DText)) : ErrorTip(string.Format("{0}失败！", DText));

            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteList(List<int> ids)
        {
            var list = db.Customers.Where(x => ids.Contains(x.Id)).ToList();
            db.Customers.RemoveRange(list);
            AjaxResult _AjaxResult = db.SaveChanges() > 0 ? SuccessTip(string.Format("{0}成功！", DText)) : ErrorTip(string.Format("{0}失败！", DText));

            return Json(_AjaxResult, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region File handle
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        public FileResult ExportExcel()
        {
            string excelPath = Server.MapPath("~/Excel/用户列表.xls");
            GenerateExcel genExcel = new GenerateExcel();
            genExcel.SheetList.Add(new UserListSheet(db.Customers.ToList(), "用户列表"));
            genExcel.ExportExcel(excelPath);
            return File(excelPath, "application/ms-excel", "用户列表.xls");
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public JsonResult ExportFile()
        {
            HttpPostedFileBase file = Request.Files["txt_file"];
            uploadFile _uploadFile = new uploadFile();

            if (file != null)
            {
                string str = DateTime.Now.ToString("yyyyMMddhhMMss");
                var fileFullName =string.Format("{0}{1}_{2}",Request.MapPath("~/Upload/"),str ,file.FileName);
                try
                {
                    file.SaveAs(fileFullName);
                    _uploadFile.state = 1;
                }
                catch
                {
                    _uploadFile.state = 0;
                }
                finally
                {
                    _uploadFile.name = str+"_"+file.FileName;
                    _uploadFile.fullName = fileFullName;
                }
            }
            else
            {
                _uploadFile.state = 0;
            }
            return Json(_uploadFile, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteFile(string key)
        {
            var fileFullName = Path.Combine(Request.MapPath("~/Upload"), key);
            int state = 0;
            try
            {
                state = FileHelper.DeleteFile(fileFullName) ? 1 : 0;
                //var model = db.Customers.Where(x => x.HeadsUrl == key).FirstOrDefault();
                //if(model!=null)
                //{
                //    db.Customers.Remove(model);
                //}
            }
            catch
            {
                state = 0;
            }
            return Json(state, JsonRequestBehavior.AllowGet);
        } 

        #endregion
    }
}
