// ������: ����
// ����ʱ��: 2017/6/29 18:23:14
({
    // app����Ŀ¼���Ǳ�ѡ����ָ��ֵ��baseUrl����Դ�Ϊ���·��
    appDir: '../js',
	// ģ���Ŀ¼��Ĭ�����������ģ����Դ����Դ�Ŀ¼��
    // ����ֵδָ����ģ�������build�ļ�����Ŀ¼��
    // ��appDirֵ��ָ����ģ���Ŀ¼baseUrl�����appDir��
    baseUrl: './',
    mainConfigFile: '../js/config.js',
	// ָ�����Ŀ¼����ֵδָ��������� build �ļ�����Ŀ¼
    dir: '../release-js',
	    paths: {
        "jquery": "jquery.min",
        //"jqueryValidate": "lib/jquery.validate.min",
        //"jqueryValidateUnobtrusive": "lib/jquery.validate.unobtrusive.min",
        "bootstrap": "lib/bootstrap",
        "moment": "lib/moment.min",
        "datepicker": "lib/datepicker/WdatePicker",
        "bootstrapValidator":"lib/bootstrapValidator",
        "bootstrapValidator-zh_CN":"lib/bootstrapValidator-zh_CN",
        "jquery.cookie":"lib/jquery.cookie",
        "jquery.blockui":"lib/jquery.blockui.min",
        "jquery.md5":"lib/jquery.md5",
        "domReady": "lib/domReady"
    },
	   //������AMD�淶��js�����Լ�������ϵ����
    shim: {
        'bootstrap': {
            deps: ['jquery'],
            exports: "bootstrap"
        },
        //"jqueryValidate": ["jquery"],
        //"jqueryValidateUnobtrusive": ["jquery", "jqueryValidate"],
        "datepicker": {
            deps: ['jquery'],
            exports: "datepicker"
        },
        "bootstrapValidator": {
            deps: ['jquery'],
            exports: "bootstrapValidator"
        }
    },
	findNestedDependencies: true,
	// ���ʻ�����
    locale: "zh-cn",
	 // ���Ż�ĳЩ�ļ�
    //fileExclusionRegExp: /^\.min/,
	//optimize: "uglify",
    //uglify: { mangle: false},//false ������������
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
	   exclude: ['config','datepicker']
    },
    {
       name: 'views/areas/History/Log/index',
	   exclude: ['config','datepicker']
    },
    {
       name: 'views/home/index',
	   exclude: ['config','datepicker']
    },
    {
       name: 'views/home/login',
	   exclude: ['config','datepicker']
    },
    ],
    onBuildRead: function (moduleName, path, contents) {
        if (moduleName = "config") {
            return contents.replace("/content/js","/content/release-js")
        }
        return contents;
    },
})