﻿/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Home.Controllers
* 文件名: AreaViewController.cs
* 创建者: 邹琼俊
* 创建时间: 08/14/2017 10:55:38
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.Home.Controllers
{
    public class AreaViewController : Controller
    {
        // GET: AreaView
        public ActionResult Index()
        {
            return View();
        }
    }
}