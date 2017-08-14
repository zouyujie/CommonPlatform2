define(function (ctrlId) {
    var init = function (ctrlId) {
        $("#" + ctrlId).datetimepicker({
            language: 'zh-CN',//显示中文
            format: 'yyyy-mm-dd',//显示格式
            minView: "month",//设置只显示到月份
            initialDate: new Date(),//初始化当前日期
            autoclose: true,//选中自动关闭
            todayBtn: true//显示今日按钮
        });
    }
    return {
        init: init
    }
});