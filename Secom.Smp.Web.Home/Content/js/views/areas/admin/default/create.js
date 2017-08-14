$(function () {
    DatetimepickerObj.init('CreateTime');//(控件ID)
    //--------------表单验证
    FormValidatorObj.init("defaultForm","defaultModal","table_local"); //(表单id，[modal容器Id]，[datable容器ID])
    //初始化编辑界面的数据
    //--------------添加界面中的上传控件
    FileInputObj.init(undefined,"txt_file", "hidFileUrl", "/Admin/Default/ExportFile",true);  //配置项,控件ID，存储文件路径的控件ID，上传路径，是否新增页面
});