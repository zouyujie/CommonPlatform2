using System.Web.Optimization;

namespace Secom.Smp.Web.Home
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region js
            //1.CORE PLUGINS
            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                      "~/Content/js/jquery.min.js",
                      "~/Content/js/lib/bootstrap.js"
                      ));
            //2.layouts
            bundles.Add(new ScriptBundle("~/bundles/layouts").Include(
                   "~/Content/js/lib/jquery.blockui.min.js", //界面遮罩
                   "~/Content/js/app.js",
                   "~/Content/js/layouts/layout.js", //界面布局
                   "~/Content/js/layouts/quick-sidebar.js", //侧边导航插件
                   "~/Content/js/layouts/quick-nav.js" //快速导航
                   ));
            //3.index
            bundles.Add(new ScriptBundle("~/bundles/index").Include(
          "~/Content/js/lib/datatables/js/jquery.dataTables.js",
          "~/Content/js/lib/datatables/js/dataTables.bootstrap.js",
           "~/Content/js/common/base-Datatable.js",
          "~/Content/js/lib/bootstrap-toastr/toastr.js", //提示框
          "~/Content/js/lib/bootstrapValidator/bootstrapValidator.js", //表单验证
          "~/Content/js/common/base-validator.js",
          "~/Content/js/lib/bootstrap-confirmation/bootstrap-confirmation.js" //确认提示
          ));

            #endregion
            #region js 插件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-switch").Include(
           "~/Content/js/lib/bootstrap-switch.js")); //开关插件
            #endregion
            #region page js
            //文件上传组件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-fileinput").Include(
"~/Content/js/lib/bootstrap-fileinput/js/fileinput.js",
"~/Content/js/lib/bootstrap-fileinput/js/locales/zh.js",
"~/Content/js/common/base-Fileinput.js"
));
            //日期组件
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
"~/Content/js/lib/bootstrap-datetimepicker/js/bootstrap-datetimepicker.js",
"~/Content/js/lib/bootstrap-datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js",
"~/Content/js/common/base-Datetimepicker.js"));

            //ECharts报表
            bundles.Add(new ScriptBundle("~/bundles/echarts").Include(
"~/Content/js/lib/echarts.js",
"~/Content/js/common/base-ECharts.js"));
            //wizard 组件
            bundles.Add(new ScriptBundle("~/bundles/wizard").Include(
"~/Content/js/lib/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
"~/Content/js/common/base-wizard.js"));
            #endregion

            #region css
            //1.Core STYLES
            bundles.Add(new StyleBundle("~/Content/core/css").Include(
                   "~/Content/css/lib/font-awesome.css",
                   "~/Content/css/lib/simple-line-icons.css",
                   "~/Content/css/lib/bootstrap.css"
                   ));
            //2.LAYOUT STYLES
            bundles.Add(new StyleBundle("~/Content/layout/css").Include(
                     "~/Content/css/layouts/layout.css",
                      "~/Content/css/components.css"
                    ));
            //3.index lib STYLES
            bundles.Add(new StyleBundle("~/Content/js/index/css").Include(
                    "~/Content/js/lib/bootstrapValidator.css",
                    "~/Content/js/lib/bootstrap-toastr/toastr.css",
                    "~/Content/js/lib/datatables/css/jquery.dataTables.css",
                    "~/Content/js/lib/datatables/css/datatables.bootstrap.css",
                    "~/Content/css/lib/bootstrap-switch.css"
                    ));
            //4.plugins STYLES
            bundles.Add(new StyleBundle("~/Content/plugins/css").Include(
                     "~/Content/css/plugins.css"
                    ));           
            // 5.Custorer Styles 自定义页面级样式
            bundles.Add(new StyleBundle("~/Content/custom/css").Include(
                   "~/Content/css/app/custom.css"
                  ));
            // home首页样式
            bundles.Add(new StyleBundle("~/Content/home/css").Include("~/Content/css/app/home.css"));
            //---------------------------Page UI Styles---------------------------- 
            #endregion
            #region page ui css

            bundles.Add(new StyleBundle("~/Content/fileinput").Include(
"~/Content/js/lib/bootstrap-fileinput/css/fileinput.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-datetimepicker").Include(
"~/Content/js/lib/bootstrap-datetimepicker/css/bootstrap-datetimepicker.css"));
            #endregion

            // 启用合并压缩
            //BundleTable.EnableOptimizations = false;

        }
    }
}
