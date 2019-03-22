
var vali;//= $("#remindForm").validate({

$(function () {
    validExtraForm();
    $(document).on("click", "#tip i", function () {

        var extraId = $(this).attr("data-id");

        if ($(this).hasClass("edit")) {

            var content = $('p#' + extraId + " span:eq(1)").text();

            $('textarea[name="ExtraContent"]').val(content);
            $('input[name="Id"]').val(extraId);
            new Alert().AlertInfo({
                content: "#addExtra",
                title: "编辑信息记录", //是否显示标题
                width: "500",
                height: "320",
                callBackOne: function () {
                    $('textarea[name="ExtraContent"]').val("");
                    $('input[name="Id"]').val("");
                },
                callBack: function () {

                    if (vali != null && !(vali.form())) {
                        return false;
                    }
                    var params = $.serializer.serialize('#extraInfoForm');
                    params._ = Math.random();

                    $.ajax({
                        url: "/ExtraInfo/Edit",
                        method: "post",
                        async: true,
                        dataType: "json",
                        data: params,
                        success: function (result) {

                            if (!result.ReturnType) {
                                new Alert().AlertInfo({
                                    content: result.ReturnMsg,
                                    iClass: 'error'
                                });
                                return;
                            }

                            $('p#' + result.ReturnData.Id + " span:eq(1)").text(result.ReturnData.ExtraContent);
                            $('textarea[name="ExtraContent"]').val("");
                            $('input[name="Id"]').val("");
                        }
                    });
                }
            });
        } else {
            new Alert().AlertInfo({
                content: "确定要删除吗？",
                width: "400",
                height: "330",
                callBack: function () {
                    $.ajax({
                        url: "/ExtraInfo/Delete",
                        method: "post",
                        async: true,
                        dataType: "json",
                        data: { Id: extraId },
                        success: function (result) {

                            if (!result.ReturnType) {
                                new Alert().AlertInfo({
                                    content: result.ReturnMsg,
                                    iClass: 'error'
                                });
                                return;
                            }
                            $('p#' + extraId).remove();
                        }
                    });
                }
            });
        }
    });
});

function add() {

    $("#tip i").removeClass("edit del");
    new Alert().AlertInfo({
        content: "#addExtra",
        title: "新增信息记录", //是否显示标题
        width: "500",
        height: "320",
        callBack: function () {

            if (vali != null && !(vali.form())) {
                return false;
            }
            var params = $.serializer.serialize('#extraInfoForm');
            params._ = Math.random();
            $.ajax({
                url: "/ExtraInfo/Create",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {

                    if (!result.ReturnType) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: 'error'
                        });
                        return;
                    }
                    result
                        .ReturnData.CreateTime = DateFormat.format.timestamp(result.ReturnData.CreateTime, "yyyy-MM-dd HH:mm");
                    $("#templete").tmpl(result.ReturnData).appendTo($("#tip"));

                }
            });
            $('textarea[name="ExtraContent"]').val("");
            $('input[name="Id"]').val("");
        }
    });

}

function action(type) {
    var currentOptId = $('input[name="CurrentOptId"]').val();

    $("#tip i").removeClass("edit del f-hide");
    $("#tip i").each(function () {
        if (currentOptId == $(this).attr("data-createoptid")) {
            if (type == 1) {//编辑
                $(this).addClass("edit");
            }
            else {
                $(this).addClass("del");
            }
        }
    });
}

function validExtraForm() {
    vali = $("#extraInfoForm").validate({
        rules: {
            ExtraContent: "required"
        },
        messages: {
            ExtraContent: "请输入新增内容"
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.parent().parent());
        },
        errorElement: 'p',
        errorClass: "bug"
    });
}

