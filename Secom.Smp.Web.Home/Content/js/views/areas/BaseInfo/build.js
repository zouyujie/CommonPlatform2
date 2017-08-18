$(function () {
    //-------------初始化datatable
    DataTablesObj.showReadBtn = false;//显示详情按钮
    DataTablesObj.showDeleteBtn = true;//显示删除按钮
    DataTablesObj.showUpdateBtn = true;//显示更新按钮

    DataTablesObj.updateUrl = "/Admin/Default/Update";
    DataTablesObj.deleteUrl = "/Admin/Default/Delete";
    DataTablesObj.batchDeleteUrl = "/Admin/Default/DeleteList";//批量删除路径

    DataTablesObj.options.columns = [{ title: "", "visible": false, "data": "ID" },
           DataTablesObj.checboxFied,
           { "data": "Name", title: "建筑编号" },
           { "data": "Address", title: "建筑名称" },
           { "data": "CreateTime", title: "所属单位" },
           { "data": "Name2", title: "建筑总面积" },
           { "data": "Address2", title: "空调面积" },
           { "data": "CreateTime2", title: "联系人" },
           { "data": "CreateTime3", title: "联系电话" },
           { "data": "CreateTime4", title: "状态" },
           DataTablesObj.opratorFiled
    ];
    DataTablesObj.options.sAjaxSource = "/Admin/Default/List"; //数据源地址
    DataTablesObj.init();
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
    //打印预览
    $("#printView").on("click", function () {
        $("#table_local").printThis({
            debug: false,// 调试模式下打印文本的渲染状态
            importCSS: true,
            importStyle: true,
            printContainer: true,
            //loadCSS: "/Content/bootstrap.css",
            pageTitle: "用户列表",
            removeInline: false,
            printDelay: 333,
            header: null,
            formValues: true,
            header: "<h1>用户列表</h1>",
            footer: null
        });
    })
})
