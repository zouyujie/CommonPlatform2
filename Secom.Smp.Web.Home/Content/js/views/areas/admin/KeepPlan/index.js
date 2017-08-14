$(function () {
    $("#btnSearch").on("click", function () {
        $("#spnTest").html("选中记录：" + r.join(','));
    });
    JsTreeObj.bindJsTree("tree_2", "/Admin/KeepPlan/GetEquipmentTypes", true, function () { JsTreeObj.bindOn("tree_2"); });
}
)
