


$(function () {

    $("#search-btn").click(function (data) {
        $("#integrate").removeClass("f-hide");
        GetPageLoanInfoList();
    });

    $("#search-btn").triggerHandler("click");

})


function GetPageLoanInfoList()
{
    var page = new Page();
    page.Url = "/SettleMent/GetPageLoanInfoList";
    page.Dom = $(".search");
    page.Container = $("#container");
    page.CallBack = function (data) {
        $("#container").empty();
        $.each(data, function (index, item) {
            item.SignDate = $.format.timestamp(item.SignDate, "yyyy年MM月dd日");
            $("#templete").tmpl(item).appendTo($("#container"));
        });
    };

    page.GetPageData();
}

//查看信贷信息详情
//function Details(PARAMS) {
//    var temp_form = document.createElement("form");
//    temp_form.action = "/LoanInfo/CreditLoanInfoDetails";
//    temp_form.target = "_blank";
//    temp_form.method = "post";
//    temp_form.style.display = "none";
//    for (var x in PARAMS.data) {
//        var opt = document.createElement("textarea");
//        opt.name = x;
//        opt.value = PARAMS.data[x];
//        temp_form.appendChild(opt);
//    }
//    document.body.appendChild(temp_form);
//    temp_form.submit();
//}


