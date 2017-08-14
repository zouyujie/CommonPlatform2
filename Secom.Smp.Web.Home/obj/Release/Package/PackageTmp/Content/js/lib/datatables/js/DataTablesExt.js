//*********************************2017-07-06-Zouqj*****************************************
//---------------------------DataTables UI控件的扩展js，请确保引用了此js的页面元素命名一致，引入此js之前请先引用jquery-------------------------------------------

var table_h = 0; //表格的高度
var table_h1 = 0;
$(function () {
    table_h = $("#divSearch") ? $(document).height() - $("#divSearch").height() - 318 : $(document).height() -318;
    table_h1 = $(document).height()/2-60;
});
var tbShowRows = 50; //表格默认显示行数
document.onkeydown = function (event) {
    var e = event || window.event || arguments.callee.caller.arguments[0];
    if (e && e.keyCode == 27) { // 按 Esc 
        //要做的事情
    }
    if (e && e.keyCode == 13) { // enter 键
        //要做的事情
        reloadList("table_local");
    }
};
////对行单击添加监听事件
//$('#table_local tbody').on('click', 'tr', function () {
//    var tr = $(this).closest('tr');
//    var checkbox = tr.find('td:first-child input:checkbox')[0];
//    checkbox.checked = !checkbox.checked;
//});
//获Ggridview中所有的复选框 sName: Gridview 的ID  
function getCheckbox(sName) {
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
}

//监听每一行的复选框,控制全选、反选按钮  
function controlSelectAll(i) {
    var tblName, cbkAll; //Gridview ID ，全选框ID  
    var tblName = "table_local";
    var cbkAll = "chkAllColl";
    var id = "#cbx" + i;
    //点击复选框选中行
    //if ($(id)[0].checked == true) {
    //    $(id).parent().parent().addClass('selected');
    //    $(id).parent().parent().siblings().removeClass('selected');
    //} else {
    //    $(id).parent().parent().siblings().removeClass('selected');
    //    $(id).parent().parent().removeClass('selected');
    //}
    var chks = getCheckbox(tblName);
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
}
//全选反选
function selectAll() {
    var isChecked = $("#chkAllColl")[0].checked;
    $("input[name='chkItem']").prop("checked", isChecked);
}
//查询 刷新
function reloadList(id) {
    var tables = $('#' + id).dataTable().api();//获取DataTables的Api，详见 http://www.datatables.net/reference/api/
    tables.ajax.reload();
}
