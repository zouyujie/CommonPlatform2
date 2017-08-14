define( function () {
    var lengthMenuStr = '每页显示：<select class="form-control input-xsmall">' + '<option value="5">5</option>' + '<option value="10">10</option>' + '<option value="20">20</option>' + '<option value="30">30</option>'
                    + '<option value="50">50</option>' + '<option value="100">100</option>' + '<option value="150">150</option>' + '<option value="200">200</option>' + '<option value="250">250</option>' + '<option value="500">500</option>';
    var infoStr = "总共 <span class='pagesStyle'>(_PAGES_) </span>页，显示 _START_ -- _END_ ，共<span class='recordsStyle'> (_TOTAL_)</span> 条";
    var table_local = "table_local";
    //删除选中记录（批量删除）
    var doDeleteList = function (ctrlId, url) {
        var table = $('#' + ctrlId).dataTable();
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
                reloadList(ctrlId);
            }
        });
    }
    //删除单条记录
    window.doDelete = function (id,url,tbId) {
        $.post(url, { id: id }, function (result) {
            toastr.success(result.message);
            tbId = (tbId ==undefined||tbId == null) ? table_local : tbId;
            reloadList(tbId);
        });
    };
    var options = {
        bProcessing: true,
        "scrollY": table_h1,// 340,// 
        "scrollX": false,
        "scrollCollapse": "true",
        //dom:"",//'ftr<"bottom"lip>',//<"clear">
        "bServerSide": false, //指定从服务器端获取数据
        sServerMethod: "POST",
        sAjaxSource: "",
        autoWidth: false,
        fnServerParams: null,
        columns: null,
        paging: true,//分页
        ordering: true,//是否启用排序
        searching: true,//搜索
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
    var init = function (tbId, ctrlId, url) {
        $('#' + tbId).dataTable(options);
        //监听批量删除按钮事件
        $('#' + ctrlId).on('confirmed.bs.confirmation', function () {
            bdt.doDeleteList(tbId, url);
        }).on("click", function () {
            ('#' + ctrlId).confirmation('show');
        });
    };
    return {
        options: options,
        doDeleteList: doDeleteList,
        init: init
    };
});