/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Common.UIModel
* 文件名: jstree
* 创建者: 邹琼俊
* 创建时间: 2017/7/11 10:16:46
* 版权所有： 紫衡技术
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.Common.UIModel
{
    public class jstree
    {
        public string id { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public List<jstree> children { get; set;}
        public state state { get; set; }
    }
    public class state
    {
         public bool? disabled { get; set; }
         public bool? selected { get; set; }
         public bool? opened { get; set; }
    }

}
