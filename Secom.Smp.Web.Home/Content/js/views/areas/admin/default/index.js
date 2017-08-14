$(function () {
    //-------------初始化datatable
    var obj = DataTablesObj;
    obj.showReadBtn = false;//显示详情按钮
    obj.showDeleteBtn = true;//显示删除按钮
    obj.showUpdateBtn = true;//显示更新按钮

    obj.updateUrl = "/Admin/Default/Update";
    obj.deleteUrl = "/Admin/Default/Delete";
    obj.batchDeleteUrl = "/Admin/Default/DeleteList";//批量删除路径

    obj.options.columns = [{ title: "", "visible": false, "data": "ID" },
           obj.checboxFied,
           { "data": "Name", title: "用户名称" },
           { "data": "Address", title: "用户地址" },
           { "data": "CreateTime", title: "创建时间" },
           obj.opratorFiled
    ];
    obj.options.searching = true;
    obj.options.sAjaxSource = "/Admin/Default/List"; //数据源地址
    obj.init(obj.options);
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
