$(function () {

    $(document).on("click", "a.CarLoanLink", function () {
        actionCarLoan($(this));
    });

    $(document).on("click", "a.CreditLoanLink", function () {
        actionCreditLoan($(this));
    });

    $(document).on("click", "td.CollectionType", function () {
        updateOptType($(this));
    });


});


//车贷催收支持城市修改
function actionCarLoan($this) {
    var registParms = {};//
    registParms.Id = $this.attr('data-optid'); //当前催收人员ID

    var collectorType = $this.parents('tr').attr('data-type'); //获取当前催收类型
    if (collectorType == -1) {
        new Alert().AlertInfo({
            content: "请您先选择当前催收人员的角色!",
            iClass: 'error'
        });
        return;
    }

    //清除城市复选框状态
    $('input[name="CarLoanCity"]').each(function () {
        $(this).prop("checked", false).attr("disabled", false);;
    })

    //初始化弹出层城市复选框状态
    var queryParms = {};
    queryParms.Role = "CarLoan";
    queryParms.TypeId = $this.parents('tr').attr('data-type');

    $.ajax({
        url: "/TaskOrder/QuerySupportCity",
        method: "post",
        async: true,
        dataType: "json",
        data: queryParms,
        success: function (result) {
            if (result.ReturnType) {

                $.each(result.ReturnData, function (index, item) {
                    $.each(item.SupportDeptList, function (index, dept) {
                        $('#CarLoan' + dept).prop("checked", true);
                        if (registParms.Id != item.Id) {
                            $('#CarLoan' + this).attr("disabled", "disabled");
                        }
                    });

                });
            }

        }
    });

    new Alert().AlertInfo({
        title: "选择车贷催收城市信息", //是否显示标题
        content: "#cityCarLoanLayer",
        width: "650",
        height: "600",
        callBack: function () {

            var chk_value = [];
            var chk_name = [];
            $('input[name="CarLoanCity"]:checked').each(function () {
                if ($(this).attr('disabled') == 'disabled') {
                    return;
                }
                chk_value.push($(this).val());
                chk_name.push($(this).attr('data-name'));
            });

            registParms.CityIdList = chk_value;
            registParms.SourceType = 1;
            $.ajax({
                url: "/TaskOrder/RegistCity",
                method: "post",
                async: true,
                dataType: "json",
                data: registParms,
                success: function (result) {

                    new Alert().AlertInfo({
                        content: result.ReturnMsg,
                        iClass: result.ReturnType ? 'yes' : 'error'
                    });

                    if (result.ReturnType) {
                        var supportCityNames = chk_name.join(',');
                        $('td#CarLoan' + registParms.Id).html(supportCityNames);
                    }

                }
            });

        }
    });
}

//信贷催收支持城市修改
function actionCreditLoan($this) {
    var registParms = {};//
    registParms.Id = $this.attr('data-optid'); //当前催收人员ID

    var collectorType = $this.parents('tr').attr('data-type'); //获取当前催收类型
    if (collectorType == -1) {
        new Alert().AlertInfo({
            content: "请您先选择当前催收人员的角色!",
            iClass: 'error'
        });
        return;
    }

    //清除城市复选框状态
    $('input[name="CreditLoanCity"]').each(function () {
        $(this).prop("checked", false).attr("disabled", false);;
    })

    //初始化弹出层城市复选框状态
    var queryParms = {};
    queryParms.Role = "CreditLoan";
    queryParms.TypeId = $this.parents('tr').attr('data-type');

    $.ajax({
        url: "/TaskOrder/QuerySupportCity",
        method: "post",
        async: true,
        dataType: "json",
        data: queryParms,
        success: function (result) {
            if (result.ReturnType) {

                $.each(result.ReturnData, function (index, item) {
                    $.each(item.SupportDeptList, function (index, dept) {
                        $('#CreditLoan' + dept).prop("checked", true);
                        if (registParms.Id != item.Id) {
                            $('#CreditLoan' + this).attr("disabled", "disabled");
                        }
                    });

                });
            }

        }
    });

    new Alert().AlertInfo({
        title: "选择信贷催收城市信息", //是否显示标题
        content: "#cityCreditLoanLayer",
        width: "650",
        height:"450",
        callBack: function () {

            var chk_value = [];
            var chk_name = [];
            $('input[name="CreditLoanCity"]:checked').each(function () {
                if ($(this).attr('disabled') == 'disabled') {
                    return;
                }
                chk_value.push($(this).val());
                chk_name.push($(this).attr('data-name'));
            });

            registParms.CityIdList = chk_value;
            registParms.SourceType =2;
            $.ajax({
                url: "/TaskOrder/RegistCity",
                method: "post",
                async: true,
                dataType: "json",
                data: registParms,
                success: function (result) {

                    new Alert().AlertInfo({
                        content: result.ReturnMsg,
                        iClass: result.ReturnType ? 'yes' : 'error'
                    });

                    if (result.ReturnType) {
                        var supportCityNames = chk_name.join(',');
                        $('td#CreditLoan' + registParms.Id).html(supportCityNames);
                    }

                }
            });

        }
    });
}

function updateOptType($this) {

    var parms = {};
    parms.OptId = $this.attr('data-optid');
    parms.TypeId = $this.parent('tr').attr('data-type');
    parms.OptName = $this.attr('data-optName');

    $('select[name="CollectionType"]').val(parms.TypeId);
    $('#CurrentOptName').val(parms.OptName);

    new Alert().AlertInfo({
        title: "选择催收角色", //是否显示标题
        content: "#collectionTypeLayer",
        callBack: function () {
            var changeCollectionType = $('select[name="CollectionType"] option:selected').val();//选中的值
            if (changeCollectionType != parms.TypeId) {

                parms.TypeId = changeCollectionType;
                parms.TypeName = $('select[name="CollectionType"] option:selected').text();

                $.ajax({
                    url: "/TaskOrder/UpdateOptCollectionType",
                    method: "post",
                    async: true,
                    dataType: "json",
                    data: { OptId: parms.OptId, Type: parms.TypeId },
                    success: function (result) {
                        //清空弹框数据
                        $('#CurrentOptName').val('');
                        $('input[name="CurrentTypeId"]').val('');

                        new Alert().AlertInfo({
                            content: result.ReturnMsg,
                            iClass: result.ReturnType ? 'yes' : 'error'
                        });
                        if (result.ReturnType) {
                            $this.html(parms.TypeName);
                            $this.next().html('');
                            $this.parent('tr').attr('data-type', parms.TypeId);
                        }
                    }
                });
            }
        }
    });
}