function info(obj, id) {
    $("#collectionStatus").val($(obj).parent().parent().find("td:eq(2)").attr("data-collectionstatus"));
    $("#linkPersonType option:contains("+ $(obj).parent().parent().find('td:eq(4)').text() +")")[0].selected= true;
    $("#outboundAddress").val($(obj).parent().parent().find("td:eq(3)").text());
    $("#collectionRecord").val($(obj).parent().parent().find("td:eq(5)").text());

    new Alert().AlertInfo({
        content: "#loanInfo",
        width: "400",
        height: "475",
        callBack: function () {
            var params = {};
            params.CollectionStatus = $("#collectionStatus").val();
            params.OutboundAddress = $("#outboundAddress").val();
            params.LinkPersonType = $("#linkPersonType").val();
            params.CollectionRecord = $("#collectionRecord").val();
            params.Id = id;

            $.ajax(
                {
                    url: "/CollectionInfo/UpdateCollectionInfo",
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
                            $(obj).parent().parent().find("td:eq(2)").text($("#collectionStatus option:selected").text());
                            $(obj).parent().parent().find("td:eq(3)").text(result.ReturnData.OutboundAddress);
                            $(obj).parent().parent().find("td:eq(4)").text($("#linkPersonType option:selected").text());
                            $(obj).parent().parent().find("td:eq(5)").text(result.ReturnData.CollectionRecord);
                        }
                    }
                }
            )
        }
    });
}
function del(obj, id) {
    new Alert().AlertInfo({
        content: "确定要删除吗？",
        width: "400",
        height: "330",
        callBack: function () {
            var params = {};
            params.id = id;
            $.ajax(
                {
                    url: "/CollectionInfo/DelCollectionInfo",
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
                            $(obj).parent().parent().remove();
                        }
                    }
                }
            )

        }
    });

}