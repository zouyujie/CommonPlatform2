/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Data.Controllers
* 文件名: BaseController.cs
* 创建者: 邹琼俊
* 创建时间: 06/26/2017 11:25:57
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common;
using Secom.Smp.Web.Base.Filters;
using Secom.Smp.Web.Home.Client;
using System.Web.Mvc;

namespace Secom.Smp.Web.Base.Controllers
{
    [PublicAuthorize]
    public class BaseController : Controller
    {
        HomeService _HomeService = new HomeService();
        #region 字段

        /// <summary>
        /// 新增
        /// </summary>
        protected string CText = "新增";
        /// <summary>
        /// 读取
        /// </summary>
        protected string RText = "读取";
        /// <summary>
        /// 更新
        /// </summary>
        protected string UText = "更新";
        /// <summary>
        /// 删除
        /// </summary>
        protected string DText = "删除";
        /// <summary>
        /// 数据有误！
        /// </summary>
        protected string VoidText = "数据有误！";

        #endregion

        #region 属性
        /// <summary>
        /// 获取点击的菜单ID
        /// </summary>
        public string MenuId { get { return Request.QueryString["MenuId"]; } }
        /// <summary>
        /// 自动构建页面标题导航
        /// </summary>
        public MvcHtmlString HeadString
        {
            get { return new MvcHtmlString(_HomeService.GetHead(int.Parse(MenuId))); }
        } 
        /// <summary>
        /// 构造非菜单页的界面导航标题
        /// </summary>
        /// <param name="title">页面标题</param>
        public void CreateSubPageHead(string title)
        {
            ViewBag.HeadString = HeadString;
            ViewBag.MenuId = MenuId;
            ViewBag.SubHeadString =  new MvcHtmlString(string.Format("<i class='fa fa-angle-right'></i>{0}",title)); 
        }
        #endregion
        [HttpGet]
        public virtual ActionResult Index()
        {
            if (!string.IsNullOrEmpty(MenuId))
            {
                ViewBag.MenuId = MenuId;
                ViewBag.HeadString = HeadString;
            }
            return View();
        }
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="message">提示文本</param>
        /// <returns></returns>
        protected virtual AjaxResult SuccessTip(string message)
        {
            return new AjaxResult { state = ResultType.success.ToString(), message = message };
        }
        /// <summary>
        /// 操作失败
        /// </summary>
        /// <param name="message">提示文本</param>
        /// <returns></returns>
        protected virtual AjaxResult ErrorTip(string message)
        {
            return new AjaxResult { state = ResultType.error.ToString(), message = message };
        }
    }
}