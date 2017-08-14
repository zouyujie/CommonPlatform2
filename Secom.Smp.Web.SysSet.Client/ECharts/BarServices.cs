/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.SysSet.Client.ECharts
* 文件名: BarServices
* 创建者: 邹琼俊
* 创建时间: 2017/7/21 11:43:34
* 版权所有： 紫衡技术
******************************************************************/
using Newtonsoft.Json.Linq;
using Secom.Smp.Common;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.axis;
using Secom.Smp.ECharts.Entities.feature;
using Secom.Smp.ECharts.Entities.series;
using Secom.Smp.ECharts.Entities.style;
using System.Collections.Generic;

namespace Secom.Smp.Web.SysSet.Client.ECharts
{
    public class BarServices: IEChartsServices
    {
        public string GetOptions()
        {
            ChartOption option = new ChartOption();
            option.Title().Text("温度计式图表").Subtext("我是小标题").
                Sublink("http://www.baidu.com");
            option.ToolTip().Trigger(TriggerType.axis)
             .Formatter(new JRaw(@"function (params){
            return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + '<br/>'
                   + params[1].seriesName + ' : ' + (params[1].value + params[0].value);
            }"))
             .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("实际温度", "预计温度");
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            option.Grid().Y(80).Y2(30);
            CategoryAxis x = new CategoryAxis();
            x.Data("北京", "上海", "深圳", "长沙", "广州", "武汉");
            option.XAxis(x);
            ValueAxis y = new ValueAxis();
            y.BoundaryGap(new List<double>() { 0, 0.1 });
            option.YAxis(y);

            var tomatoStyle = new ItemStyle();
            tomatoStyle.Normal().Color("tomato").BarBorderRadius(0)
                .BarBorderColor("tomato").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.insideTop);
            Bar b1 = new Bar("实际温度");
            b1.Stack("sum");
            b1.SetItemStyle(tomatoStyle);
            b1.Data(27, 25, 32, 39, 26, 35);

            var forecastStyle = new ItemStyle();
            forecastStyle.Normal().Color("#fff").BarBorderRadius(0)
                .BarBorderColor("tomato").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.top)
                .Formatter(new JRaw(@"function (params) {
                            for (var i = 0, l = option.xAxis[0].data.length; i < l; i++) {
                                if (option.xAxis[0].data[i] == params.name) {
                                    return option.series[0].data[i] + params.value;
                                }
                            }
                        }"))
                        .TextStyle().Color("tomato");

            Bar b2 = new Bar("预计温度");
            b2.Stack("sum");
            b2.SetItemStyle(forecastStyle);
            b2.Data(27.5, 26, 30, 41, 24, 33);

            option.Series(b1, b2);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }
    }
}
