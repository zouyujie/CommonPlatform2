$(function () {
    InitChart("/EquipMaintain/Total/GetWorkloadTotalOptions", "divWorkloadTotal"); //工作量统计
    /*DataTables*/
    var obj = DataTablesObj;
    var options = clone(DataTablesObj.options);
    options.paging = false;
    options.ordering = false;
    //工作量统计
    options.columns = [
      obj.autoIncrement,
      { "data": "TName", title: "班组名称" },
      { "data": "TName1", title: "总工量" },
      { "data": "TName2", title: "完工量" },
      { "data": "TName3", title: "未完工量" },
      { "data": "TName4", title: "维修耗时" },
      { "data": "TName5", title: "满意度" }
     ];
    options.sAjaxSource = "/EquipMaintain/Total/WorkloadTotalList"; //数据源地址
    DataTablesObj.init(options, "table_WorkloadTotal");
})