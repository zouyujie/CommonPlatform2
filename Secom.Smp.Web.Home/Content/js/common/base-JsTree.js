// ajax加载调试用
//# sourceURL=base-JsTree.js

var JsTreeObj = (function () {
    //以指定的Json数据，初始化JStree控件
    //treeName为树div id，url为数据源地址，isCheck为是否显示复选框，loadedfunction为加载完毕的回调函数
    this.bindJsTree = function (treeName, url, isCheck, loadedfunction) {
        var control = $('#' + treeName)
        //control.data('jstree', false);//清空数据，必须
        //var isCheck = arguments[2] || false; //设置checkbox默认值为false
        if (isCheck) {
            //复选框树的初始化
            $.getJSON(url, null, function (data) {
                //JSON.parse
                control.jstree({
                    'plugins': ["checkbox"], //出现选择框
                    'checkbox': { cascade: "", three_state: true }, //级联
                    'core': {
                        'data': data,
                        "themes": {
                            "responsive": false
                        }
                    }
                }).bind('loaded.jstree', loadedfunction);
            });
        }
        else {
            //普通树列表的初始化
            $.getJSON(url, function (data) {
                control.jstree({
                    'core': {
                        'data': data,
                        "themes": {
                            "responsive": false
                        }
                    }
                }).bind('loaded.jstree', loadedfunction);
            });
        }
    };
    this.bindOn = function (treeId) {
        var control = $('#' + treeId);
        // listen for event  
        control.on('changed.jstree', function (e, data) {
            r = [];
            var i, j;
            for (i = 0, j = data.selected.length; i < j; i++) {
                var node = data.instance.get_node(data.selected[i]);
                if (data.instance.is_leaf(node)) {
                    r.push(node.id);
                }
            }
            $("#spnTest").html('选中: ' + r.join(','));
        });
    }
    return this;
}).call({});

