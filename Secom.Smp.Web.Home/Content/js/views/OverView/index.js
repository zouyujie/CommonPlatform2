$(function () {
    /*-----------------------------安全管理----------------------------*/
    var options = clone(DataTablesObj.options);
    options.paging = false;
    options.ordering = false;
    //暖通空调
    options.columns = [
           { "data": "Name0", title: "名称" },
           { "data": "Name1", title: "冷机" },
           { "data": "Name2", title: "新风机组" },
            { "data": "Name3", title: "组合空调" },
           { "data": "Name4", title: "吊装空调" }

    ];
    options.sAjaxSource = "/OverView/AirList"; //数据源地址
    DataTablesObj.init(options, "table_airCondition");
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
    DataTablesObj.init(options, "table_transformer");
    //医用冷链
    options.columns = [
       { "data": "Test", title: "名称" },
       { "data": "Test1", title: "一号楼" },
       { "data": "Test2", title: "二号楼" },
        { "data": "Test3", title: "三号楼" },
       { "data": "Test4", title: "四号楼" }
    ];
    options.sAjaxSource = "/OverView/ColdChains"; //数据源地址
    DataTablesObj.init(options, "table_coldChains");
    /*--------------------------运维管理--------------------------------*/
    //InitChart("/OverView/GetRepairTotalOptions", "repairTotal"); //维修统计
    //InitChart("/OverView/GetVisitTotalOptions", "visitTotal"); //巡检统计
    //InitChart("/OverView/GetMaintainTotalOptions", "maintainTotal"); //保养统计
    InitEChartList("/OverView/GetTotalOptions", new Array("repairTotal", "visitTotal", "maintainTotal")); //合并请求加载（维修统计，巡检统计，保养统计）
    /*能耗统计*/
    InitChart("/OverView/GetMonthECTotalOptions", "monthEC"); //本月总能耗
    InitChart("/OverView/GetYearECTotalOptions", "yearEC"); //本年总能耗
    //多个图表响应式支持
    ResizeECharts(new Array("repairTotal", "visitTotal", "maintainTotal", "monthEC", "yearEC"));
})