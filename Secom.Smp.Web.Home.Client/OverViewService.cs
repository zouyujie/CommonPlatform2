/******************************************************************
* Copyright (C): http://www.cnsecom.com/
* CLR版本: 4.0.30319.42000
* 命名空间名称: Secom.Smp.Web.Home.Client
* 文件名: OverViewService——首页概览界面业务逻辑类
* 创建者: 邹琼俊
* 创建时间: 2017/8/9 9:19:30
* 版权所有： 紫衡技术
******************************************************************/
using Newtonsoft.Json.Linq;
using Secom.Smp.Common;
using Secom.Smp.Common.EChartsUtil;
using Secom.Smp.ECharts.Entities;
using Secom.Smp.ECharts.Entities.axis;
using Secom.Smp.ECharts.Entities.series;
using Secom.Smp.ECharts.Entities.style;
using Secom.Smp.ViewModel.Enums;
using Secom.Smp.ViewModel.Home;
using System.Collections.Generic;

namespace Secom.Smp.Web.Home.Client
{
    public class OverViewService
    {
        #region 模拟数据
        /// <summary>
        /// 页面基础信息
        /// </summary>
        /// <returns></returns>
        public TestModel GetBaseInfo()
        {
            var introduction = @" 
       医院现有职工5869人，正高职称277人，副高职称513人、中级职称1158人；年门急诊量突破490万人次，开放病床2850张，年住院手术人数达7.18 万人次，出院人次达10.61万人次，
病床使用率达95%以上，直接服务病人的范围从广州、广东走向华南地区，并辐射全国、东南亚乃至世界各国。长期以来，医院充分发挥医疗技术力量雄厚的优势，
不断采用各种新技术成功诊断、治疗和抢救了许多危重、疑难和罕见病例，如：成功开展国内首例肾移植手术、首例断趾再植手术；成功实施世界第八例、中国第一例连体婴分离手术；
成功实现国内首例第三代试管婴儿的诞生；成功施行三足婴矫正手术、全国首例连头婴分离手术（被评为2001年中国卫生界十件大事之一）；
成功实施亚洲首例肝肾联合移植手术、首例多器官移植手术（被评为 2004 中国医药科技十大新闻之一）；成功实施国内首例、世界罕见胸腹主动脉瘤、升主动脉夹层动脉瘤腔内治疗手术；
成功开展全球首例异基因脐血干细胞移植治疗假肥大型肌营养不良症术；成功施行国内首例最小年龄心肺联合移植手术、国内首例母子亲体小肠移植术、国内首例在心跳不停的情况下切开心房取出癌栓术、
国内首例双胎输血综合征宫内治疗术；成功救治华南地区首例、国内罕见巨大颌骨肿瘤患者；成功开展DBS手术治疗帕金森病，达国际先进水平；成功发现全国首例 A型胰岛素抵抗综合征；
成功施行世界上年龄最小幼儿（17月）巨大腹主动脉瘤术；成功实施华南地区首例成人右半肝活体肝移植手术、亲属活体双肝移植术、国内首例保留胰腺器官簇移植术等，这些令人瞩目的辉煌成就，
为我国医疗界填补了许多空白。在复旦大学医院管理研究所评审发布的2013年度最佳医院排行榜（综合）中，医院位于全国前10名；在北京大学于2015年5月发布的中国最佳临床学科评估排行榜（共19个专科）中，
我院14个专科进入前15名，数量位列广东第一、全国第四。";
            return new TestModel { Name0 = introduction, Name1 = "/Upload/Organization/1.png" };
        }
        /// <summary>
        /// 运维管理基本信息
        /// </summary>
        /// <returns></returns>
        public List<RepairOrder> GetDataList()
        {
            return new List<RepairOrder>() { new RepairOrder { RepairFinish=332,RepairNoFinish=140},
                new RepairOrder { RepairFinish = 86, RepairNoFinish = 16 }, new RepairOrder { RepairFinish = 22, RepairNoFinish = 5 }};
        }
        /// <summary>
        /// 月能耗统计基本信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<TestModel> GetMonthECDataList(AlarmTypeEnum type)
        {
            List<TestModel> lstMonth = null;
            switch (type)
            {
                case AlarmTypeEnum.Water:
                    lstMonth = new List<TestModel>() {
            new TestModel { Value = 1106, Name1 = "5%" },
            new TestModel { Value = 928, Name1 = "12%" },
            new TestModel { Value = 82, Name1 = "13%" },
            new TestModel { Value = 574, Name1 = "8%" }};
                    break;
                case AlarmTypeEnum.Air:
                    lstMonth = new List<TestModel>() {
            new TestModel { Value = 606, Name1 = "5%" },
            new TestModel { Value = 728, Name1 = "11%" },
            new TestModel { Value = 582, Name1 = "16%" },
            new TestModel { Value = 174, Name1 = "12%" }};
                    break;
                default: //Electricity
                    lstMonth = new List<TestModel>() {
            new TestModel { Value = 2106, Name1 = "5%" },
            new TestModel { Value = 1928, Name1 = "11%" },
            new TestModel { Value = 982, Name1 = "16%" },
            new TestModel { Value = 1574, Name1 = "18%" }};
                    break;
            }
            return lstMonth;
        }
        /// <summary>
        /// 年能耗统计基本信息
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<TestModel> GetYearECDataList(AlarmTypeEnum type)
        {
            List<TestModel> lstYear = null;
            switch (type)
            {
                case AlarmTypeEnum.Water:
                    lstYear = new List<TestModel>() {
            new TestModel { Value = 11106, Name1 = "5%" },
            new TestModel { Value = 9280, Name1 = "12%" },
            new TestModel { Value = 820, Name1 = "13%" },
            new TestModel { Value = 5740, Name1 = "8%" }};
                    break;
                case AlarmTypeEnum.Air:
                    lstYear = new List<TestModel>() {
            new TestModel { Value = 6606, Name1 = "5%" },
            new TestModel { Value = 7280, Name1 = "11%" },
            new TestModel { Value = 5820, Name1 = "16%" },
            new TestModel { Value = 1740, Name1 = "12%" }};
                    break;
                default: //Electricity
                    lstYear = new List<TestModel>() {
            new TestModel { Value = 21060, Name1 = "5%" },
            new TestModel { Value = 19280, Name1 = "11%" },
            new TestModel { Value = 9820, Name1 = "16%" },
            new TestModel { Value = 15740, Name1 = "18%" }};
                    break;
            }

            return lstYear;
        } 

