using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Secom.Smp.Web.Base.Controllers;


namespace Secom.Smp.Web.SysSet.Areas.BaseInfo.Controllers
{
    public class BranchController : BaseController
    {
        // GET: BaseInfo/Branch
        public ActionResult Index()
        {
            ViewBag.HeadString = HeadString;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}