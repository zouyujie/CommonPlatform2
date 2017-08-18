/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* 命名空间名称: Secom.Smp.Web.Home.Client
* 文件名: HomeService.cs
* 创建者: 邹琼俊
* 创建时间: 07/31/2017 21:45:57
* 版权所有： 紫衡技术
******************************************************************/
using Secom.Smp.Common;
using Secom.Smp.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Secom.Smp.Web.Home.Client
{
    public class HomeService
    {
        static readonly string MenuLinkClass = "nav-link nav-toggle dropdown-toggle"; //默认菜单链接的样式

        #region 顶部菜单-左侧菜单
        /// <summary>
        /// 获取顶部一级菜单
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetTopMenu()
        {
            return GetShowMenus().Where(x => x.ParentId == -1).OrderByDescending(o => o.SortNumber).ToList();
        }
        /// <summary>
        /// 根据顶部菜单ID加载左侧菜单列表
        /// </summary>
        /// <returns></returns>
        public string GetMenusByTopMenuId(int menuId)
        {
            string result = string.Empty;
            if (CacheHelper.GetCache("Menus_" + menuId) != null)
            {
                result = CacheHelper.GetCache("Menus_" + menuId).ToString();
            }
            else
            {
                var menus = GetShowMenus().Where(x => x.ParentId == menuId); //二级菜单
                StringBuilder sb = new StringBuilder();
                bool firstFlag = true;//第一个默认展开
                GetChildMenus(ref sb, menus, firstFlag);//三级菜单
                result = sb.ToString();

                CacheHelper.SetCache("Menus" + menuId, result, DateTime.Now.AddMinutes(SystemConfig.SysCacheTime), TimeSpan.Zero); //插入cache 缓存30分钟
            }
            return result;
        }
        //加载子菜单-递归调用
        public void GetChildMenus(ref StringBuilder sb, IEnumerable<Menu> menus, bool firstFlag)//二级以上菜单
        {
            int count = 0;
            if (!firstFlag)
                sb.Append("<ul class='sub-menu'>");

            string url = string.Empty;
            foreach (var m in menus)
            {
                var menusChild = GetShowMenus().Where(a => a.ParentId == m.Id);
                count = menusChild.Count();

                url = (string.IsNullOrEmpty(m.LinkUrl) || m.LinkUrl == "javascript;") ? m.LinkUrl : m.LinkUrl + "?MenuId=" + m.Id;
                string spnArrow = string.Format("<span class='arrow {0}'></span>", firstFlag ? "open" : "");

                sb.AppendFormat("<li class='{0}'>", (firstFlag&&count>0) ? "nav-item start active open" : "nav-item start");
                sb.AppendFormat("<a id='menu_{5}' href='{0}' class='{4}'><i class='{1}'></i><span class='title'>{2}</span>{3}</a>",
                    count > 0 ? "javascript;" : url,
                    m.IconClass,
                    m.Text,
                    count > 0 ? spnArrow : "",
                    count > 0 ? MenuLinkClass : "ajaxify " + MenuLinkClass,
                    m.Id);

                firstFlag = false;
                if (count > 0)
                    GetChildMenus(ref sb, menusChild, firstFlag);
                sb.Append("</li>");
            }
            if (!firstFlag)
                sb.Append("</ul>");

        }
        /// <summary>
        /// 获取所有菜单列表
        /// </summary>
        /// <returns></returns>
        public List<Menu> GetAllMenus()
        {
            List<Menu> result = null;
            if (CacheHelper.GetCache("MenusAll" ) != null)
            {
                result = CacheHelper.GetCache("MenusAll") as List<Menu>;
            }
            else
            {
                //模拟数据库菜单数据
                result = new List<Menu>() {
                    new Menu{Id=1,Text="首页",IconClass= "icon-home",LinkUrl="/Home/",SortNumber=999,ParentId=-1 },
                    new Menu{Id=2,Text="系统管理",IconClass= "icon-home",LinkUrl="/Home/SysSet",SortNumber=6 ,ParentId=-1 },
                    new Menu{Id=4,Text="能耗监测",IconClass= "icon-diamond",LinkUrl="/Home/Energy",SortNumber=8,ParentId=-1 },
                    new Menu{Id=3,Text="设备控制",IconClass= "icon-home",LinkUrl="/Home/Watch" ,SortNumber=7,ParentId=-1 },
                    new Menu{Id=5,Text="设备运维",IconClass= "icon-bell",LinkUrl="/Home/Maintain",SortNumber=9 ,ParentId=-1 },

                    new Menu{Id = 21,ParentId=2,Text="用户管理",IconClass= "icon-user", LinkUrl="" },
                    new Menu {Id = 20, ParentId = 21, Text = "用户列表", IconClass = "icon-user", LinkUrl = "/Admin/Default" },
                    new Menu{Id=19,ParentId=2,Text="报表管理",IconClass= "icon-bar-chart", LinkUrl="" },
                    new Menu{Id=29,ParentId=19,Text="Echarts报表",IconClass= "icon-bar-chart", LinkUrl="/Admin/Echarts" },
                    new Menu {Id = 25, ParentId = 19, Text = "Line", IconClass = "icon-user", LinkUrl = "/Admin/ECharts/Line",IsHidden=true } ,
                    new Menu{Id=18,ParentId=2,Text="文件上传",IconClass= "icon-user", LinkUrl="/Admin/FileUpload" },
                    new Menu{Id=17,ParentId=5,Text="设备维修",IconClass= "icon-wrench",LinkUrl="javascript;" },
                    new Menu{Id=10,ParentId=17,Text="报修管理",IconClass= "icon-bell", LinkUrl="/EquipRepair/RepairManage"},
                    new Menu{Id=23,ParentId=5,Text="设备保养",IconClass= "fa fa-medkit",LinkUrl="javascript;" },
                    new Menu{Id=10,ParentId=17,Text="任务管理",IconClass= "fa fa-tasks", LinkUrl="/EquipRepair/RepairManage"},
                    new Menu{Id = 12, ParentId = 4,Text ="操作历史",IconClass= "icon-docs", LinkUrl="/History/Log" },
                    new Menu{Id=14,ParentId=3,Text="树控件演示",IconClass= "icon-docs", LinkUrl= "/Admin/KeepPlan" },
                    new Menu {Id=15,ParentId=3, Text = "Wizard Plugin", IconClass = "icon-docs", LinkUrl = "/Admin/RepairsList" },
                    new Menu {Id=16,ParentId=3, Text = "饼形图", IconClass = "icon-basket" ,LinkUrl="/Admin/EquKeep"},
                    new Menu {Id=31,ParentId=23, Text = "统计分析", IconClass = "icon-bar-chart" ,LinkUrl="/EquipMaintain/Total"},
                    new Menu{Id=32,ParentId=23,Text="保养标准",IconClass= "fa fa-legal", LinkUrl="/EquipMaintain/MaintainStandard"},
                    new Menu{Id=33,ParentId=23,Text="综合查询",IconClass= "fa fa-search", LinkUrl="/EquipMaintain/CompositeSearching",SortNumber=1}

                   ,new Menu{Id=41,ParentId=4, Text="电耗",IconClass= "fa fa-legal", LinkUrl="/Energy/ElectricItem"},
                    new Menu{Id=42,ParentId=4, Text="水耗",IconClass= "fa fa-legal", LinkUrl="/Energy/Water"},
                    new Menu{Id=43,ParentId=4, Text="气耗",IconClass= "fa fa-legal", LinkUrl="/Energy/Gas"},
                    new Menu{Id=44,ParentId=4, Text="报表",IconClass= "fa fa-legal", LinkUrl="/Energy/Report"},

                    new Menu{Id=441,ParentId=41, Text="分项", IconClass = "icon-bar-chart" ,LinkUrl="/Energy/ElectricItem"},
                    new Menu{Id=442,ParentId=41, Text="支路", IconClass = "icon-bar-chart" ,LinkUrl="/Energy/ElectricBranch"},
                    new Menu{Id=443,ParentId=41, Text="分户", IconClass = "icon-bar-chart" ,LinkUrl="/Energy/ElectricUnit"}

                   ,new Menu{Id = 200,ParentId=2,Text="基本信息",IconClass= "icon-user", LinkUrl="" },
                    new Menu {Id = 210, ParentId = 200, Text = "区域管理", IconClass = "icon-user", LinkUrl = "/BaseInfo/Area" },
                    new Menu {Id = 211, ParentId = 200, Text = "单位信息", IconClass = "icon-user", LinkUrl = "/BaseInfo/Units" },
                    new Menu {Id = 212, ParentId = 200, Text = "建筑信息", IconClass = "icon-user", LinkUrl = "/BaseInfo/Build" },
                    new Menu {Id = 213, ParentId = 200, Text = "采集器", IconClass = "icon-user", LinkUrl = "/BaseInfo/Collector" },
                    new Menu {Id = 214, ParentId = 200, Text = "采集命令", IconClass = "icon-user", LinkUrl = "/BaseInfo/CollectorCMD" },
                    new Menu {Id = 215, ParentId = 200, Text = "分项信息", IconClass = "icon-user", LinkUrl = "/BaseInfo/Item" },
                    new Menu {Id = 216, ParentId = 200, Text = "支路信息", IconClass = "icon-user", LinkUrl = "/BaseInfo/Branch" }

                };
                CacheHelper.SetCache("MenusAll", result, DateTime.Now.AddMinutes(SystemConfig.SysCacheTime), TimeSpan.Zero); //插入cache 缓存30分钟
            }
            return result;
        } 
        /// <summary>
        /// 获取所有显示的菜单列表-注：有些菜单在界面中是不显示的
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Menu> GetShowMenus()
        {
            foreach (var menu in GetAllMenus())
            {
                if (menu.IsHidden==false)
                    yield return menu;
            }
        }
        #endregion
        #region 动态加载界面标题头
        /// <summary>
        /// 动态构造页面head
        /// </summary>
        /// <param name="menuId">左侧选中的菜单Id</param>
        /// <returns></returns>
        public string GetHead(int menuId)
        {
            var menu = GetAllMenus().Where(x => x.Id == menuId).FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<li>
            <i class='icon-home'></i>
            <a class='nav-link' id='page_Home' href='/Home'>首页</a>
            <i class='fa fa-angle-right'></i>");
            List<string> lst = new List<string>();
            if (menu != null)
            {
                GetParentHead(menu, sb, lst);
                if (lst.Count > 0)
                {
                    var array = lst.ToArray();
                    var result = array.Reverse();
                    foreach (var v in result)
                    {
                        sb.Append(v);
                    }
                }
                string strLeaveIcon = string.IsNullOrEmpty(menu.IconClass) ? string.Empty : string.Format("<i class='{0}'></i>", menu.IconClass);
                sb.AppendFormat(@"</li><li>{1}<span>{0}</span>", menu.Text, strLeaveIcon);
            }
            else
            {
                sb.Append("</li>");
            }
            return sb.ToString();
        }
        private void GetParentHead(Menu menu, StringBuilder sb, List<string> lst)
        {
            var result = GetAllMenus().Where(x => x.Id == menu.ParentId).FirstOrDefault();
            if (result != null)
            {
                string str = string.Empty;
                if (!string.IsNullOrEmpty(result.IconClass))
                {
                    str += string.Format("<i class='{0}'></i>", result.IconClass);
                }
                str += string.Format("<span>{1}</span><i class='fa fa-angle-right'></i>", result.LinkUrl, result.Text);
                lst.Add(str);
                GetParentHead(result, sb, lst);
            }
        }
        #endregion
    }
}
