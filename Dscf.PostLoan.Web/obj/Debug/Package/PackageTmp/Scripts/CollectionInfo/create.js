//Jquery Validation对象
var validator;

$(function () {
    validator = $("#form-collection").validate();

    $('input[name="CollectionFileList"]').change(function () {

        $("#UpFileNameList").empty();
        var checkedFiles = this.files;
        $.each(checkedFiles, function (index, file) {
            $("#UpFileNameList").append("<li>" + file.name + "</li>");
        });
        validator.element($('input[name="CollectionFileList"]'));

    });

    //提交按钮的触发事件
    $(document).on('click', "#saveForm", function () {
        if (validator.form()) {
            new Alert().AlertInfo({
                content: "确认操作?",
                iClass: "yes",
                callBack: function () {
                    layer.load(2);
                    $("#form-collection").ajaxSubmit({
                        success: postSuccess
                    });
                }
            });
        }
    });



});


function postSuccess(request, status) {
    new Alert().AlertInfo({
        width: 600,
        height: 200,
        isIcon: false,
        btnCount: 1,
        content: request.ReturnMsg,
        callBack: function () {
            if (request.ReturnType) {
                var type = $.url.getQueryString("OrderType");
                var orderId = $.url.getQueryString("OrderId");
                if (type == 1) {
                    window.location = "/OverdueCustomer/CreditOverdueDetail?orderId=" + orderId;
                } else {
                    window.location = "/OverdueCustomer/CarOverdueDetail?orderId=" + orderId;
                }
            }
            layer.close(2);
        }
    });
}