function applySubmit() {
    var params = {};
    params.loanProductOrerId = $.url.getQueryString("orderId");
    params.derationAmount = $("#derationAmount").val();
    params.extensionMemo = $("#extensionMemo").val();
    params.orderType = 2;
    params.repayId = $.url.getQueryString("repayId");
    if (!validator.form()) {
        return false;
    }
    new Alert().AlertInfo({
        content: "确定提交吗？",
        width: "400",
        height: "330",
        callBack: function () {
            $.ajax({
                url: "/RepayRemind/AddLoanExtensionApply",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {
                    if (result.ReturnType == true && $.url.getQueryString("css") == 1054) {
                        window.location = "/RepayRemind/CarRemindList?css=1054";
                    }
                    else if (result.ReturnType == true && $.url.getQueryString("css") == 1056) {
                        window.location = "/OverdueCustomer/CarOverdueList?css=1056";
                    }
                    else {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: result.ReturnType ? 'yes' : 'error',

                        })
                    }
                }
            })
        }
    })
}
$(function () {
    validate();
});
function validate() {
    validator = $(".spilds").validate({
        errorClass: "bug",
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.appendTo(element.parent());
        },
        rules: { "derationAmount": { required: true, number: true, min: 0 }, "extensionMemo": { required: true } },
        messages: {
            "derationAmount": { required: "请填写降额额度！", number: "请输入数字", min: "不能为负数！" },
            "extensionMemo": { required: "请填写展期意见！" }

        }
    }
);
}
function giveUp() {
    new Alert().AlertInfo({
        content: "确定放弃展期吗？",
        width: "400",
        height: "330",
        callBack: function () {
            var parms = {};
            parms.repayId = $.url.getQueryString("repayId");
            parms.isRemind = 3;

            $.ajax({
                url: "/RepayRemind/UpdateCarRemind",
                method: "post",
                async: true,
                dataType: "json",
                data: parms,
                success: function (result) {
                    if (result.ReturnType == true&&$.url.getQueryString("css")==1054) {
                        window.location = "/RepayRemind/CarRemindList?css=1054";
                    }
                    else if (result.ReturnType == true && $.url.getQueryString("css") == 1056) {
                        window.location = "/OverdueCustomer/CarOverdueList?css=1056";
                    }
                    else {
                        new Alert().AlertInfo({
                            content: result.ReturnType ? '放弃展期成功！' : '放弃展期失败！',
                            iClass: result.ReturnType ? 'yes' : 'error'
                        });
                    }
                }
            });
        }
    })
}