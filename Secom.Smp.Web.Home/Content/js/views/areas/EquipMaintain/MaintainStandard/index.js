$(function () {
    //-------------初始化datatable
    var obj = DataTablesObj;
    obj.showReadBtn = true;//显示详情按钮
    obj.showUpdateBtn = true;//显示更新按钮
    obj.showDeleteBtn = false; //显示删除按钮
    obj.readUrl = "/EquipMaintain/MaintainStandard/Read";
    obj.updateUrl = "/EquipMaintain/MaintainStandard/Update";

    var options = obj.options;

    options.columns = [{ title: "", "visible": false, "data": "ID" },
           obj.autoIncrement,
           { "data": "TName", title: "保养参数" },
           { "data": "TName1", title: "设备类型" },
           { "data": "TName2", title: "输入类型" },
           { "data": "TName3", title: "保养周期" },
           { "data": "TName4", title: "标准值" },
           { "data": "TName5", title: "单位" },
           { "data": "TName6", title: "是否拍照",orderable: false },
           obj.opratorFiled
    ];
    options.sAjaxSource = "/EquipMaintain/MaintainStandard/List"; //数据源地址
    options.bServerSide = true;
    //DataTablesObj.options.fnServerParams = function (aoData) {  //查询条件
        //aoData.push(
        //     { "name": "LogName", "value": $("#LogName").val() }
        //    );
    //};
    DataTablesObj.init(options);
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
})