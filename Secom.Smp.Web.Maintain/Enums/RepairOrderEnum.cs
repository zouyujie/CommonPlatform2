using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Secom.Smp.Web.Maintain.Enums
{
    /// <summary>
    /// 工单状态
    /// </summary>
    public enum RepairOrderEnum
    {
        [Display(Name = "待派工")]
        WaitDispatching =1,
        [Display(Name = "待接受任务")]
        WaitAcceptTask =2
    }
}