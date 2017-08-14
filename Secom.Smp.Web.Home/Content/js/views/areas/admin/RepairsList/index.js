$(function () {
    $("#submit_form").bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            username: {
                message: '用户名验证失败',
                validators: {
                    notEmpty: {
                        message: '用户名不能为空'
                    }
                }
            },
            phone: {
                validators: {
                    notEmpty: {
                        message: '电话号码不能为空'
                    }
                }
            },
            card_name: {
                validators: {
                    notEmpty: {
                        message: '信用卡不能为空'
                    }
                }
            }
        }
    });
    var displayConfirm = function () {
        var form = $('#submit_form');
        $('#tab4 .form-control-static', form).each(function () {
            var input = $('[name="' + $(this).attr("data-display") + '"]', form);
            if (input.is(":radio")) {
                input = $('[name="' + $(this).attr("data-display") + '"]:checked', form);
            }
            if (input.is(":text") || input.is("textarea")) {
                $(this).html(input.val());
            } else if (input.is("select")) {
                $(this).html(input.find('option:selected').text());
            } else if (input.is(":radio") && input.is(":checked")) {
                $(this).html(input.attr("data-title"));
            } else if ($(this).attr("data-display") == 'payment[]') {
                var payment = [];
                $('[name="payment[]"]:checked', form).each(function () {
                    payment.push($(this).attr('data-title'));
                });
                $(this).html(payment.join("<br>"));
            }
        });
    }
    var successFunc = function () {
        $('#form_wizard_1').find('.button-previous').hide();
        $('#form_wizard_1 .button-submit').click(function () {
            toastr.success("保存成功！");
        }).hide();
    }
    FormWizard.init('form_wizard_1', 'submit_form', displayConfirm, successFunc);
}
)