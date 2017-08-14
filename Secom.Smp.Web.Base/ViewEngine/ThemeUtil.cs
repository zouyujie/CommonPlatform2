/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.WebApp.Helper
* 文件名: Utils
* 创建者: 邹琼俊
* 创建时间: 2017/6/23 15:45:26
* 版权所有： 紫衡技术
******************************************************************/
using System.Web.Mvc;
using Secom.Smp.Common;

namespace Secom.Smp.Web.Base
{
    /// <summary>
    /// 自定义系统主题控制类
    /// </summary>
    public class ThemeUtil
    {
        private static string _themeName;

        public static string ThemeName
        {
            get
            {
                if (!string.IsNullOrEmpty(_themeName))
                {
                    return _themeName;
                }
                //模板风格
                _themeName =SystemConfig.ThemeName;
                return _themeName;
            }
        }
        public static void ResetRazorViewEngine(string themeName)
        {
            themeName = string.IsNullOrEmpty(themeName) ? ThemeUtil.ThemeName : themeName;
            if (!string.IsNullOrEmpty(themeName))
            {
                ViewEngines.Engines.Clear();
                ViewEngines.Engines.Add(new CustomRazorViewEngine(themeName));
            }
        }
    }
}