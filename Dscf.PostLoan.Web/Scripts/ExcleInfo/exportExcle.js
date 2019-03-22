
$(function () {
    getCityNameList($("#productType_jk").val());
    getProductNameList($("#productType_jk").val());
    GetOverDueCityNameList($("#loanOrderType").val());
    GetOverDueProductNameList($("#loanOrderType").val());
    $("#loanOrderType").change(function () {
        var loanOrderType = $(this).val();
        if (loanOrderType == '') {
            $("select[name='Platform']").html(str);
            return;
        }

        GetOverDueCityNameList(loanOrderType);
        GetOverDueProductNameList(loanOrderType);
    });

    $("#productType_jk").change(function () {
        var str = '<option value="">全部</option>';
        var productTypeId = $(this).val();
        if (productTypeId == '') {
            $("select[name='Platform']").html(str);
            return;
        }

        getCityNameList(productTypeId);
        getProductNameList(productTypeId);
    });
    $(document).on('click', '#financialExportExcle', function () {
        getFinancialExportExcle();
    })
    $('#overdueExportExcle').click(function () { Get0verdueExportExcle(); }
)
})

function getFinancialExportExcle() {
    var productType = $("#productType_jk").val();
    var cityName = $("#cityName_jk").val();
    var productName = $("#productName_jk").val();
    var contractDataBegin = $("#contractDataBegin_jk").val();
    var contractDataEnd = $("#contractDataEnd_jk").val();
    var loansDataBegin = $("#loansDataBegin_jk").val();
    var loansDataEnd = $("#loansDataEnd_jk").val();
    var teamName = $("#teamName_jk").val();
    var locationStr = "?1=1";
    locationStr += "&ProductType=" + productType;
    cityName != "0" ? locationStr += "&CityName=" + cityName : false;
    productName != "0" ? locationStr += "&ProductName=" + productName : false;
    contractDataBegin != "" ? locationStr += "&ContractDataBegin=" + contractDataBegin : false;
    contractDataEnd != "" ? locationStr += "&ContractDataEnd=" + contractDataEnd : false;
    loansDataBegin != "" ? locationStr += "&LoansDataBegin=" + loansDataBegin : false;
    loansDataEnd != "" ? locationStr += "&LoansDataEnd=" + loansDataEnd : false;
    teamName != "0" ? locationStr += "&TeamName=" + teamName : false;
    new Alert().AlertInfo({
        content: "确认导出财务报表？",
        iClass: "yes",
        callBack: function () {
            self.location.href = "/ExcleInfo/FinancialExportExcle" + locationStr;
        }
    })
}
function GetOverDueCityNameList(productTypeId) {
    $.ajax({
        url: "/ExcleInfo/GetCityNameListOfproductTypeId",
        data: { productTypeId: productTypeId },
        async: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            $("#deptId").empty();
            $("#deptId").append($("<option/>", { "value": "", "text": "全部" }));
            $.each(result.ReturnData, function (index, itemdata) {
                $("#deptId").append($("<option/>", { "value": itemdata.Id, "text": itemdata.SignCity }));
            });

        }
    });
}
function GetOverDueProductNameList(productTypeId) {
    $.ajax({
        url: "/ExcleInfo/GetProductNameListOfproductTypeId",
        data: { productTypeId: productTypeId },
        async: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            $("#loanTypeId").empty();
            $("#loanTypeId").append($("<option/>", { "value": "", "text": "全部" }));
            $.each(result.ReturnData, function (index, itemdata) {
                $("#loanTypeId").append($("<option/>", { "value": itemdata.ProductId, "text": itemdata.ProductName }));
            });
        }
    });
}

function getCityNameList(productTypeId) {
    $.ajax({
        url: "/ExcleInfo/GetCityNameListOfproductTypeId",
        data: { productTypeId: productTypeId },
        async: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            $("#cityName_jk").empty();
            $("#cityName_jk").append($("<option/>", { "value": "", "text": "全部" }));
            $.each(result.ReturnData, function (index, itemdata) {
                $("#cityName_jk").append($("<option/>", { "value": itemdata.Id, "text": itemdata.SignCity }));
            });

        }
    });
}

function getProductNameList(productTypeId) {
    $.ajax({
        url: "/ExcleInfo/GetProductNameListOfproductTypeId",
        data: { productTypeId: productTypeId },
        async: true,
        cache: false,
        dataType: "json",
        success: function (result) {
            $("#productName_jk").empty();
            $("#productName_jk").append($("<option/>", { "value": "", "text": "全部" }));
            $.each(result.ReturnData, function (index, itemdata) {
                $("#productName_jk").append($("<option/>", { "value": itemdata.ProductId, "text": itemdata.ProductName }));
            });

        }
    });
}
function Get0verdueExportExcle() {

    var loanOrderType = $("#loanOrderType").val();
    var customerType = $("#customerType").val();
    var deptId = $("#deptId").val();
    var loanTypeId = $("#loanTypeId").val();
    var repayDate = $("#repayDate").val();
    var status = $("#status").val();
    var collectStatus = $("#collectStatus").val();
    var data;

    var locationStr = "?1=1";
    locationStr += "&LoanOrderType=" + loanOrderType;
    deptId != "" ? locationStr += "&DeptId=" + deptId : false;
    loanTypeId != "" ? locationStr += "&LoanTypeId=" + loanTypeId : false;
    customerType != "" ? locationStr += "&CustomerType=" + customerType : false;
    repayDate != "" ? locationStr += "&RepayDate=" + repayDate : false;
    status != "" ? locationStr += "&Status=" + status : false;
    collectStatus != "" ? locationStr += "&CollectStatus=" + collectStatus : false;
    new Alert().AlertInfo({
        content: "确认导出逾期违约报表？",
        callBack: function () {
            self.location.href = "/ExcleInfo/OverdueExportExcle" + locationStr;
        }
    })
}