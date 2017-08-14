require(["baseDatatable"], function (dt) {
    dt.options.sAjaxSource = "/History/Log/List";
    dt.options.columns = [{ title: "", "visible": false, "data": "ID", orderable: false },
                                    {
                                        "data": "ID", title: "<input type='checkbox' id='chkAllColl' onclick='selectAll()'/>", orderable: false, width: 60,
                                        "render": function (data, type, row, meta) {
                                            return "<input id='cbx" + data + "' type='checkbox' onclick='controlSelectAll(" + data + ")' class='cbx' value='" + data + "'/>  ";
                                        }
                                    },
                           { "data": "Name", title: "日志名称", width: "200" },
                           { "data": "Msg", title: "日志备注", width: "250" },
                           { "data": "CreateTime", title: "创建时间", width: "150" },
                           {
                               "data": "ID", orderable: false, title: "操作", width: "140", "render": function (data, type, row, meta) { //自定义列
                                   var re = "<div style='text-align:center'><button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false' onclick='modifyRecord(" + data + ")'>修改</button>";
                                   re = re + "<button class='btn btn-xs red dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false'>删除</button></div>";
                                   return re;
                               }
                           }
    ];
    dt.options.bServerSide = true;
    //dt.bFilter=false, 
    dt.options.fnServerParams = function (aoData) {  //查询条件
        aoData.push(
             { "name": "LogName", "value": $("#LogName").val() }
            );
    };
    dt.options.searching = false;
    dt.init('table_local');
})