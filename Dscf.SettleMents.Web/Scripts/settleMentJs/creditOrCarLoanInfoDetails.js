var validator;

$(function () {
    //if ($(".detail").length>0) {
    //    $("#payApply").attr("disabled", true);
    //    $("#payOff").attr("disabled", true);
    //}
    layer.photos({
        photos: '#layer-photos'
     , anim: 0
    });
    validate();
    $('input[name="PayImage"]').change(function () {

        $("#UpFileNameList").empty();
        var checkedFiles = this.files;
        $.each(checkedFiles, function (index, file) {
            $("#UpFileNameList").append("<li>" + file.name + "</li>");
        });
        validator.element($('input[name="PayImage"]'));
    });
});

//申请划扣
function payApplyDeduction() {
    $("input[name='ReliefAmount']").val("0.00");
    $("input[name='RepayAmount']").val(parseFloat($("#sumOverdue").text()).toFixed(2));
    new Alert().AlertInfo({
        content: "#pay",
        width: "500",
        height: "400",
        callBack: function () {
            if (!validator.form()) { return false }
            else {
                layer.load(2);
                $("#form-applyDeduct").ajaxSubmit({
                    beforeSerialize: function () {
                        $('input[name="PayWay"]').val("1");
                    },
                    success: postSuccess
                });
            }
        }
    });
}

function payOffline() {
    $("input[name='ReliefAmount']").val("0.00");
    $("input[name='RepayAmount']").val(parseFloat($("#sumOverdue").text()).toFixed(2));
    new Alert().AlertInfo({
        content: "#pay",
        width: "500",
        height: "400",
        callBack: function () {
            if (!validator.form()) { return false }
            else {
                layer.load(2);
                $("#form-applyDeduct").ajaxSubmit({
                    beforeSerialize: function () {
                        $('input[name="PayWay"]').val("2");
                    },
                    success: postSuccess
                });
            }
        }
    });

}

function carManagement() {
    $("input[name='ReliefAmount']").val("0.00");
    $("input[name='RepayAmount']").val(parseFloat($("#sumOverdue").text()).toFixed(2));
    new Alert().AlertInfo({
        content: "#pay",
        width: "500",
        height: "400",
        callBack: function () {
            if (!validator.form()) { return false }
            else {
                layer.load(2);
                $("#form-applyDeduct").ajaxSubmit({
                    beforeSerialize: function () {
                        $('input[name="PayWay"]').val("3");
                    },
                    success: postSuccess
                });
            }
        }
    });
}

function action(obj) {
    if ($(obj).find("i").attr("class") == "down") {
        $(obj).find("i").removeClass('down').addClass("up");
        $(obj).find("span").html("点击收起");
        $("#loanDetail").removeClass("f-hide");
    } else {
        $(obj).find("i").removeClass('up').addClass("down");
        $(obj).find("span").html("点击查看更多");
        $("#loanDetail").addClass("f-hide");
    }
}




function postSuccess(request, status) {
    new Alert().AlertInfo({
        width: 600,
        height: 200,
        isIcon: false,
        btnCount: 1,
        content: request.ReturnMsg,
        callBack: function () {
            if (request.ReturnType) {
                window.location = "/OverdueCustomer/CarOverdueList?css=1056";
                return;
            }
            layer.close(2);
        }
    });
}
function validate() {
    validator = $("#form-applyDeduct").validate({
        errorClass: "bug",
        errorElement: 'p',
        errorPlacement: function (error, element) {
            if (element.attr("name") == "PayImage") {
                error.appendTo(element.parent().parent().parent());
            }
            else {
                $("#prompt").empty();
                error.appendTo($("#prompt"));
            }
        },
        rules: { "ReliefAmount": { required: true, number: true, min: 0, amount: true }, "RepayAmount": { required: true, number: true, min: 0, repay: true }, "PayImage": { required: true } },
        messages: {
            "ReliefAmount": { required: "请填写减免金额！", number: "请输入数字", min: "不能为负数！" },
            "RepayAmount": { required: "请填写还款金额！", number: "请输入数字", min: "不能为负数！" },
            "PayImage": { required: "请上传图片！" }

        }
    }
);
    $.validator.addMethod("repay", function (value, element) {

        var reliefAmount = $("input[name='ReliefAmount']").val();
        if (reliefAmount != null) {
            var sum = parseFloat(value) + parseFloat(reliefAmount);
            if (sum.toFixed(2) > parseFloat($("#sumOverdue").text())) {
                return false;
            }
            else if (sum.toFixed(2) < parseFloat($("#sumOverdue").text())) {

                $("#prompt").empty();
                $("#prompt").append("<p style='color:green'>减免金额和还款金额总和小于待还款总额</p>");
            }
        }
        return true;
    }, "减免金额和还款金额总和不能大于待还款总额");
    $.validator.addMethod("amount", function (value, element) {

        var repayAmount = $("input[name='RepayAmount']").val();
        if (repayAmount != null) {
            var sum = parseFloat(value) + parseFloat(repayAmount);
            if (sum.toFixed(2) > parseFloat($("#sumOverdue").text())) {
                return false;
            }
            else if (sum.toFixed(2) < parseFloat($("#sumOverdue").text())) {
                $("#prompt").empty();
                $("#prompt").append("<p style='color:green'>减免金额和还款金额总和小于待还款总额</p>");
            }
        }
        return true;
    }, "减免金额和还款金额总和不能大于待还款总额");
}

function actionDetail(obj) {
    if ($(obj).find("i").attr("class") == "down") {
        $(obj).find("i").removeClass('down').addClass("up");
        $(obj).find("span").html("点击收起");
        $("#loanDetail").removeClass("f-hide");
    } else {
        $(obj).find("i").removeClass('up').addClass("down");
        $(obj).find("span").html("点击查看更多");
        $("#loanDetail").addClass("f-hide");
    }
}


