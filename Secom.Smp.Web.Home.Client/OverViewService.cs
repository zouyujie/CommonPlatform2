/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Home.Client
* 文件名: OverViewService
* 创建者: 邹琼俊
* 创建时间: 2017/8/9 9:19:30
* 版权所有： 紫衡技术
******************************************************************/
using Newtonsoft.Json.Linq;
using Secom.Smp.Common;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ViewModel.Home;
using System.Collections.Generic;

namespace Secom.Smp.Web.Home.Client
{
    public class OverViewService
    {
        public List<RepairOrder> GetDataList()
        {
         return new List<RepairOrder>() { new RepairOrder { RepairFinish=332,RepairNoFinish=140},
                new RepairOrder { RepairFinish = 86, RepairNoFinish = 16 }, new RepairOrder { RepairFinish = 22, RepairNoFinish = 5 }};
        }
        /// <summary>
        /// 合并为一次请求后调用
        /// </summary>
        /// <returns></returns>
        public string GetTotalOptions()
        {
            var lst = GetDataList();
            if (lst != null && GetDataList().Count == 3)
            {
                return "["
                    + GetOperationsOptions("维修计划", lst[0].RepairFinish, lst[0].RepairNoFinish, "orange", "#94A0B2") + ","
                    + GetOperationsOptions("巡检计划", lst[1].RepairFinish, lst[1].RepairNoFinish, "#3598dc", "#94A0B2") + ","
                    + GetOperationsOptions("保养计划", lst[2].RepairFinish, lst[2].RepairNoFinish, "#44b6ae", "#94A0B2") + "]";
            }
            else
            {
                return string.Empty;
            }
        }
        #region 能耗统计
        public string GetMonthECTotalOptions()
        {
            return GetECOptions(22, 5, "#44b6ae", "#94A0B2");
        }
        public string GetYearECTotalOptions()
        {
            return GetECOptions(22, 5, "#44b6ae", "#94A0B2");
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="done">已完成单数</param>
        /// <param name="noDone">未完成单数</param>
        /// <param name="doneColor">已完成颜色</param>
        /// <param name="noDoneColor">未完成颜色</param>
        /// <returns></returns>
        public string GetOperationsOptions(string title,int done, int noDone,string doneColor,string noDoneColor)
        {
            ChartOption option = new ChartOption();
            option.color = new JRaw(string.Format("['{0}', '{1}']",doneColor,noDoneColor));
            option.series = new JRaw(@"[{
             name: '访问来源',
             type: 'pie',
             radius: ['70%', '83%'],//这里是控制环形内半径和外半径
             center: ['50%', '50%'], //设置圆心
             avoidLabelOverlap: false,
             hoverAnimation:false,//此处查了好久属性//控制鼠标放置在环上时候的交互
             label: {
                 normal: {
                     show: true,
                     position: 'center',
                     textStyle: {
                         fontSize: '16',
                         fontWeight: 'bold'
                     }
                 }
             },
             data: [
                {
                     value:" + done + @",
                     name: '已完成',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '" + (done+noDone) + @"\n',
                       
                         textStyle: {
                            fontSize: '24',
                            baseline : 'top',
                            color: '#2f353b'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value: " + noDone + @",
                     name: '未完成',
                      itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                         formatter : '\n\n\n"+ title+@"',
                         textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 }
             ]
         }]");
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
        public string GetECOptions(int done, int noDone, string doneColor, string noDoneColor)
        {
            ChartOption option = new ChartOption();
            option.color = new JRaw(string.Format("['{0}', '{1}']", doneColor, noDoneColor));
            option.series = new JRaw(@"[{
             name: '访问来源',
             type: 'pie',
             radius: ['70%', '83%'],//这里是控制环形内半径和外半径
             center: ['50%', '50%'], //设置圆心
             avoidLabelOverlap: false,
             hoverAnimation:false,//此处查了好久属性//控制鼠标放置在环上时候的交互
             label: {
                 normal: {
                     show: true,
                     position: 'center',
                     textStyle: {
                         fontSize: '16',
                         fontWeight: 'bold'
                     }
                 }
             },
             data: [
                {
                     value:" + done + @",
                     name: '已完成',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '" + (done + noDone) + @"\n',
                       
                         textStyle: {
                            fontSize: '24',
                            baseline : 'top',
                            color: '#2f353b'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value: " + noDone + @",
                     name: '未完成',
                      itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                         formatter : '\n\n\n维修计划',
                         textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 }
             ]
         }]");
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
    }
}
