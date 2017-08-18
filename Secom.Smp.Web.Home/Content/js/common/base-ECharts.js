// ajax加载调试用
//# sourceURL=base-ECharts.js

//配置项地址，报表容器ID
function InitChart(optionsUrl, chartsId) {
    // 基于准备好的dom，初始化echarts图表
    var charts = document.getElementById(chartsId);
    var myChart = echarts.init(charts);
    myChart.showLoading();
    var option = null;
    $.ajax({
        url: optionsUrl,
        type: "POST",
        success: function (data) {
            option = eval('(' + data + ')');
            myChart.hideLoading();
            // 为echarts对象加载数据
            myChart.setOption(option);
        },
        error: function (msg) {
            toastr.error("系统发生错误:"+msg);
        }
    });
    //单个ECharts图表响应式
    window.onresize = function () {
        myChart.resize();
    }
}
//多个图表响应式支持——Echarts Id集合
function ResizeECharts(ids) {
    if (ids != undefined && ids != null) {
        var length = ids.length;
        if (length > 0) {
            window.onresize = function () {
                for (var x=0;x<length;x++) {
                    var chart = document.getElementById(ids[x]);
                    console.log(ids[x]);
                    var myChart = echarts.init(chart);
                    myChart.resize();
                }
            }
        }
    }
}
//批量ECharts初始化——(地址,ChartIds)集合
function InitEChartList(optionsUrl, ids) {
    if (ids != undefined && ids != null) {
        var length = ids.length;
        if (length > 0) {
            var arrayStr = new Array();
            for (var x=0;x<length;x++) {
                // 基于准备好的dom，初始化echarts图表
                var charts = document.getElementById(ids[x]);
                var myChart = echarts.init(charts);
                myChart.showLoading();
                arrayStr.push(myChart);
            }
            $.post(optionsUrl, {}, function (data) {
                var result = eval('(' + data + ')'); 
                var index = 0;
                for (x in result) {
                    var myChart = arrayStr[index];
                    myChart.setOption(result[x]);
                    myChart.hideLoading();
                    index++;
                }
            })
        }
    }
}