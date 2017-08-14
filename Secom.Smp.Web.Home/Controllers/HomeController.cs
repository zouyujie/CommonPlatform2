/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: GloabController.Controllers
* 文件名: HomeController.cs
* 创建者: 邹琼俊
* 创建时间: 06/22/2017 16:33:27
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Web.Mvc;
using System.Web;
using Secom.Smp.Common;
using Secom.Smp.Web.Home.Client;
using Secom.Smp.Web.Base;
using Secom.Smp.Web.Base.Filters;

namespace Secom.Smp.Web.Home.Controllers
{
    public class HomeController:Controller
    {
        HomeService _service = new HomeService();
        string themeCookieName = "Theme";

        #region 属性
        /// <summary>
        /// 当前登录用户对象
        /// </summary>
        public OperatorModel Operator
        {
            get { return OperatorProvider.Provider.GetCurrent(); }
        }
        #endregion

        [PublicAuthorize]
        public ActionResult Index()
        {
            ViewBag.UserName = Operator == null ? string.Empty : Operator.UserName;
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }
        #region 其它顶部一级菜单页面
        public ActionResult Maintain()
        {
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }
        public ActionResult SysSet()
        {
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }
        public ActionResult Watch()
        {
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }
        public ActionResult Alarm()
        {
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }

        public ActionResult Energy()
        {
            ViewData["TopMenu"] = _service.GetTopMenu();
            return View();
        }
        #endregion
        [PublicAuthorize]
        [HttpGet]
        /// <summary>
        /// 动态加载左侧菜单
        /// </summary>
        /// <param name="menuId">一级菜单Id</param>
        /// <returns></returns>
        public MvcHtmlString LoadMenu(int? Id)
        {
            int id = Id == null ? -1 : (int)Id;
            var result = _service.GetMenusByTopMenuId(id);
            return new MvcHtmlString(result);
        }

        public ActionResult SetTheme(string themeName,string returnUrl)
        {
            if (!string.IsNullOrEmpty(themeName))
            {
                Response.Cookies.Set(new HttpCookie(themeCookieName, themeName) { Expires = DateTime.Now.AddYears(1) });
            }
            else
            {
                themeName = Request.Cookies[themeCookieName].Value ?? "".Trim();
            }
            ThemeUtil.ResetRazorViewEngine(themeName);
            return string.IsNullOrEmpty(returnUrl)? Redirect("~/Home/Index"):Redirect(returnUrl);
        }
        #region Login Module
        public ActionResult Login()
        {
            //string themeName = Request.Cookies[themeCookieName].Value ?? "".Trim();
            string themeName = ThemeUtil.ThemeName;
            if (!string.IsNullOrEmpty(themeName))
            {
                ThemeUtil.ResetRazorViewEngine(themeName);
            }
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//防伪造令牌来避免 CSRF 攻击
        public JsonResult CheckLogin(string username, string password, string code)
        {
            try
            {
                if (Session["session_verifycode"].IsEmpty() || Md5.Md5Hash(code.ToLower(), 16) != Session["session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }
                if (username == "admin" && password == "202cb962ac59075b964b07152d234b70")//123
                {
                    var userEntity = new object();// new UserApp().CheckLogin(username, password);
                    if (userEntity != null)
                    {
                        OperatorModel operatorModel = new OperatorModel();
                        //operatorModel.UserId = userEntity.F_Id;
                        //operatorModel.UserCode = userEntity.F_Account;
                        //operatorModel.UserName = userEntity.F_RealName;
                        //operatorModel.CompanyId = userEntity.F_OrganizeId;
                        //operatorModel.DepartmentId = userEntity.F_DepartmentId;
                        //operatorModel.RoleId = userEntity.F_RoleId;
                        operatorModel.LoginIPAddress = Net.Ip;
                        operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                        operatorModel.LoginTime = DateTime.Now;
                        operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                        if (username == "admin")
                        {
                            operatorModel.UserName = username;
                            operatorModel.IsSystem = true;
                        }
                        else
                        {
                            operatorModel.IsSystem = false;
                        }
                        //logEntity.F_Description = "登录成功";
                        //new LogApp().WriteDbLog(logEntity);记录日志
                        //登录成功后
                        OperatorProvider.Provider.AddCurrent(operatorModel);
                    }
                }
                else
                {
                    throw new Exception("用户名或错误，请重新输入");
                }
                return Json(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //logEntity.F_Description = "登录失败，" + ex.Message;
                //new LogApp().WriteDbLog(logEntity);
                return Json(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            //new LogApp().WriteDbLog(new LogEntity
            //{
            //    F_ModuleName = "系统登录",
            //    F_Type = DbLogType.Exit.ToString(),
            //    F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
            //    F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
            //    F_Result = true,
            //    F_Description = "安全退出系统",
            //});
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Login", "Home");
        }
        #endregion
    }
}