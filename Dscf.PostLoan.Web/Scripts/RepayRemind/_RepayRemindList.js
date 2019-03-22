$(function () {
    validate();
});

function add() {
    $("#repayRemindType").val("-1");
    $(".form-control.height").val("");
    $("#tip i").removeClass("edit del");
    content = "";
    new Alert().AlertInfo({
        content: "#addRemind",
        title: "提醒记录", //是否显示标题
        width: "500",
        height: "400",
        callBack: function () {

            if (validator != null && !(validator.form())) {
                return false;
            }
            var params = {};
            params.repayRemindType = $("#repayRemindType").val();
            params.remindContent = $(".form-control.height").val();
            params.orderType = $("#addRemind").attr("data-ordertype");

            params.repayId = $.url.getQueryString("repayId");
            $.ajax(
                {
                    url: "/RepayRemind/AddRepayRemind",
                    method: "post",
                    async: true,
                    dataType: "json",
                    data: params,
                    success: function (result) {
                        result.ReturnData.RemindTypeName = $("#repayRemindType option:selected").text();
                        result.ReturnData.CreateTime = $.format.timestamp(result.ReturnData.CreateTime, "yyyy-MM-dd HH:mm");
                        $("#templete").tmpl(result.ReturnData).appendTo($("#tip"));
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: result.ReturnType ? 'yes' : 'error'
                        })
                    }
                }
            )
        }
    })
}
//function getRepayRemindList() {
//    var params = {};
//    params.repayId = $.url.getQueryString("repayId");
//    params.orderType = $("#addRemind").attr("data-ordertype");
//    $.ajax(
//    {
//        url: "/RepayRemind/GetRepayRemindList",
//        method: "post",
//        async: true,
//        dataType: "json",
//        data: params,
//        success: function (result) {
//            $("#tip").empty();
//            $.each(result.ReturnData, function (index, item) {
//                item.LastUpdateTime = $.format.timestamp(item.LastUpdateTime, "yyyy年MM月dd日");
//                $("#templete").tmpl(item).appendTo($("#tip"));
//            });

//        }
//    }
//)
//}
function action(type, ctreateOptId) {
    $("#tip i").removeClass("edit del f-hide");
    $("#tip i").each(function () {
        if ($(this).attr("data-createoptid") == ctreateOptId) {
            if (type == 1) {//编辑
                $(this).addClass("edit");
            }
            else {
                $(this).addClass("del");
            }
        }
    })
}
function edit(remingId, obj) {
    if ($(obj).hasClass("edit")) {
        content = $(obj).parent().next().next().next().text();
        $("#repayRemindType").val($(obj).attr("data-remindtype"));
        $(".form-control.height").val(content);
        new Alert().AlertInfo({
            content: "#addRemind",
            width: "500",
            height: "350",
            callBack: function () {
                if (validator != null && !(validator.form())) {
                    return false;
                }
                var params = {};
                params.remindId = remingId;
                params.repayRemindType = $("#repayRemindType").val();
                params.remindContent = $(".form-control.height").val();


                $.ajax(
                    {
                        url: "/RepayRemind/EditRepayRemind",
                        method: "post",
                        async: true,
                        dataType: "json",
                        data: params,
                        success: function (result) {

                            $("#" + result.ReturnData.RemindId + " label").contents().filter(function () { if (this.nodeType == 3) return this; }).remove();
                            $("#" + result.ReturnData.RemindId + " label").append($.format.timestamp(result.ReturnData.CreateTime, "yyyy-MM-dd HH:mm"));
                            $("#" + result.ReturnData.RemindId + " span:eq(1)").text($("#repayRemindType option:selected").text());
                            $("#" + result.ReturnData.RemindId + " span:eq(2)").text(result.ReturnData.RemindContent);
                            $("#" + result.ReturnData.RemindId + " label i").attr("data-remindtype", $("#repayRemindType").val());

                            $("#repayRemindType").val("-1");
                            $(".form-control.height").val("");
                            if (result.ReturnMsg == false) {
                                new Alert().AlertInfo({
                                    content: result.ReturnMsg,
                                    iClass: result.ReturnType ? 'yes' : 'error'
                                })
                            }
                        }
                    }
                )
            }
        })
    }
    else {
        new Alert().AlertInfo({
            content: "确定要删除吗？",
            width: "400",
            height: "330",
            callBack: function () {
                var params = {};
                params.remindId = remingId;
                $.ajax(
                    {
                        url: "/RepayRemind/DelRepayRemind",
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
                                $("#" + result.ReturnCount).remove();
                            }
                        }
                    }
                )
            }
        })

    }
}
function isContains(str, substr) {
    return str.indexOf(substr) == 0;
}
function validate() {
    validator = $("#remindForm").validate({
        errorClass: "bug",
        errorElement: 'p',
        errorPlacement: function (error, element) {

            if (element[0].tagName == "SELECT") {
                error.appendTo(element.parent().parent());
            }
            else {
                error.appendTo(element.parent().parent());
            }

        },
        rules: { "remindContent": { required: true ,update:true}, "repayRemindType": { select: true } },
        messages: {
            "remindContent": { required: "请填写提醒内容！" }
        }
    }
);
    $.validator.addMethod("select", function (value, element) {
        if (value == "-1" || value == "") {
            return false;
        }
        else return true;
    }, "请选择提醒结果！");
    $.validator.addMethod("update", function (value, element) {
        if (!isContains(value, content)) {
            return false;
        }
        else return true;
    }, "修改内容只能添加在原记录后面！");
    //$("span#delAction").click(function () {

    //});
}


