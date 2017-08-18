using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Secom.Smp.Web.Base.Controllers;


namespace Secom.Smp.Web.SysSet.Areas.BaseInfo.Controllers
{
    public class CollectorCMDController : BaseController
    {
        // GET: BaseInfo/CollectorCMD
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