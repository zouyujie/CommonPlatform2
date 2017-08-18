//# sourceURL=index.js
//初始化能耗统计模块的信息(能耗类型)
function getName(name,arr) {
    var result = "";
    switch (name) {
        case "空调用电":
            result = arr[0];
            break;
        case "照明插座用电":
            result = arr[1];
            break;
        case "动力用电":
            result = arr[2];
            break;
        default:
            result = arr[3];
            break;
    }
    return result;
}
function initAlarmTotal(type) {
    //模板数据绑定(ajax数据地址，模板ids数组，容器ids数据）
    tmplBindList("/OverView/GetAlarmTotalInfo?type=" + type, new Array("monthTemplate", "yearTemplate"), new Array("monthAlarmInfo", "yearAlarmInfo"));
    InitEChartList("/OverView/GetECTotalOptions?type=" + type, new Array("monthEC", "yearEC")); //本月总能耗、本年总能耗
    InitChart("/OverView/GetHourTotalOptions?type=" + type, "divAlarmTotal"); //逐时能耗、柱状图统计

    InitEChartList("/OverView/GetECTotalOptionsNew?type=" + type, new Array("monthECNew", "yearECNew")); //本月总能耗、本年总能耗
}
$(function () {
    /*--------------------------安全管理--------------------------------*/
    tmplBind("/OverView/PublicLighting", "publicLightingTemplate", "publicLightingContainer", "table_publicLighting_processing");//获取公共照明数据
    tmplBind("/OverView/AirList", "airConditionTemplate", "airConditionContainer", "table_airCondition_processing"); //暖通空调数据

    function getInitOptions() {
        var options = clone(DataTablesObj.options);//复杂配置项，要使用深拷贝
        options.paging = false; //取消分页
        options.ordering = false; //取消排序
        return options;
    }
    var myOptions = new Array()
    options = getInitOptions();
    //变配电
    options.columns = [
      { "data": "TName", title: "名称" },
      { "data": "TName1", title: "1T" },
      { "data": "TName2", title: "2T" },
      { "data": "TName3", title: "3T" },
      { "data": "TName4", title: "4T" },
      { "data": "TName5", title: "5T" },
      { "data": "TName6", title: "6T" },
      { "data": "TName7", title: "7T" },
      { "data": "TName8", title: "8T" },
      { "data": "TName9", title: "9T" }
    ];
    options.sAjaxSource = "/OverView/Transformer"; //数据源地址
    myOptions[0] = options;
    options = getInitOptions();
    //医用冷链
    options.columns = [
       { "data": "Test", title: "名称" },
       { "data": "Test1", title: "一号楼" },
       { "data": "Test2", title: "二号楼" },
        { "data": "Test3", title: "三号楼" },
       { "data": "Test4", title: "四号楼" }
    ];
    options.sAjaxSource = "/OverView/ColdChains"; //数据源地址
    myOptions[1] = options;
    DataTablesObj.initList(myOptions, new Array("table_transformer", "table_coldChains"));//批量初始化Datatables，注意两个数组集合的顺序要对上
    /*--------------------------运维管理--------------------------------*/
    InitEChartList("/OverView/GetTotalOptions", new Array("repairTotal", "visitTotal", "maintainTotal")); //批量初始化，合并请求加载（维修统计，巡检统计，保养统计）
    /*--------------------------能耗统计--------------------------------*/
    initAlarmTotal(0);
    //多个图表响应式支持
    //ResizeECharts(new Array("repairTotal", "visitTotal", "maintainTotal", "monthEC", "yearEC", "divAlarmTotal"));
    //ResizeECharts(new Array("monthECNew", "yearECNew"));
    $("#btnElectricity").focus();//电耗自动聚焦
})