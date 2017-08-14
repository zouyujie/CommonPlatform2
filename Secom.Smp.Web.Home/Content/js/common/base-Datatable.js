// ajax加载调试用
//# sourceURL=base-Datatable.js

//DataTables表格组件扩展对象--created by zouqj 2017-7-03
var DataTablesObj = (function () {
    //------------------------------静态全局属性-------------------------------------
    var infoStr = "总共 <span class='pagesStyle'>(_PAGES_) </span>页，显示 _START_ -- _END_ ，共<span class='recordsStyle'> (_TOTAL_)</span> 条";

    var lengthMenuStr = '每页显示：<select class="form-control input-xsmall">' + '<option value="5">5</option>' + '<option value="10">10</option>' + '<option value="20">20</option>' + '<option value="30">30</option>'
         + '<option value="50">50</option>' + '<option value="100">100</option>' + '<option value="150">150</option>' + '<option value="200">200</option>' + '<option value="250">250</option>' + '<option value="500">500</option>';

    this.table_local = "table_local"; //table ID
    this.chkAllColl = "chkAllColl"; //全选按钮ID
    this.modalId = "defaultModal"; //模态窗体ID
    this.batchDeleteBtn = "btnDeleteList"; //批量删除按钮ID
    this.deleteBtn = "btnDelete"; //删除按钮ID
    this.autoIncrement={'title': '序号', 'data': null, 'bSortable': false,'render': function (data, type, full, meta) {return meta.row + 1 + meta.settings._iDisplayStart;}}; // 序号
    //操作列
    this.opratorFiled = {
        "data": "ID", orderable: false, title: "操作", "render": function (data, type, row, meta) { //自定义列
            var re = "<div class='operatorDiv'></i>";
            if (DataTablesObj.showReadBtn) {
                var temp = DataTablesObj.detailModal == undefined ? data : data + ",'" + DataTablesObj.detailModal+"'";
                re += "<a class='' type='button' data-toggle='dropdown' aria-expanded='false' onclick=\"DataTablesObj.doReadModal(" + temp + ")\">详情</a>";
            }
            if (DataTablesObj.showUpdateBtn) {
                var temp = DataTablesObj.updateModal == undefined ? data : data + ",'" + DataTablesObj.updateModal + "'";
                re += "<a class='' type='button' onclick='DataTablesObj.doUpdateModal(" + temp + ")'>编辑</a>";
            }
            if (DataTablesObj.showDeleteBtn) {
                re += "<a class='' title='确定要删除吗?' data-toggle='confirmation' data-placement='left' data-btn-ok-label='继续' data-btn-ok-icon='icon-like' data-btn-ok-class='btn-success toastrBtn' data-btn-cancel-label='取消' data-btn-cancel-icon='icon-close' data-btn-cancel-class='btn-danger' type='button' onclick='DataTablesObj.doDelete(this," + data + ")'>删除</a>";
            }
            re += "</div>";
            return re;
        }
    };
    //复选框列
    this.checboxFied = {
        "data": "ID", title: "<input type='checkbox' id='chkAllColl' onclick='DataTablesObj.selectAll()'/>", orderable: false,
        "render": function (data, type, row, meta) {
            return "<input id='cbx" + data + "' name='chkItem' type='checkbox' onclick='DataTablesObj.controlSelectAll(" + data + ")' class='cbx' value='" + data + "'/>  ";
        }
    };
    //------------------------------变化部分的属性-------------------------------------
    this.batchDeleteUrl = "";//批量删除路径
    this.deleteUrl = ""; //单条记录删除路径
    this.showReadBtn = true;//默认不显示详情按钮
    this.showDeleteBtn = false;//默认不显示删除按钮
    this.showUpdateBtn = false;//默认显示更新按钮
    this.readUrl = ""; //单条记录读取路径
    this.updateUrl = "";//更新界面URL地址
    this.detailModal = undefined; //详情页面的modalId
    this.updateModal = undefined;//修改页面的modalId

    //------------------------------事件、方法-------------------------------------
    document.onkeydown = function (event) {
        var e = event || window.event || arguments.callee.caller.arguments[0];
        if (e && e.keyCode == 27) { // 按 Esc 
            //要做的事情
        }
        if (e && e.keyCode == 13) { // enter 键
            //要做的事情
            DataTablesObj.reloadList(DataTablesObj.table_local);
        }
    };
    ////对行单击添加监听事件
    //$('#table_local tbody').on('click', 'tr', function () {
    //    var tr = $(this).closest('tr');
    //    var checkbox = tr.find('td:first-child input:checkbox')[0];
    //    checkbox.checked = !checkbox.checked;
    //});
    //获Ggridview中所有的复选框 sName: Gridview 的ID  
    this.getCheckbox = function (sName) {
        var aryCheckbox = new Array();
        var tb = document.getElementById(sName);
        if (tb == null)
            return;
        var objs = tb.getElementsByClassName("cbx");
        for (var i = 0; i < objs.length; i++) {
            if (objs[i].type == 'checkbox')
                aryCheckbox.push(objs[i]);
        }
        return aryCheckbox;
    };

    //监听每一行的复选框,控制全选、反选按钮  
    this.controlSelectAll = function (i) {
        var tblName, cbkAll; //Gridview ID ，全选框ID  
        var tblName = DataTablesObj.table_local;
        var cbkAll = DataTablesObj.chkAllColl;
        var id = "#cbx" + i;
        //点击复选框选中行
        //if ($(id)[0].checked == true) {
        //    $(id).parent().parent().addClass('selected');
        //    $(id).parent().parent().siblings().removeClass('selected');
        //} else {
        //    $(id).parent().parent().siblings().removeClass('selected');
        //    $(id).parent().parent().removeClass('selected');
        //}
        var chks = DataTablesObj.getCheckbox(tblName);
        var count = 0;
        for (var i = 0; i < chks.length; i++) {
            if (chks[i].checked == true) {
                count++;
            }
        }
        if (count < chks.length) {
            document.getElementById(cbkAll).checked = false;
        }
        else {
            document.getElementById(cbkAll).checked = true;
        }
    };
    //全选反选
    this.selectAll = function () {
        var isChecked = $("#" + DataTablesObj.chkAllColl)[0].checked;
        $("input[name='chkItem']").prop("checked", isChecked);
    };
    //查询刷新
    this.reloadList = function (id) {
        var tableId = id == undefined ? DataTablesObj.table_local : id;
        var tables = $('#' + tableId).dataTable().api();//获取DataTables的Api，详见 http://www.datatables.net/reference/api/
        tables.ajax.reload();
    };
    //****************************************************************************************************************

    //新增记录（异步请求界面url,[modal ID],[回调函数]）
    this.doCreateModal = function (url, modalId, func) {
        var modalId = modalId == undefined ? DataTablesObj.modalId : modalId;
        $('#' + modalId).modal({ show: true, backdrop: 'static', remote: url });
        if (func != undefined) {
            func();
        }
    };
    //详细记录（主键ID，[modal ID],[异步请求界面url]）
    this.doReadModal = function (id, modalId) {
        var modalId = modalId == undefined ? DataTablesObj.modalId : modalId;
        $('#' + DataTablesObj.modalId).modal({ show: true, backdrop: 'static', remote: DataTablesObj.readUrl + "?id=" + id });
    }
    //编辑记录（主键ID，异步请求界面url,[modal ID]）
    this.doUpdateModal = function (id,updateUrl, modalId) {
        var modalId = modalId == undefined ? DataTablesObj.modalId : modalId;
        $('#' + modalId).modal({ show: true, backdrop: 'static', remote: DataTablesObj.updateUrl + "?id=" + id });
    };
    //删除选中记录（批量删除）
    this.doDeleteList = function (url) {
        var table = $('#' + DataTablesObj.table_local).dataTable();
        var nTrs = table.fnGetNodes();//fnGetNodes获取表格所有行，nTrs[i]表示第i行tr对象
        var row;
        var strdid = '';
        var selectCounts = 0;
        for (var i = 0; i < nTrs.length; i++) {
            if ($(nTrs[i])[0].cells[0].children[0].checked) {
                row = table.fnGetData(nTrs[i]);//fnGetData获取一行的数据        
                selectCounts++;
                strdid += "" + row.ID + ",";
            }
        }
        strdid = strdid.substring(0, strdid.length - 1);
        var ids = strdid.split(",");
        if (selectCounts < 1) {
            toastr.warning("请先选择数据行!");
            return false;
        }
        $.ajax({
            type: 'POST',
            url: url,
            data: { 'ids': ids },
            dataType: 'json',
            success: function (result) {
                toastr.success(result.message);
                DataTablesObj.reloadList(DataTablesObj.table_local);
            }
        });
    }
    //删除单条记录
    this.doDelete = function (btn, id) {
        $(btn).on('confirmed.bs.confirmation', function () {
            $.post(DataTablesObj.deleteUrl, { Id: id }, function (result) {
                toastr.success(result.message);
                DataTablesObj.reloadList(DataTablesObj.table_local);
            });
        });
        $(btn).confirmation('show');
    };
    this.options = {
        bProcessing: true,
        //"scrollY": table_h1,// 340,// 
        "scrollX": false,
        //"scrollCollapse": "true",
        //dom:"",//'ftr<"bottom"lip>',//<"clear">
        "bServerSide": false, //指定从服务器端获取数据
        sServerMethod: "POST",
        sAjaxSource: "",
        autoWidth: false,
        fnServerParams: null,
        columns: null,
        paging: true,//分页
        ordering: true,//是否启用排序
        searching: false,//搜索
        language: {
            "sProcessing": "处理中...",
            lengthMenu: lengthMenuStr,//左上角的分页大小显示。
            search: '<span class="label label-success">搜索：</span>',//右上角的搜索文本，可以写html标签

            //paginate: {//分页的样式内容。
            //    previous: "上一页",
            //    next: "下一页",
            //    first: "",
            //    last: ""
            //},
            "paginate": {
                "previous": "Prev",
                "next": "Next",
                "last": "Last",
                "first": "First"
            },

            zeroRecords: "",//table tbody内容为空时，tbody的内容。--暂无记录
            //下面三者构成了总体的左下角的内容。
            info: infoStr,//左下角的信息显示，大写的词为关键字。初始_MAX_ 条
            infoEmpty: "0条记录",//筛选为空时左下角的显示。
            infoFiltered: ""//筛选之后的左下角筛选提示，
        },
        pagingType: "bootstrap_full_number"//分页样式的类型 "full_numbers"//
    };
    //监听批量删除按钮事件
    this.listenerDeleteEvent = function (ctrlId, url) {
        $('#' + ctrlId).on('confirmed.bs.confirmation', function () {
            DataTablesObj.doDeleteList(url);
        }).on("click", function () {
            $('#' + ctrlId).confirmation('show');
        });
    }
    //控件初始化（[table容器ID]）
    this.init = function (options, tableId,obj) {
        var tableId = tableId == undefined ? DataTablesObj.table_local : tableId;
        var opts = options == undefined ? DataTablesObj.options : options;
        $('#' + tableId).dataTable(opts);
        if (obj == undefined) {
            DataTablesObj.listenerDeleteEvent(DataTablesObj.batchDeleteBtn, DataTablesObj.batchDeleteUrl);
        } else {
            obj.listenerDeleteEvent(obj.batchDeleteBtn, obj.batchDeleteUrl);
        }      
        delete options.aoColumns;
    };
    return this;
}).call({});
