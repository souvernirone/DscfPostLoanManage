$(function () {
    carRemindExcle();
    return;
    financialExportExcle();
    overdueExportExcle();
})

function carRemindExcle()
{
    $(document).on("click", "#carRemindExcle", function () {
        var productName = $("#productName").val();
        var timeBegin = $("#timeBegin").val();
        var timeEnd = $("#timeEnd").val();

        new Alert().AlertInfo({
            content: "确定导出还款提醒记录？",
            width: "400",
            height: "330",
            iClass: 'yes',
            callBack: function () {

                self.location.href = "/ExcleInfo/RemindExcleListOut?productName=" + productName + "&timeBegin=" + timeBegin + "&timeEnd=" + timeEnd + "";
            }
        });


    })
}

function financialExportExcle()
{
    $(document).on("click", "#financialExportExcle", function () {
        var cityName = $("#cityName").val();
        var productName = $("#productName").val();
        var contractDataBegin = $("#contractDataBegin").val();
        var contractDataEnd = $("#contractDataEnd").val();
        var loansDataBegin = $("#loansDataBegin").val();
        var loansDataEnd = $("#loansDataEnd").val();
        var teamName = $("#teamName").val();
        var locationStr = "?1=1";
        cityName != "0" ? locationStr += "&CityName=" + cityName : false;
        productName != "0" ? locationStr += "&ProductName=" + productName : false;
        contractDataBegin != "" ? locationStr += "&ContractDataBegin=" + contractDataBegin : false;
        contractDataEnd != "" ? locationStr += "&ContractDataEnd=" + contractDataEnd : false;
        loansDataBegin != "" ? locationStr += "&LoansDataBegin=" + loansDataBegin : false;
        loansDataEnd != "" ? locationStr += "&LoansDataEnd=" + loansDataEnd : false;
        teamName != "0" ? locationStr += "&TeamName=" + teamName : false;
        new Alert().AlertInfo({
            content: "确定导出财务报表？",
            width: "400",
            height: "330",
            iClass: 'yes',
            callBack: function () {
                self.location.href = "/ExcleInfo/FinancialExportExcle" + locationStr;
            }
        });

    })
}

function overdueExportExcle()
{
    $(document).on("click", "#overdueExportExcle", function () {
        var overdueCityName = $("#overdueCityName").val();
        var customerType = $("#customerType").val();
        var overdueProductName = $("#overdueProductName").val();
        var payDate = $("#payDate").val();
        var collection = $("#collection").val();
        var nowStatus = $("#nowStatus").val();
        var locationStr = "?1=1";
        overdueCityName != "" ? locationStr += "&overdueCityName=" + overdueCityName : false;
        customerType != "" ? locationStr += "&customerType=" + customerType : false;
        overdueProductName != "" ? locationStr += "&overdueProductName=" + overdueProductName : false;
        payDate != "" ? locationStr += "&payDate=" + payDate : false;
        collection != "" ? locationStr += "&collection=" + collection : false;
        nowStatus != "" ? locationStr += "&nowStatus=" + nowStatus : false;
        new Alert().AlertInfo({
            content: "确定导出预期违约报表？",
            width: "400",
            height: "330",
            iClass: 'yes',
            callBack: function () {
                self.location.href = "/ExcleInfo/OverdueExportExcle" + locationStr;
            }
        });
    })
}