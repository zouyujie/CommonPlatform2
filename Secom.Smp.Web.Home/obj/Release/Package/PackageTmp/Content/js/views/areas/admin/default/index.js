define(["baseDatatable", "common/fileinput", "common/form-validator", "common/datetimepicker"], function (bdt, fileinput, form, dpk) {
    dpk.init('CreateTime');
    //初始化编辑界面的上传控件
    var initCtrl = function (data) {
        if (data.HeadsUrl!=null&&data.HeadsUrl != "") {
            var url = "<img src='/Upload/" + data.HeadsUrl + "' class='file-preview-image'/>";
            fileinput.options.theme = 'explorer';
            fileinput.options.initialPreview = [url];
            fileinput.options.initialPreviewConfig = [{
                caption: data.HeadsUrl,// 展示的图片名称  
                url: "/Admin/Default/DeleteFile",// 预展示图片的删除调取路径  
                key: data.HeadsUrl //删除路径默认传参
                //width: "120px",
                //,extra: {id: 100} //调用删除路径额外所传参数   
            }];
            //fileinput.options.initialPreviewAsData = true;
        }
        fileinput.initFileInput("HeadsUrl", "/Admin/Default/ExportFile");
    }
    //初始化编辑界面的数据
    var initModifyData = function (data,id) {
        if (data != undefined && data != null) {
            $("#txtId").val(id);
            $("#txtName").val(data.Name);
            $("#txtAddress").val(data.Address)
            $("#txtCreateTime").val(data.CreateTime);
            $("#txtMsg").val(data.Msg);
            $("#hidHeadsUrl").val(data.HeadsUrl);
            initCtrl(data);
        }
    }
    //修改记录
    window.doModify = function (id) {
        $("#updateModal").modal();
        $.post("/Admin/Default/Read", { id: id }, function (data) {
            initModifyData(data, id);//根据id获取实体对象
        });
    };
    //-------------初始化datatable
    bdt.options.columns = [{ title: "", "visible": false, "data": "ID" },
                    {
                        "data": "ID", title: "<input type='checkbox' id='chkAllColl' onclick='selectAll()'/>", orderable: false,
                        "render": function (data, type, row, meta) {
                            return "<input id='cbx" + data + "' name='chkItem' type='checkbox' onclick='controlSelectAll(" + data + ")' class='cbx' value='" + data + "'/>  ";
                        }
                    },
           { "data": "Name", title: "用户名称" },
           { "data": "Address", title: "用户地址" },
           { "data": "CreateTime", title: "创建时间" },
           {
               "data": "ID", orderable: false, title: "操作", "render": function (data, type, row, meta) { //自定义列
                   var re = "<div style='text-align:center'></i><button class='btn btn-xs green dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false' onclick='doModify(" + data + ")'>修改</button>"; //<li class='fa fa-edit'>
                   re = re + "<button class='btn btn-xs red dropdown-toggle' type='button' data-toggle='dropdown' aria-expanded='false' onclick='doDelete(" + data + ",'/Admin/Default/Delete','table_local')'>删除</button></div>";
                   return re;
               }
           }
    ];
    bdt.options.sAjaxSource = "/Admin/Default/List";
    bdt.init("table_local", "btnDeleteList", "/Admin/Default/DeleteList"); //表格容器id，删除按钮id，删除操作url地址
    //--------------表单验证
    var options = {
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
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
    };
    var addSuccessFunc = function () {
        document.getElementById('btnClose').click(); //关闭模态窗体
        document.getElementById("defaultForm").reset(); //清空表单
        reloadList("table_local"); //刷新datatable
    }
    var modifySuccessFunc = function () {
        document.getElementById('btnModifyClose').click(); //关闭模态窗体
        document.getElementById("modifyFrom").reset(); //清空表单
        reloadList("table_local");
    }
    form.init("defaultForm", options, addSuccessFunc);  //验证表单ID，配置验证对象，验证成功回调函数
    form.init("modifyFrom", options, modifySuccessFunc);
    form.retValidatorInit("defaultForm", "defaultModal",options);
    form.retValidatorInit("modifyFrom", "updateModal", options);
    //--------------添加界面中的上传控件
    //初始化fileinput控件（第一次初始化）
    fileinput.initFileInput("txt_file", "/Admin/Default/ExportFile"); 
    fileinput.init("txt_file", "hidFileUrl"); //控件ID，上传完成后的回调函数，删除后回调函数
    //编辑界面中的上传控件
    fileinput.init("HeadsUrl", "hidHeadsUrl");
})
