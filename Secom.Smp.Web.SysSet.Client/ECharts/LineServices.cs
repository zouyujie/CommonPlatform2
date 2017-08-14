/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Clients.Admin.ECharts
* 文件名: LineServices
* 创建者: 邹琼俊
* 创建时间: 2017/7/20 15:23:29
* 版权所有： 紫衡技术
******************************************************************/
using Newtonsoft.Json.Linq;
using Secom.Smp.ECharts;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.axis;
using Secom.Smp.ECharts.Entities.series;
using Secom.Smp.Common.EChartsUtil;
using System.Collections.Generic;
using System.Linq;
using Secom.Smp.ECharts.Entities.style;
using Secom.Smp.Common;

namespace Secom.Smp.Web.SysSet.Client.ECharts
{
    public class LineServices : IEChartsServices
    {
        public string GetOptions()
        {
            IList<int> datas1 = ChartsUtil.Datas(9, 200, 3500); //电数据
            string strColor1 = "#58d0da";
            string strColor2 = "orange";

            IList<int> datas2 = ChartsUtil.Datas(24, 200, 3500); //环比数据

            int min = datas2.Min();
            int index = datas2.IndexOf(min);

            ChartOption option = new ChartOption();

            option.title = new List<Title>(){new Title()
            {
                show = true,
                text = "逐时能耗",
                //subtext = ""
            }};

            option.tooltip = new ToolTip()
            {
                trigger = TriggerType.axis,
                //formatter="{a0}: {c0}kwh<br />时间："+DateTime.Now.ToDateStr()+ " {b0}时<br/>{a1}: {c1}kwh"
            };
            //设置为方形、设置颜色为绿色
            //设置颜色为橙色
            string strLegend = @"[{
    name: '电',
    icon: 'rect',
    textStyle: {
        color: '"+strColor1+@"'
    }
},{
    name: '环比',
    textStyle: {
        color: '"+ strColor2+@"'
    }
}]";
            var legendData = new JRaw(strLegend);
            option.legend = new Legend()
            {
                data = legendData
            };

            option.calculable = true;
            //X坐标
            option.xAxis = new List<Axis>()
         {
        //     new CategoryAxis()
        //     {
        //         type = AxisType.category,
        //         //boundaryGap= false,
        //         data = new JRaw(@"['00','02','04','06','08','10','12','14','16','18','20','22']")
        //},
             new CategoryAxis()
             {
                 type = AxisType.category,
                 data = new JRaw(@"['00','01','02','03','04','05','06','07','08','09','10','11','12',
      '13','14','15','16','17','18','19','20','21','22','23']"),
                axisLabel=new AxisLabel(){interval=1},
                axisTick=new AxisTick() {alignWithLabel=true}
        }
         };
            //Y坐标
            option.yAxis = new List<Axis>()
         {
             new ValueAxis()
             {
                 name="单位：[KWh]",
                 type = AxisType.value,
                 data = new JRaw(@"[0,500,1000,1500,2000,2500,3000,3500]"),
                // axisLabel = new AxisLabel(){
                //  formatter=new JRaw("{value}kwh").ToString()
                //}
             }
         };
            option.series = new List<object>()
         {
                 new Bar()
                 {
                     name = "电",
                     type =  ChartType.bar,
                     data =  datas1,
                     itemStyle=new ItemStyle() { normal=new Normal()
                     {
                         color=strColor1
                     }
                     },
                     markPoint =  new MarkPoint()
                     {
                             data = new List<object>()
                             {
                                 new MarkData()
                                 {
                                      name = "最大值",
                                      type= MarkType.max,
                                 },
                                 new MarkData()
                                 {
                                      name = "最小值",
                                      type= MarkType.min,
                                 }
                             }
                     },
                     markLine = new MarkLine()
                     {
                             data = new List<object>()
                             {
                                  new MarkData()
                                  {
                                       name = "平均值",
                                       type = MarkType.average
                                  }
                             }
                    }
           },
           new Line(){
             name="环比",
             //xAxisIndex=1,
             type = ChartType.line,
             data = datas2,
                    itemStyle=new ItemStyle() { normal=new Normal()
                     {
                         color=strColor2
                     }
                     },
             markLine = new MarkLine(){
             data = new List<object>(){
                new MarkData(){
                 type = MarkType.average,
                 name = "平均值"
                }
             }
            }
           }
         };
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
    }
}
