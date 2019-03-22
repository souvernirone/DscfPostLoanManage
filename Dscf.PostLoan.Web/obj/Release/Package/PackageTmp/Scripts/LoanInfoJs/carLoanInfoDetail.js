


$(function () {

    var orderId = $("input[name='OrderId']").val();

    $.ajax({
        url: "/LoanInfo/QueryCarRepayList",
        method: "post",
        async: true,
        dataType: "json",
        data: { orderId: orderId, _: Math.random() },
        success: function (result) {
            if (result.ReturnType) {
                $("#container").empty();
                $.each(result.ReturnData, function (index, item) {
                    item.RepayDate = $.format.timestamp(item.RepayDate, "yyyy年MM月dd日");
                    $("#templete").tmpl(item).appendTo($("#container"));
                });
            }

        }
    });

})



