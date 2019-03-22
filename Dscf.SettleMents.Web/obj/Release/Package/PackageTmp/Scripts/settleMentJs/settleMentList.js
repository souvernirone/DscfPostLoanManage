
$(function () {
    getShouPageOverdueList();
    var myData = $("#todayTime").val();
    if (myData == 6 || myData == 20) {//批量划扣时间配置
        getPiLiangPageOverdueList();
    } else {
        $("#divShort").empty();
    }
    $("#allCh").click(function () {
        $("input[name='Checked'] ").prop("checked", this.checked);
    });
    $("input[name='Checked']").click(function () {
        if (!this.checked)
            $("#allCh").prop("checked", this.checked);
    })
});
function getPiLiangPageOverdueList() {
    var page = new Page();
    page.Url = "/Deduction/GetDeductCriticalityThroughList";
    page.Container = $("#container");
    page.CallBack = function (data) {
        $("#piLiangContainer").empty();
        $.each(data, function (index, item) {
            item.FirstOverdueTime = $.format.timestamp(item.FirstOverdueTime, "yyyy年MM月dd日");
            item.SignDate = $.format.timestamp(item.SignDate, "yyyy年MM月dd日");
            $("#piLiangTemplete").tmpl(item).appendTo($("#piLiangContainer"));
        });
    };
    page.GetPageData();
}

function getShouPageOverdueList() {
    var page = new Page();
    page.Url = "/Deduction/GetDeductThroughList";
    page.Container = $("#container");
    page.CallBack = function (data) {
        $("#shouContainer").empty();
        $.each(data, function (index, item) {
            item.FirstOverdueTime = $.format.timestamp(item.FirstOverdueTime, "yyyy年MM月dd日");
            item.SignDate = $.format.timestamp(item.SignDate, "yyyy年MM月dd日");
            $("#shouTemplete").tmpl(item).appendTo($("#shouContainer"));
        });
    };
    page.GetPageData();
}

function pass() {
    new Alert().AlertInfo({
        content: "确定扣款吗？",
        iClass: 'yes',
        callBack: function () {
            var params = {};
            var chk_value = [];
            $('input[name="Checked"]:checked').each(function () {
                chk_value.push($(this).val() + "," + $(this).parent().parent().attr("data-periodorder")
                    + "," + $(this).parent().parent().attr("data-code"));
            });

            params.idAndPeriods = chk_value;
            $.ajax({
                url: "/Deduction/AddADeductProgressByKey",
                method: "post",
                async: true,
                dataType: "json",
                data: params,
                success: function (result) {
                    if (!result.ReturnType) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: result.ReturnType ? 'yes' : 'error'
                        });
                    }
                    else { getPiLiangPageOverdueList(); }
                }
            });
        }
    })
}

function buckle() {
    new Alert().AlertInfo({
        content: "确定扣款吗？",
        iClass: 'yes',
        callBack: function () {
            $.ajax({
                url: "/Deduction/AddADeductProgress",
                method: "post",
                async: true,
                dataType: "json",
                success: function (result) {
                    if (!result.ReturnType) {
                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: result.ReturnType ? 'yes' : 'error'
                        });
                    }
                    else { getPiLiangPageOverdueList(); }
                }
            });
        }
    })
}


function redirectPL(orderId, ApprovalStatus) {
    window.open("/Deduction/CreditBatchDeductClaims?orderId=" + orderId + "&orderState=2&css=1055");
}