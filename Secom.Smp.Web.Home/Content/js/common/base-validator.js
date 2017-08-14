// ajax加载调试用
//# sourceURL=base-validator.js

//BootStrap-FormValidator表单验证组件扩展对象--created by zouqj 2017-7-23
var FormValidatorObj = (function () {
    this.table_local = "table_local"; //table ID
    this.options = {
        message: '输入值无效',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        }
    };
    //(表单id，[modal容器Id]，[datable容器ID])
    this.init = function (formId, modalId,tableId) {
        var form = $('#' + formId);
        var modalId = (modalId == undefined || modalId == null) ? FormValidatorObj.modalId : modalId;
        form.bootstrapValidator(FormValidatorObj.options);
        $("#" + modalId).on('hidden.bs.modal', function () {  //Modal验证销毁重构
            if (form.data('bootstrapValidator') != undefined) {
                form.data('bootstrapValidator').destroy();
                form.data('bootstrapValidator', null);
            }
            form.bootstrapValidator(FormValidatorObj.options);
        });
        form.on('success.form.bv', function (e) {//点击提交之后
            // Prevent form submission
            e.preventDefault();
            // Get the form instance
            var $form = $(e.target);
            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');
            // Use Ajax to submit form data 提交至form标签中的action，result自定义
            $.post($form.attr('action'), $form.serialize(), function (result) {
                //do something...
                if (result.state == "success") {
                    toastr.success(result.message);
                    // Enable the submit buttons  
                    form.bootstrapValidator('disableSubmitButtons', false);
                    bv.resetForm();
                    $("#" + modalId).modal('hide');//关闭模态窗体
                    document.getElementById(formId).reset(); //清空表单
                    if (tableId != undefined) {
                        DataTablesObj.reloadList(tableId); //刷新datatable
                    }
                } else {
                    toastr.error(result.message);
                }
            });
        });
    }
    return this;
}).call({});