define(["common/baseJsTree"], function (tree) {
    $("#btnSearch").on("click", function () {
        $("#spnTest").html("选中记录：" + r.join(','));
    });
    tree.bindJsTree("tree_2", "/Admin/KeepPlan/GetEquipmentTypes", true, function () { tree.bindOn("tree_2"); });
}
)
