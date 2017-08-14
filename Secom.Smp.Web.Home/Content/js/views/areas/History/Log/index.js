$(function () {
    //--------------------------初始化datatable----------------------------------
    var obj = DataTablesObj;
    obj.readUrl = "/History/Log/Read";
    obj.updateUrl = "/History/Log/Update";
    obj.deleteUrl = "/History/Log/Delete";
    //obj.showReadBtn = true;//显示详情按钮
    obj.showDeleteBtn = true;//显示删除按钮
    obj.showUpdateBtn = true;//显示更新按钮

    var options = clone(DataTablesObj.options);

    options.sAjaxSource = "/History/Log/List";
    options.columns = [{ title: "", "visible": false, "data": "ID", orderable: false },
                           obj.autoIncrement, //序号
                           obj.checboxFied, //文本框
                           { "data": "Name", title: "日志名称" },
                           { "data": "Msg", title: "日志备注" },
                           { "data": "CreateTime", title: "创建时间" },
                           obj.opratorFiled
    ];
    options.bServerSide = true;
    options.fnServerParams = function (aoData) {  //查询条件
        aoData.push(
             { "name": "LogName", "value": $("#LogName").val() }
            );
    };
    obj.detailModal = "detailModal";//指定详情页面的Modal ID
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
    }
    //自动搜索用户名
    $('#LogName').typeahead({
        ajax: {
            url: '/History/Log/GetLogNameByField',
            data: { 'query': $("#LogName").val() },
            timeout: 300,                   // 延时
            method: 'post',
            triggerLength: 1,               // 输入几个字符之后，开始请求
            loadingClass: null,             // 加载数据时, 元素使用的样式类
            preDispatch: null,　　　　　　　　// 发出请求之前，调用的预处理方法
            preProcess: null　　　　　　　　　// Ajax 请求完成之后，调用的后处理方法
        },
        display: "Name",     // 默认的对象属性名称为 name 属性
        val: "Id",           // 默认的标识属性名称为 id 属性
        items: 8,            // 最多显示项目数量
        itemSelected: function (item, val, text) {      // 当选中一个项目的时候，回调函数
            console.info(item.Id+","+item.Name);
        }
    });
})
