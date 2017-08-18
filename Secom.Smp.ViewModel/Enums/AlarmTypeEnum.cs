/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.ViewModel.Enum
* 文件名: AlarmTypeEnum
* 创建者: 邹琼俊
* 创建时间: 2017/8/16 14:50:07
* 版权所有： 紫衡技术
******************************************************************/
using System.ComponentModel.DataAnnotations;

namespace Secom.Smp.ViewModel.Enums
{
    /// <summary>
    /// 能耗类型
    /// </summary>
    public enum AlarmTypeEnum
    {
        [Display(Name = "电耗")]
        Electricity =0,
        [Display(Name = "水耗")]
        Water =1,
        [Display(Name = "气耗")]
        Air
    }
}
