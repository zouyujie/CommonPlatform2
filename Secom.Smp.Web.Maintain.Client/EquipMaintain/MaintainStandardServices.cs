/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Maintain.Client.EquipMaintain
* 文件名: MaintainStandardServices
* 创建者: 邹琼俊
* 创建时间: 2017/8/14 14:55:18
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secom.Smp.Web.Maintain.Client.EquipMaintain
{
    public class MaintainStandardServices
    {
        public List<TestModel1> DataSource()
        {
            return new List<TestModel1> { new TestModel1() { ID = 1, TName = "压力", TName1 = "电梯", TName2 = "区间值", TName3 = "半月", TName4 = "300~900", TName5 = "Pa", TName6 = "是" } };
        }
    }
}
