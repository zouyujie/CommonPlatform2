define(function () {
    var FormWizard = function () {
        return {
            //main function to initiate the module
            //最外层容器ID，需要提交的表单ID，显示确认界面函数，最后一步保存回调函数
            init: function (form_wizard_1, submit_form, displayConfirm,successFunc) {
                if (!jQuery().bootstrapWizard) {
                    return;
                }
                var form = $('#'+submit_form);
                var error = $('.alert-danger', form);
                var success = $('.alert-success', form);
                var formWizard = $('#' + form_wizard_1);

                var isValid = function () {
                    //获取表单对象
                    var bootstrapValidator = form.data('bootstrapValidator');
                    //手动触发验证
                    bootstrapValidator.validate();
                    return bootstrapValidator.isValid();
                }
                var handleTitle = function (tab, navigation, index) {
                    var total = navigation.find('li').length;
                    var current = index + 1;
                    // set wizard title
                    $('.step-title', formWizard).text('' + (index + 1) + ' / ' + total);
                    // set done steps
                    jQuery('li', formWizard).removeClass("done");
                    var li_list = navigation.find('li');
                    for (var i = 0; i < index; i++) {
                        jQuery(li_list[i]).addClass("done");
                    }

                    if (current == 1) {
                        formWizard.find('.button-previous').hide();
                    } else {
                        formWizard.find('.button-previous').show();
                    }

                    if (current >= total) {
                        formWizard.find('.button-next').hide();
                        formWizard.find('.button-submit').show();
                        if (displayConfirm != undefined && displayConfirm != null) {
                            displayConfirm();
                        }
                    } else {
                        formWizard.find('.button-next').show();
                        formWizard.find('.button-submit').hide();
                    }
                    App.scrollTo($('.page-title'));
                }
                // default form wizard
                formWizard.bootstrapWizard({
                    'nextSelector': '.button-next',
                    'previousSelector': '.button-previous',
                    onTabClick: function (tab, navigation, index, clickedIndex) {
                        //return false;
                        success.hide();
                        error.hide();

                        if (isValid() == false) {
                            return false;
                        }

                        handleTitle(tab, navigation, clickedIndex);
                    },
                    onNext: function (tab, navigation, index) {
                        success.hide();
                        error.hide();
                        if (isValid() == false) {
                            return false;
                        }

                        handleTitle(tab, navigation, index);
                    },
                    onPrevious: function (tab, navigation, index) {
                        success.hide();
                        error.hide();

                        handleTitle(tab, navigation, index);
                    },
                    onTabShow: function (tab, navigation, index) {
                        var total = navigation.find('li').length;
                        var current = index + 1;
                        var $percent = (current / total) * 100;
                        formWizard.find('.progress-bar').css({
                            width: $percent + '%'
                        });
                    }
                });
                if (successFunc != undefined && successFunc != null) {
                    successFunc();
                }
            }
        };
    }();
    return FormWizard;
})
