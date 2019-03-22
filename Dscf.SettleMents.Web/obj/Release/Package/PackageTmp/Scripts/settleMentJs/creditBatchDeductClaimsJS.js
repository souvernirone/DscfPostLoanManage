$(function () {
    validate();

    layer.photos({
        photos: '#layer-photos',
        anim: 0
    });

});

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

function buckle() {

    new Alert().AlertInfo({
        content: "确定扣款吗？",
        callBack: function () {
            var params = {};
            params.orderId = $.url.getQueryString("orderId");
            params.orderType = 1;
            params.status = 2;
            params.deductKind = 1;
            params.deductType = 1;
            params.applyId = $.url.getQueryString("applyId");
            params.payType = 1;
            $.ajax({
                url: "/Deduction/UpdateApplyStatusByKey",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {

                    if (result.ReturnType == false) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: 'error'
                        })
                    }
                    else {
                        window.location = "/Deduction/CreditDeductionList?css=1055";
                        return;
                    }
                }
            });
        }
    });
}

function pass() {

    new Alert().AlertInfo({
        content: "确定已入账吗？",
        callBack: function () {
            var params = {};
            params.orderId = $.url.getQueryString("orderId");
            params.orderType = 1;
            params.status = 3;
            params.deductKind = 1;
            params.deductType = 2;
            $.ajax({
                url: "/Deduction/UpdateApplyStatusByKey",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {

                    if (result.ReturnType == false) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: 'error'
                        })
                    }
                    else {
                        window.location = "/Deduction/CreditDeductionList?css=1055";
                        return;
                    }
                }
            });
        }
    });
}
function reject() {

    new Alert().AlertInfo({
        content: "#addReason",
        width: "450",
        height: "280",
        callBack: function () {
            if (!validator.form()) {
                return false
            }
            var params = {};
            params.orderId = $.url.getQueryString("orderId");
            params.orderType = 1;
            params.reason = $("#reasonContent").val();
            params.status = 5;
            params.deductKind = 1;
            params.deductType = $.url.getQueryString("payWay");
            $.ajax({
                url: "/Deduction/UpdateApplyStatusByKey",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {

                    if (result.ReturnType == false) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: 'error'
                        })
                    }
                    else {
                        window.location = "/Deduction/CreditDeductionList?css=1055";
                        return;
                    }
                }
            });
        }
    });
}
function validate() {
    validator = $("#reasonForm").validate({
        errorClass: "bug",
        errorElement: 'p',
        errorPlacement: function (error, element) {
            error.appendTo(element.parent().parent());
        },
        rules: { "reasonContent": { required: true } },
        messages: {
            "reasonContent": { required: "请填写拒绝原因！" },

        }
    }
);
}