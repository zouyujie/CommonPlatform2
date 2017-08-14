requirejs.config({
    baseUrl: '/content/js',
    paths: {
        "jquery": "jquery.min",
        "bootstrap": "lib/bootstrap",
        "moment": "lib/moment.min",
        "datepicker": "lib/datepicker/WdatePicker",
        "bootstrapValidator": "lib/bootstrapValidator.min",
        "bootstrapValidator-zh_CN": "lib/bootstrapValidator-zh_CN",
        "jquery.cookie":"lib/jquery.cookie",
        "jquery.blockui":"lib/jquery.blockui.min",
        "jquery.md5": "lib/jquery.md5",
        "datatables.net": "lib/datatables/js/jquery.dataTables",
        "DataTablesExt": "lib/datatables/js/DataTablesExt",
        "datatables.bootstrap": "lib/datatables/js/dataTables.bootstrap",
        "baseDatatable": "common/baseDatatable",
        "WdatePicker": "lib/datepicker/WdatePicker",
        "toastr": "lib/bootstrap-toastr/toastr",
        "confirmation": "lib/bootstrap-confirmation/bootstrap-confirmation",
        "domReady": "lib/domReady"
    },
    urlArgs: "bust=" +  (new Date()).getTime(),
   //不符合AMD规范的js定义以及依赖关系配置
    shim: {
        'bootstrap': ['jquery'],
        ////"datepicker": ['jquery'],//$.fn.bootstrapValidator
        "confirmation": ["bootstrap"],
        "bootstrapValidator": ['jquery'],
        ////"datatables.net":["jquery"],
        ////"datatables": { deps: ["jquery"], exports: "datatables" },
        "datatables.bootstrap": ["datatables.net"],
        //"toastr": ['jquery'],
        //"jquery.md5": ['jquery']
    },
  
    waitSeconds: 300
});

