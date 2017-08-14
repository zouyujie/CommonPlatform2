//ajax加载调试用
//# sourceURL=base-Datetimepicker.js

//Datetimepicker日期组件扩展对象--created by zouqj 2017-7-13
var DatetimepickerObj = (function () {
    this.options = {
        language: 'zh-CN',//显示中文
        format: 'yyyy-mm-dd',//显示格式
        minView: "month",//设置只显示到月份
        initialDate: new Date(),//初始化当前日期
        autoclose: true,//选中自动关闭
        todayBtn: true//显示今日按钮
    };
    this.init= function (ctrlId) {
        $("#" + ctrlId).datetimepicker(DatetimepickerObj.options);
    }
    //(开始日期控件，结束日期控件)
    this.initStartEnd = function (startCtrl, endCtrl) {
        var startCtrl = $("#" + startCtrl);
        var endCtrl = $("#" + endCtrl);
        startCtrl.datetimepicker({
            format: 'yyyy-mm-dd',
            minView: 'month',
            language: 'zh-CN',
            autoclose: true,
            startDate: new Date()
        }).on("click", function () {
            startCtrl.datetimepicker("setEndDate", endCtrl.val())
        });
        endCtrl.datetimepicker({
            format: 'yyyy-mm-dd',
            minView: 'month',
            language: 'zh-CN',
            autoclose: true,
            startDate: new Date()
        }).on("click", function () {
            endCtrl.datetimepicker("setStartDate", startCtrl.val())
        });
    }
    return this;
}).call({});
   
