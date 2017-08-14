/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.WebApp.Helper
* 文件名: CustomRazorViewEngine
* 创建者: 邹琼俊
* 创建时间: 2017/6/23 17:50:20
* 版权所有： 紫衡技术
******************************************************************/
using System.Web.Mvc;

namespace Secom.Smp.Web.Base
{
    /// <summary>
    /// 自定义视图引擎规则
    /// </summary>
    public class CustomRazorViewEngine : RazorViewEngine
    {
        public CustomRazorViewEngine(string theme)
        {
            if (!string.IsNullOrEmpty(theme))
            {
                AreaViewLocationFormats = new[]
                {
                       //themes
                       "~/themes/"+theme+"/views/Areas/{2}/{1}/{0}.cshtml",
                      "~/themes/"+theme+"/Shared/{0}.cshtml",

        "~/Areas/{2}/Views/{1}/{0}.cshtml",
        "~/Areas/{2}/Views/Shared/{0}.cshtml"
    };
                AreaMasterLocationFormats = new[]
                {
                             //themes
              "~/themes/"+theme+"/views/Areas/{2}/{1}/{0}.cshtml",
              "~/themes/"+theme+"/views/Areas/{2}/Shared/{0}.cshtml",
              "~/themes/"+theme+"/views/Shared/{0}.cshtml",

        "~/Areas/{2}/Views/{1}/{0}.cshtml",
        "~/Areas/{2}/Views/Shared/{0}.cshtml"
    };
                AreaPartialViewLocationFormats = new[]
                {
                            //themes
         "~/themes/"+theme+"/views/Shared/{0}.cshtml",

        "~/Areas/{2}/Views/{1}/{0}.cshtml",
        "~/Areas/{2}/Views/Shared/{0}.cshtml"
    };

                ViewLocationFormats = new[]
                {
                            //themes
          "~/themes/"+theme+"/views/{1}/{0}.cshtml",

        "~/Views/{1}/{0}.cshtml",
        "~/Views/Shared/{0}.cshtml"
    };
                MasterLocationFormats = new[]
                {
                            //themes
         "~/themes/"+theme+"/views/Shared/{0}.cshtml",

        "~/Views/{1}/{0}.cshtml",
        "~/Views/Shared/{0}.cshtml"
    };
                PartialViewLocationFormats = new[]
                {
                            //themes
        "~/themes/"+theme+"/views/Shared/{0}.cshtml",

        "~/Views/{1}/{0}.cshtml",
        "~/Views/Shared/{0}.cshtml"
    };

                FileExtensions = new[]{"cshtml"};
            }

        }
    }
}