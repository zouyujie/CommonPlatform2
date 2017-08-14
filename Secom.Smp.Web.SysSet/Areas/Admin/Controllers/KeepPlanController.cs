/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.SysSet.Areas.Admin.Controllers
* 文件名: KeepPlanController.cs
* 创建者: 邹琼俊
* 创建时间: 07/10/2017 17:43:01
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Web.Base.Controllers;
using Secom.Smp.Common.UIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Secom.Smp.Web.SysSet.Areas.Admin.Controllers
{
    public class KeepPlanController : BaseController
    {
        public JsonResult GetEquipmentTypes()
        {
            #region 数据格式
            //            var data = @"[{
            //                ""text"": ""所有"",
            //                ""children"": [{ ""text"": ""制冷站"",
            //                    ""children"": [{
            //                        ""id"":""1"",
            //                        ""text"": ""空调主机"",
            //                        ""state"": {
            //                            ""selected"": true
            //                        }
            //}, {
            //                        ""text"": ""custom icon"",
            //                        ""icon"": ""fa fa-warning icon-state-danger""
            //                    }, {
            //                        ""text"": ""initially open"",
            //                        ""icon"": ""fa fa-folder icon-state-default"",
            //                        ""state"": {
            //                            ""opened"": true
            //                        },
            //                        ""children"": [""Another node""]
            //                    }, {
            //                        ""text"": ""custom icon"",
            //                        ""icon"": ""fa fa-warning icon-state-warning""
            //                    }, {
            //                        ""text"": ""disabled node"",
            //                        ""icon"": ""fa fa-check icon-state-success"",
            //                        ""state"": {
            //                            ""disabled"": true
            //                        }
            //                    }]
            //                }, ""冷链系统""]
            //            }]
            //            "; 
            #endregion

            jstree _jstree = new jstree()
            {
                text = "所有",
                children = new List<jstree> {
                new jstree {
                text = "制冷站",
                children =  new List<jstree> { new jstree { id = "1", text = "空调主机", state = new state { selected = true } } }
              },
              new jstree { id="2", text="冷却水泵",icon= "fa fa-warning icon-state-danger"},
              new jstree {text="空调主机",icon="fa fa-folder icon-state-default" ,state = new state { opened = true },
              children=  new List<jstree> {
                      new jstree { id="4",text="离心泵"},
                      new jstree { id="5",text="螺旋机"}
                  }
              }
              }
            };

            return Json(_jstree, JsonRequestBehavior.AllowGet);
        }
    }

}