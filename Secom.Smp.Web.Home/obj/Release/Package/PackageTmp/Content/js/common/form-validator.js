define(function () {
    //表单id，model Id，验证选项
    var retValidatorInit = function (formId, modelId, options) {
        var form = $('#' + formId);
        $("#" + modelId).on('hidden.bs.modal', function () {  //Modal验证销毁重构
            form.data('bootstrapValidator').destroy();
            form.data('bootstrapValidator', null);
            form.bootstrapValidator(options);
        })
    }
    var formObj = {
        //验证表单ID，配置验证对象，验证成功回调函数
        init: function (formId, options, successFunc) {
            var form = $('#' + formId);
            form.bootstrapValidator(options);
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
                        if (successFunc != undefined) {
                            successFunc();
                        }
                    } else {
                        toastr.error(result.message);
                    }
                });
            });
        }
        , retValidatorInit: retValidatorInit
    }
    return formObj;
})