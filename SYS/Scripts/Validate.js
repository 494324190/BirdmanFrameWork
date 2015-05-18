/*
创建时间：2015/3/15
创建人：ZG
版本：1.0

修改时间：2015/3/17
修改人：ZG
修改内容：增加自定义提示消息方法vdUserMessage，增加equalsStr来和固定值进行对比
版本：1.1.0

修改时间：2015/3/31
修改人：ZG
修改内容：增加手机号码验证
版本：1.2.0
*/


var json;
//页面初始化绑定验证
jQuery.Validate = function () {
    jQuery("input").each(function (index, element) {
        var $ele = jQuery(this);
        $ele.blur(function () {
            if ($ele.attr("data-bsvalidate") != undefined) {
                vd($ele, $ele.attr("data-bsValidate"));
            }
        })
    });
};
//提交验证
jQuery.SubmitValidate = function () {
    var result = true;
    jQuery("input[data-validate='true']").each(function (index, element) {
        var $ele = jQuery(this);
        result = vd($ele, $ele.attr("data-bsValidate"));
    });
    return result;
}
function vd(obj, attr) {
    json = eval('(' + attr + ')');
    var result = true;
    jQuery.each(json, function (key, val) {
        if (!result) {
            return false;
        }
        switch (val.name) {
            case "isNotNull":
                if (jQuery(obj).val() == "" || jQuery(obj).val() == undefined || jQuery(obj).val() == null) {
                    vdMessage(obj, 'isNotNull')
                    result = false;
                } else {
                    vdYes(obj);
                }
                break;
            case "length":
                var textLength = jQuery(obj).val().length;
                if (parseInt(textLength) < parseInt(val.Length.minLength) || parseInt(textLength) > parseInt(val.Length.maxLength)) {
                    vdMessage(obj, 'length')
                    result = false;

                } else {
                    vdYes(obj);
                }
                break;
            case "email":
                var Regex = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
                if (!Regex.test(jQuery(obj).val())) {
                    vdMessage(obj, 'email')
                    result = false;
                } else {
                    vdYes(obj);
                }
                break;
            case "duplicate":
                var $val = jQuery(obj).val()
                jQuery.ajax({
                    url: "/Base/isExistence",
                    data: { "para": $val },
                    type: "POST",
                    success: function (data) {
                        if (data == 1) {
                            vdMessage(obj, 'duplicate')
                            result = false;
                        } else {
                            vdYes(obj);
                        }
                    }
                })
                break;
            case "equals":
                var $val = jQuery(obj).val()
                var $valEq = jQuery('#' + val.eq).val();
                if ($val != $valEq) {
                    vdMessage(obj, 'equals')
                } else {
                    vdYes(obj);
                }
                break;
            case "equalsStr":
                var $val = jQuery(obj).attr('data-uStr');
                var $valEq = jQuery(obj).attr('data-str');
                if ($val != $valEq) {
                    vdMessage(obj, 'equals')
                } else {
                    vdYes(obj);
                }
                break;
            case "MPhone":
                var $val = jQuery(obj).val();
                if (!(/^1[3|4|5|7|8][0-9]\d{4,8}$/.test($val))) {
                    vdMessage(obj, 'MPhone')
                } else {
                    vdYes(obj);
                }
                break;
        }

    });
    return result;
}
function vdMessage(obj, type) {
    var name = jQuery(obj).attr("id");
    //var json = eval('(' + attr + ')');
    var message = "";
    if (jQuery(obj).next().hasClass("ValidateFalse")) {
        jQuery(obj).next().removeClass("ValidateFalse glyphicon glyphicon-remove")
        jQuery("#" + name + "_message").remove();
    }
    //获取当前验证条件对应的自定义消息
    message = vdUserMessage(type);
    switch (type) {
        case "isNotNull":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>必填写字段</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "length":
            jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
            jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>长度介于" + json[1].Length.minLength + "个字和" + json[1].Length.maxLength + "个字之间</span>");
            break;
        case "equals":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>请再次输入相同的值</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "email":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>邮箱地址不正确</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "duplicate":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>该信息已存在</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "equals":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>两次输入不一致</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "equalsStr":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>与固定值不符</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
        case "MPhone":
            if (message == undefined || message == null || message == "") {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>手机号码不正确</span>");
            } else {
                jQuery(obj).next().addClass("ValidateFalse glyphicon glyphicon-remove");
                jQuery(obj).next().after("<span class='ValidateFalse' id='" + name + "_message'>" + message + "</span>");
            }
            break;
    }
}
function vdYes(obj) {
    jQuery(obj).next().removeClass("ValidateFalse glyphicon glyphicon-remove").addClass('ValidateTrue glyphicon glyphicon-ok');
    var name = jQuery(obj).attr("id");
    jQuery("#" + name + "_message").remove();
}

function vdUserMessage(type) {
    var message = "";
    jQuery.each(json, function (key, val) {
        if (type == val.name) {
            message = val.message;
            return false;
        }
    });
    return message;
}