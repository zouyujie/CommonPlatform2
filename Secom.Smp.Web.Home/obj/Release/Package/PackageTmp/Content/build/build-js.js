// 创建者: 邹琼俊
// 创建时间: 2017/6/29 18:23:14
({
    // app顶级目录，非必选项。如果指定值，baseUrl则会以此为相对路径
    appDir: '../js',
	// 模块根目录。默认情况下所有模块资源都相对此目录。
    // 若该值未指定，模块则相对build文件所在目录。
    // 若appDir值已指定，模块根目录baseUrl则相对appDir。
    baseUrl: './',
    mainConfigFile: '../js/config.js',
	// 指定输出目录，若值未指定，则相对 build 文件所在目录
    dir: '../release-js',
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
   //不符合AMD规范的js定义以及依赖关系配置
    shim: {
        'bootstrap': ['jquery'],
        "confirmation": ["bootstrap"],
        "bootstrapValidator": ['jquery'],
        "datatables.bootstrap": ["datatables.net"]
    },
	findNestedDependencies: true,
	// 国际化配置
    locale: "zh-cn",
	 // 不优化某些文件
    fileExclusionRegExp:/^(r|*.min)\.js$/,
	//optimize: "uglify",
    //uglify: { mangle: false},//false 不混淆变量名
    //First set up the common build layer.
    modules: [
	{
	    //module names are relative to baseUrl
        name: "config",
        //List common dependencies here. Only need to list
        //top level dependencies, "include" will find
        //nested dependencies.
		include: ["jquery"]
        //include: ["jquery","bootstrap","datepicker","bootstrapValidator","jquery.cookie","moment","domReady"]
    },
     //Now set up a build layer for each page, but exclude
     //the common one. "exclude" will exclude
     //the nested, built dependencies from "common". Any
     //"exclude" that includes built modules should be
     //listed before the build layer that wants to exclude it.
     //"include" the appropriate "app/main*" module since by default
     //it will not get added to the build since it is loaded by a nested
     //requirejs in the page*.js files.
    {
       name: 'views/areas/admin/default/index',
	   exclude: ['config']
    },
    {
       name: 'views/areas/History/Log/index',
	   exclude: ['config']
    },
    {
       name: 'views/home/index',
	   exclude: ['config']
    },
    {
       name: 'views/home/login',
	   exclude: ['config']
    },
    ],
    onBuildRead: function (moduleName, path, contents) {
        if (moduleName = "config") {
            return contents.replace("/content/js","/content/release-js")
        }
        return contents;
    },
})

