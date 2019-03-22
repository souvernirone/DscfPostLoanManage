
$(function () {

    getPageLongCarRemindList();
    getPageShortCarRemindList();

    $(document).on("click", ".switch-animate", function () {
        var parms = {};
        parms.IsRemind = (!$(this).hasClass("switch-on")) == false ? 0 : 1;
        parms.RepayId = $(this).attr("data-repayid");


        if (!parms.IsRemind) {
            $(this).removeClass("switch-on").addClass("switch-off");

        }
        else {
            $(this).addClass("switch-on").removeClass("switch-off");
        }
        $.ajax({
            url: "/RepayRemind/UpdateCarRemind",
            method: "post",
            async: true,
            dataType: "json",
            data: parms,
            success: function (result) {
                if (result.ReturnType == false)
                    new Alert().AlertInfo({
                        content: result.ReturnMsg,
                        iClass: 'error'
                    });
            }
        });


    });

});


function getPageLongCarRemindList() {

    var page = new Page();
    page.Url = "/RepayRemind/GetPageCarRemindList";
    page.Dom = $(".search-long-condition");
    page.Container = $("#longLoanContainer");
    page.CallBack = function (data) {
        $("#longLoanContainer").empty();
        $.each(data, function (index, item) {
            item.IsRemind = (item.IsRemind == 0||item.IsRemind==null) ? "switch-off" : "switch-on";
            $("#tmplLongCarLoan").tmpl(item).appendTo($("#longLoanContainer"));

        });
    };
    page.GetPageData();
}

function getPageShortCarRemindList() {

    var page = new OtherPage();
    page.Url = "/RepayRemind/GetPageCarRemindList";
    page.Dom = $(".search-short-condition");
    page.Container = $("#shortLoanContainer");
    page.CallBack = function (data) {
        $("#shortLoanContainer").empty();
        $.each(data, function (index, item) {
            item.IsRemind = item.IsRemind ? "switch-on" : "switch-off";
            $("#tmplShortCarLoan").tmpl(item).appendTo($("#shortLoanContainer"));

        });
    };
    page.GetPageData();
}