        #endregion

        #region 运维管理

        /// <summary>
        /// 运维管理报表配置项——合并为一次请求后调用
        /// </summary>
        /// <returns></returns>
        public string GetTotalOptions()
        {
            var lst = GetDataList();
            if (lst != null && GetDataList().Count == 3)
            {
                return "["
                    + GetOptions("维修计划", lst[0].RepairFinish, lst[0].RepairNoFinish, "#FFB940", "#94A0B2") + ","
                    + GetOptions("巡检计划", lst[1].RepairFinish, lst[1].RepairNoFinish, "#6BA7F0", "#94A0B2") + ","
                    + GetOptions("保养计划", lst[2].RepairFinish, lst[2].RepairNoFinish, "#5ABE9C", "#94A0B2") + "]";
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 获取报表配置选项
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="done">已完成单数</param>
        /// <param name="noDone">未完成单数</param>
        /// <param name="doneColor">已完成颜色</param>
        /// <param name="noDoneColor">未完成颜色</param>
        /// <returns></returns>
        private string GetOptions(string title, int done, int noDone, string doneColor, string noDoneColor)
        {
            ChartOption option = new ChartOption();
            option.color = new JRaw(string.Format("['{0}', '{1}']", doneColor, noDoneColor));
            option.series = new JRaw(@"[{
             name: '访问来源',
             type: 'pie',
             radius: ['65%', '78%'],//这里是控制环形内半径和外半径
             center: ['50%', '50%'], //设置圆心
             avoidLabelOverlap: false,
             hoverAnimation:false,//此处查了好久属性//控制鼠标放置在环上时候的交互
             label: {
                 normal: {
                     show: true,
                     position: 'center',
                     textStyle: {
                         fontSize: '16'
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
                            fontWeight: 'bold',
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
                         formatter : '\n\n\n" + title + @"',
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

        #endregion

        #region 能耗统计
        /// <summary>
        /// 暖通空调
        /// </summary>
        /// <returns></returns>
        public TestModel1 AirList()
        {
            return new TestModel1() { TName = "0", TName0 = "4", TName1 = "20", TName2 = "24", TName3 = "10", TName4 = "14", TName5 = "15", TName6 = "19",TName7 = "0",TName8 = "0",TName9 = "0",TName10 = "1"};
        }
        /// <summary>
        /// 公共照明
        /// </summary>
        /// <returns></returns>
        public TestModel1 PublicLighting()
        {
            return new TestModel1() { TName = "153", TName0 = "240", TName1 = "120", TName2 = "140", TName3 = "110", TName4 = "140", TName5 = "105", TName6 = "120" };
        }
        /// <summary>
        /// 变配电
        /// </summary>
        /// <returns></returns>
        public List<TestModel1> Transformer()
        {
            return new List<TestModel1>() { new TestModel1 { TName = "负载率", TName1 = "3B", TName2 = "4B", TName3 = "5B", TName4 = "7B",TName5="20%",TName6="20%",TName7="20%",TName8="20%",TName9="20%" },
             new TestModel1 { TName = "报警", TName1 = "0", TName2 = "0", TName3 = "0", TName4 = "0" ,TName5="0",TName6="0",TName7="0",TName8="0",TName9="0"}};
        }
        /// <summary>
        /// 医用冷链
        /// </summary>
        /// <returns></returns>
        public List<TestModel2> ColdChains()
        {
            return new List<TestModel2>() { new TestModel2 { Test = "温度", Test1 = "3C", Test2 = "4C", Test3 = "5C", Test4 = "7C" },
             new TestModel2 { Test = "报警",Test1 = "0", Test2 = "0", Test3 = "0", Test4 = "0" }};
        }
        /// <summary>
        /// 根据类型获取能耗统计基础数据
        /// </summary>
        /// <param name="type">能耗类型</param>
        /// <returns></returns>
        public TestModel1 GetAlarmTotalInfo(AlarmTypeEnum type)
        {
            TestModel1 model = null;
            switch (type)
            {
                case AlarmTypeEnum.Water:
                    model = new TestModel1()
                    {
                        TName = "3101",
                        TName0 = "15%",
                        TName1 = "928",
                        TName2 = "14%",
                        TName3 = "482",
                        TName4 = "16%",
                        TName5 = "1374",
                        TName6 = "2%",
                        TName7 = "2106",
                        TName8 = "1%",
                        TName9 = "1928",
                        TName10 = "2%",
                        TName11 = "1482",
                        TName12 = "13%",
                        TName13 = "21574",
                        TName14 = "4%"
                    };
                    break;
                case AlarmTypeEnum.Air:
                    model = new TestModel1()
                    {
                        TName = "4106",
                        TName0 = "7%",
                        TName1 = "1928",
                        TName2 = "14%",
                        TName3 = "682",
                        TName4 = "12%",
                        TName5 = "974",
                        TName6 = "6%",
                        TName7 = "17106",
                        TName8 = "1%",
                        TName9 = "11228",
                        TName10 = "21%",
                        TName11 = "1482",
                        TName12 = "13%",
                        TName13 = "31574",
                        TName14 = "18%"
                    };
                    break;
                default:
                    model = new TestModel1()
                    {
                        TName = "2106",
                        TName0 = "5%",
                        TName1 = "1928",
                        TName2 = "11%",
                        TName3 = "982",
                        TName4 = "16%",
                        TName5 = "1574",
                        TName6 = "8%",
                        TName7 = "12106",
                        TName8 = "1%",
                        TName9 = "11928",
                        TName10 = "2%",
                        TName11 = "1982",
                        TName12 = "3%",
                        TName13 = "11574",
                        TName14 = "14%"
                    };
                    break;
            }
         
            return model;
        }
        /// <summary>
        /// 能耗统计报表配置项
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetECTotalOptions(AlarmTypeEnum type)
        {
            return "["
                + GetECOptions("本月总能耗", GetMonthECDataList(type)) + ","
                + GetECOptions("本年总能耗", GetYearECDataList(type)) + "]";
        }
        public string GetECTotalOptionsNew(AlarmTypeEnum type)
        {
            return "["
                + GetECOptionsNew("本月总能耗", GetMonthECDataList(type)) + ","
                + GetECOptionsNew("本年总能耗", GetYearECDataList(type)) + "]";
        }
        /// <summary>
        /// 获取能耗报表配置选项
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="data">数据集合</param>
        /// <returns></returns>
        private string GetECOptions(string title, List<TestModel> data)
        {
            ChartOption option = new ChartOption();
            option.color = new JRaw("['#FA6F74', '#FDD566','#6ED1A2','#6CBEF6']");
            option.series = new JRaw(@"[{
             name: '访问来源',
             type: 'pie',
             radius: ['50%', '65%'],//这里是控制环形内半径和外半径
             center: ['50%', '50%'], //设置圆心
             avoidLabelOverlap: false,
             hoverAnimation:false,//此处查了好久属性//控制鼠标放置在环上时候的交互
             label: {
                 normal: {
                     show: true,
                     position: 'center',
                     textStyle: {
                         fontSize: '16'
                     }
                 }
             },
             data: [
                {
                     value:" + data[0].Value + @",
                     name: '空调用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '" + title+ @"\n\n\n\n\n',
                          textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value: " + data[1].Value + @",
                     name: '照明插座用电',
                      itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '\n\n" + data[0].Value + @"\n\n',
                          textStyle: {
                            fontSize: '26',
                            fontWeight: 'bold',
                            baseline : 'top',
                            color: '#2f353b'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value:" + data[2].Value + @",
                     name: '动力用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',   
                          formatter : '\n\n\n\n\nkWh',              
                         textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value:" + data[3].Value + @",
                     name: '特殊用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : false
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

        /// <summary>
        /// 获取能耗报表配置选项
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="data">数据集合</param>
        /// <returns></returns>
        private string GetECOptionsNew(string title, List<TestModel> data)
        {
            string str = "new Array(";
            string strPercent= "new Array(";
            foreach (var v in data)
            {
                str += v.Value + ",";
                strPercent += "'"+v.Name1 + "',";
            }
            str.TrimEnd(',');
            str += ")";
            strPercent.TrimEnd(',');
            strPercent += ")";

            string tag = title.Contains("年") ? "年高" : "月高";

            ChartOption option = new ChartOption();
            option.color = new JRaw("['#FA6F74', '#FDD566','#6ED1A2','#6CBEF6']");
            option.ToolTip().Trigger(TriggerType.item).Formatter("{b}: {c}kw/h ({d}%)");
            var legendFormartter = new JRaw(@" function (name) {
                        return name +'\n\n'+ getName(name,"+ str + ")+ 'kwh 比上"+ tag+"'+getName(name,"+strPercent+");}");
            option.Legend().ItemWidth(5).ItemHeight(38).Align(HorizontalType.left).ItemGap(15).Top("15px").Left("60%").Orient(OrientType.vertical).X(HorizontalType.right)
                .Formatter(legendFormartter).Data( "空调用电", "照明插座用电","动力用电", "特殊用电");

            Pie pie = new Pie();
            pie.Center(new List<string>() { "30%", "50%" }).Radius(new List<string>() { "50%", "65%" }).HoverAnimation(false).AvoidLabelOverlap(false).
                Label().Normal().Show(false).Position(StyleLabelTyle.center).LabelLine().Show(false);

            pie.data = new JRaw(@"[
                {
                     value:" + data[0].Value + @",
                     name: '空调用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '" + title + @"\n\n\n\n\n',
                          textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value: " + data[1].Value + @",
                     name: '照明插座用电',
                      itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',
                          formatter : '\n\n" + data[0].Value + @"\n\n',
                          textStyle: {
                            fontSize: '26',
                            fontWeight: 'bold',
                            baseline : 'top',
                            color: '#2f353b'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value:" + data[2].Value + @",
                     name: '动力用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : true,
                          position : 'center',   
                          formatter : '\n\n\n\n\nkWh',              
                         textStyle: {
                            fontSize: '14',
                            baseline : 'top',
                            color: '#94A0B2'
                        }
                    },
                    labelLine : {
                        show : false
                    }}}
                 },
                 {
                     value:" + data[3].Value + @",
                     name: '特殊用电',
                     itemStyle : {//上层样式
                        normal : {
                          label : {
                          show : false
                    },
                    labelLine : {
                        show : false
                    }}}
                 }
             ]");
            option.Series(pie);
            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        /// <summary>
        /// 获取近三日逐时能耗配置
        /// </summary>
        /// <param name="type">能耗类型</param>
        /// <returns></returns>
        public string GetHourTotalOptions(AlarmTypeEnum type)
        {
            var xList = ChartsUtil.Datas(72, 1, 24);
            var yList1 =ChartsUtil.Datas(72, 200, 8000); //能耗数据

            ChartOption option = new ChartOption();
            option.Title().Text("近三日逐时能耗柱状图").SubText("（单位：kwh）").Left("48%").TextAlign(HorizontalType.center);
            option.ToolTip().Trigger(TriggerType.axis)
             .Formatter(new JRaw(@"function (params){
            return '时间：'+params[0].name + '<br/>'
                   + params[0].seriesName + ' : ' + params[0].value;
            }"))
             .AxisPointer().Type(AxisPointType.shadow);
            //option.Legend().Data("能耗").Top("2px").Left("180px");
            option.Grid().Y(60).Y2(30).X(45).X2(5);
            CategoryAxis x = new CategoryAxis();
            x.data = xList;
            x.axisTick = new AxisTick() { alignWithLabel = true };
            option.XAxis(x);
            ValueAxis y = new ValueAxis();
            y.BoundaryGap(new List<double>() { 0, 0.1 });
            option.YAxis(y);

            var tomatoStyle = new ItemStyle();
            tomatoStyle.Normal().Color("#987CB7").BarBorderRadius(0)
                .BarBorderColor("#987CB7").BarBorderWidth(6)
                .Label().Show(true).Position(StyleLabelTyle.insideTop);
            Bar b1 = new Bar("能耗");
            //b1.Stack("sum");
            b1.SetItemStyle(tomatoStyle);
            b1.data = yList1;

            option.Series(b1);

            var result = JsonTools.ObjectToJson2(option);
            return result;
        }

        #endregion
    }
}
