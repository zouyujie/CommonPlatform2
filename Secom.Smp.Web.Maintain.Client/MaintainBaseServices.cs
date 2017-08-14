/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Maintain.Client
* 文件名: MaintainBaseServices
* 创建者: 邹琼俊
* 创建时间: 2017/8/10 16:27:24
* 版权所有： 紫衡技术
******************************************************************/
using System.Collections.Generic;
using System.Web.Mvc;

namespace Secom.Smp.Web.Maintain.Client
{
    public class MaintainBaseServices
    {
        /// <summary>
        /// 获取设备类型下拉列表
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> GetEquTypeList()
        {
            //从数据库中读取
            var equTypeList = new List<SelectListItem>() {
                new SelectListItem(){Value="1",Text="空调"},
                new SelectListItem(){Value="2",Text="电梯"}
            };
            var selectItemList = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="全部",Selected=true}
            };
            var selectList=new SelectList(equTypeList, "Value", "Text");
            selectItemList.AddRange(selectList);

            return selectItemList;
        }
    }
}
