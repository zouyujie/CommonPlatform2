$(function () {
    //-------------初始化datatable
    var obj = DataTablesObj;
    obj.showReadBtn = true;//显示详情按钮
    obj.showUpdateBtn = false;//显示更新按钮
    obj.showDeleteBtn = false; //显示删除按钮

    var options = obj.options;

    options.columns = [{ title: "", "visible": false, "data": "ID" },
           obj.checboxFied,
           { "data": "TName", title: "工单号" },
           { "data": "TName0", title: "工单名称" },
           { "data": "TName1", title: "设备类型" },
           { "data": "TName2", title: "所属单位" },
           { "data": "TName3", title: "设备数量" },
           { "data": "TName4", title: "截止日期" },
           { "data": "TName5", title: "运维班组" },
           { "data": "TName6", title: "保养进度", orderable: false },
           { "data": "TName7", title: "完成时间", orderable: false },
           { "data": "TName8", title: "执行人", orderable: false },
           { "data": "TName9", title: "保养状态", orderable: false },
           {
               "data": "ID", orderable: false, title: "操作", "render": function (data, type, row, meta) { //自定义列
                   var re = "<div class='operatorDiv'></i>";
                   re += "<a class='ajaxify nav-link ' type='button' data-toggle='dropdown' aria-expanded='false' href=\"/EquipMaintain/CompositeSearching/Read?Id=" + data + "&&MenuId=" + $("#hidfMenuId").val() + "\">详情</a>";
                   re += "</div>";
                   return re;
               }
           }
    ];
    options.sAjaxSource = "/EquipMaintain/CompositeSearching/List"; //数据源地址
    options.bServerSide = true;
    //DataTablesObj.options.fnServerParams = function (aoData) {  //查询条件
        //aoData.push(
        //     { "name": "LogName", "value": $("#LogName").val() }
        //    );
    //};
    DataTablesObj.init(options);
    DatetimepickerObj.initStartEnd('TName1', 'TName2');
    //表单验证配置项
    FormValidatorObj.options.fields = {
        Name: {
            message: '用户名验证失败',
            validators: {
                notEmpty: {
                    message: '用户名不能为空'
                }
            }
        },
        Address: {
            validators: {
                notEmpty: {
                    message: '地址不能为空'
                }
            }
        }
    };
    function lookDetail(id) {

    }
})