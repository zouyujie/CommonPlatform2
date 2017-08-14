/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Maintain.Client.EquipMaintain
* 文件名: CompositeSearchingServices
* 创建者: 邹琼俊
* 创建时间: 2017/8/14 14:48:45
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
    public class CompositeSearchingServices
    {
        public List<TestModel1> DataSource()
        {
            return new List<TestModel1> { new TestModel1() { ID = 1, TName = "BYD20170810",TName0="电梯月保", TName1 = "电梯", TName2 = "儿童医院",
            TName3 = "7", TName4 = "2017-08-10", TName5 = "电梯班", TName6 = "6/6",TName7="2017-08-10",TName8="执行人",TName9="保养状态" } };
        }
    }
}
