/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.HtmlHelper
* 文件名: HtmlExtensions
* 创建者: 邹琼俊
* 创建时间: 2017/8/17 17:27:51
* 版权所有： 紫衡技术
******************************************************************/
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Secom.Smp.Common
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString Test(this HtmlHelper helper, List<string> lst)
        {
            var builder = new StringBuilder();
            if (lst != null && lst.Count > 0)
            {
                builder.Append(@"<div class=""mt-element-step"">
                        <div class=""row step-line"">");

                foreach(var v in lst)
                {

                }
                builder.Append(" </div></div>");
            }
            return MvcHtmlString.Create(builder.ToString());
        }
    }
}
