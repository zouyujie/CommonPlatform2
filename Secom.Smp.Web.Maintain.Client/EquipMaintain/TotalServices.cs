using Newtonsoft.Json.Linq;
using Secom.Smp.Common;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.axis;
using Secom.Smp.ECharts.Entities.feature;
using Secom.Smp.ECharts.Entities.series;
using Secom.Smp.ECharts.Entities.style;
using System.Collections.Generic;

namespace Secom.Smp.Web.Maintain.Client
{
    public class TotalServices
    {
        public string GetOptions()
        {
            var xList = new List<string> { "张明", "李涛", "王军", "刘浩", "赵鑫", "孙文" };
            var yList1 = new List<int> { 40, 37, 57, 28, 88, 18 };
            var yList2 = new List<int> { 10, 33, 5, 10, 2, 4 };

            ChartOption option = new ChartOption();
            option.Title().Text("班组人员工作量统计").
                Sublink("http://www.baidu.com");
            option.ToolTip().Trigger(TriggerType.axis)
             .Formatter(new JRaw(@"function (params){
            return params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value + '<br/>'
                   + params[1].seriesName + ' : ' + (params[1].value + params[0].value);
            }"))
             .AxisPointer().Type(AxisPointType.shadow);
            option.Legend().Data("已完成工作量", "工作量总数").Top("2px").Left("180px");
            Feature feature = new Feature();
            feature.Mark().Show(true);
            feature.DataView().Show(true).ReadOnly(false);
            feature.Restore().Show(true);
            feature.SaveAsImage().Show(true);
            option.ToolBox().Show(true).SetFeature(feature);
            option.Grid().Y(60).Y2(30).X(30);
            CategoryAxis x = new CategoryAxis();
            x.data= xList;
            option.XAxis(x);
            ValueAxis y = new ValueAxis();
            y.BoundaryGap(new List<double>() { 0, 0.1 });
            option.YAxis(y);

            var tomatoStyle = new ItemStyle();
            tomatoStyle.Normal().Color("#53adfd").BarBorderRadius(0)
                .BarBorderColor("#53adfd").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.insideTop);
            Bar b1 = new Bar("已完成工作量");
            b1.Stack("sum");
            b1.SetItemStyle(tomatoStyle);
            b1.data = yList1;

            var forecastStyle = new ItemStyle();
            forecastStyle.Normal().Color("#e9edef").BarBorderRadius(0)
                .BarBorderColor("#e9edef").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.top)
                .Formatter(new JRaw(@"function (params) {
                            for (var i = 0, l = option.xAxis[0].data.length; i < l; i++) {
                                if (option.xAxis[0].data[i] == params.name) {
                                    return option.series[0].data[i] + params.value;
                                }
                            }
                        }"))
                        .TextStyle().Color("#e9edef");

            Bar b2 = new Bar("工作量总数");
            b2.Stack("sum");
            b2.SetItemStyle(forecastStyle);
            b2.data= yList2;

            option.Series(b1, b2);

            var result =  JsonTools.ObjectToJson2(option);
            return result;
        }
    }
}
