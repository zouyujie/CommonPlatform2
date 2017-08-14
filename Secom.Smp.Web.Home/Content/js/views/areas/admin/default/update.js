$(function () {
    DatetimepickerObj.init('CreateTime');//(控件ID)
    //--------------表单验证
    FormValidatorObj.init("updateForm","defaultModal","table_local"); //(表单id，[modal容器Id]，[datable容器ID])
    //初始化编辑界面的数据
    //([配置项]，控件ID，存储文件路径的控件ID,图片路径，上传路径，删除路径）
    FileInputObj.initUpdateImg(undefined,"txt_file", "hidFileUrl", "/Admin/Default/ExportFile", "/Admin/Default/DeleteFile");
})