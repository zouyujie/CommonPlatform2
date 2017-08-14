/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Home.Models
* 文件名: Menu.cs
* 创建者: 邹琼俊
* 创建时间: 06/22/2017 16:30:27
* 版权所有： 紫衡技术
******************************************************************/

namespace Secom.Smp.ViewModel.Home
{
    /// <summary>
    /// 菜单ViewModel
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// 菜单显示文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 菜单图标样式名称
        /// </summary>
        public string IconClass { get; set; }
        /// <summary>
        /// 菜单连接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNumber { get; set; }
        /// <summary>
        /// 菜单级别(0,1,2,...)
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 父菜单Id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 是否隐藏菜单栏（即不显示在页面中）
        /// </summary>
        public bool IsHidden { get; set; }
    }
}