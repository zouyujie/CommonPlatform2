define(function () {
    //控件ID，上传完成后的回调函数
    var init = function (ctrlName, ctrfileName) {
        var control = $('#' + ctrlName);
        //导入文件上传完成之后的事件
        control.on("fileuploaded", function (event, data, previewId, index) {
            var res = data.response;
            if (res != undefined) {
                if (ctrfileName != undefined && ctrfileName != null) {
                    $("#" + ctrfileName).val(res.name);
                }
            }
            if (obj == undefined) {
                toastr.error('文件格式类型不正确');
                return;
            }
        });
        //文件删除之后的事件
        control.on("filesuccessremove", function (event, id) {
            $("#" + ctrfileName).val("");
        });
        ////文件预删除事件
        //control.on('filepredelete', function (event, key) {
        //    console.log('Key = ' + key);
        //    console.log($("#" + ctrfileName).val());
        //    $("#" + ctrfileName).val("");
        //});
        ////文件选择后触发事件
        //control.on("filebatchselected", function (event, files) {
            //$(this).fileinput("upload");
            //if (files.length > 0) {
            //    var fileNames = "";
            //    files.forEach(function (value, index, array) {
            //        fileNames += (value.name + ",")
            //    });
            //    fileNames = fileNames.trimEnd(',');
            //    console.log('选择了文件' + fileNames);
            //}
        //});
        ////监听移除按钮的事件
        //$(".fileinput-remove-button").on("click", function () {
        //    $("#" + ctrfileName).val("");
        //})
    }
    var options = {
        language: 'zh', //设置语言
        uploadUrl: '', //上传的地址
        allowedFileExtensions: ['jpg', 'gif', 'png'],//接收的文件后缀
        showUpload: true, //是否显示上传按钮
        showCaption: false,//是否显示标题
        showPreview: true,//是否显示文件的预览图 默认值true
        showRemove: true,//是否显示删除/清空按钮。默认值true。
        showUpload:true,//是否显示文件上传按钮。默认是submit按钮，除非指定了uploadUrl属性。默认值true。
        showCancel: true,//是否显示取消文件上传按钮。只有在AJAX上传线程中该属性才可见可用。默认值true。
        browseClass: "btn btn-primary", //按钮样式    
        maxFileCount: 1, //表示允许同时上传的最大文件个数
        enctype: 'multipart/form-data',
        validateInitialCount: true,
        previewFileIcon: "<i class='glyphicon glyphicon-king'></i>",// 按钮样式 
        msgFilesTooMany: "选择上传的文件数量({n}) 超过允许的最大数值{m}！",
        //initialDelimiter: '',//在initialPreview属性中用于上传多个文件时的分隔符。默认值：'*$$*'。
        //captionClass:'',//在标题容器上额外的class。类型string。 
        //previewClass:'',//在预览区域容器上的额外的class。类型string。
        //mainClass:'',//添加在文件上传主容器。类型string。 
        //dropZoneEnabled: false,//是否显示拖拽区域
        //minImageWidth: 50, //图片的最小宽度
        //minImageHeight: 50,//图片的最小高度
        //maxImageWidth: 1000,//图片的最大宽度
        //maxImageHeight: 1000,//图片的最大高度
        //maxFileSize: 0,//单位为kb，如果为0表示不限制文件大小
        //minFileCount: 0,
        //initialPreviewAsData: true,
        //overwriteInitial: false,
        //initialPreview:类型string或array。显示的初始化预览内容。你可以传入一个简单的HTML标签用于显示图片、文本或文件。如果设置一个字符串，会在初始化预览图中显示一个文件。你可以在initialDelimiter属性中设置分隔符用于显示多个预览图。如果设置为数组，初始化预览图中会显示数组中所有的文件。
    };
    //初始化fileinput控件（第一次初始化），上传地址，
    var initFileInput =
        function (ctrlName, uploadUrl) {
            var control = $('#' + ctrlName);
            options.uploadUrl = uploadUrl;
            control.fileinput(options);
        };
    return {
        options: options,
        initFileInput: initFileInput,
        init: init
    };
})