/**
 * [Page 分页]
 * @Author yanlin
 * @DateTime 2016-10-12T09:59:58+0800
 */
var Page = function () { };
Page.prototype = {
    Count: 10,//当前页显示多少条数据
    Current: 1, //当前页
    Total: 0, //总页数
    Url: "", //地址
    Dom: null, //搜索条件的容器
    Container: null, //列表容器
    Data: {}, //参数
    DomId: "caption",//当没有数据时显示的容器id
    CountNumber: 0,//与DomId 一起用 列表的总列数  方便在没有数据时居中显示
    type: 0,
    CallBack: null, //回调函数
    GetPageData: function () {
        $this = this;
        if ($this.Dom) {
            $this.Data = $.serializer.serialize($this.Dom);
        }
        this.Count = parseInt($("#selelct_PageCount").val());
        this.Data.PageSize = this.Count;
        this.Data.PageNum = this.Current;
        this.Data.type = this.type;
        this.Data._ = Math.random();
        $.ajax({
            url: $this.Url,
            async: false,
            cache: false,
            dataType: "json",
            data: $this.Data,
            success: function (result) {
                if (result.ReturnType) {
                    if (result.ReturnCount > 0) {
                        laypage({
                            cont: 'pager', //容器。值支持id名、原生dom对象，jquery对象。
                            pages: result.ReturnData.TotalPageCount,  //通过后台拿到的总页数
                            curr: $this.Current, //当前页
                            skin: '#3C93D6',//自定义皮肤
                            skip: true, //是否开启跳页
                            jump: function (obj, first) { //触发分页后的回调
                                if (!first) { //点击跳页触发函数自身，并传递当前页：obj.curr
                                    $this.Current = obj.curr;
                                    $this.GetPageData();
                                }
                            }
                        });
                        if ($this.CallBack) {
                            if ($this.Container) {
                                $this.Container.empty();
                            }
                            $this.CallBack(result.ReturnData.CurrentPageItems);
                            $this.Total = result.ReturnData.TotalItemCount;
                        }
                        result.ReturnData.TotalPageCount == 1 ? $("#selectCount").hide() : $("#selectCount").show();
                    }
                    else {
                        if ($this.Container) {
                            $this.Container.empty();
                        }
                        $("#" + $this.DomId + "").attr("style", "color:red");
                        $("#" + $this.DomId + "").html("<td colspan=" + $this.CountNumber + " style='text-align:center'>暂无数据</td>");
                    }
                }
                else {
                    if ($this.Container) {
                        $this.Container.empty();
                    }
                    $("#" + $this.DomId + "").html("<td colspan=" + $this.CountNumber + " style='text-align:center;color:red'>" + result.ReturnMsg + "</td>");
                }
                $("#selelct_PageCount").unbind("change").change(function () {
                    var page = new Page();
                    page.Pchange();
                });
            }
        });
    },
    Pchange: function () {
        $this.Count = parseInt($("#selelct_PageCount").val());
        $this.Current = 1;
        $this.GetPageData();
    }

}


/**
 * [Page 分页]
 * @Author yanlin
 * @DateTime 2016-10-12T09:59:58+0800
 */
var OtherPage = function () { };
OtherPage.prototype = {
    Count: 10,//当前页显示多少条数据
    Current: 1, //当前页
    Total: 0, //总页数
    Url: "", //地址
    Dom: null, //搜索条件的容器
    Container: null, //列表容器
    Data: {}, //参数
    DomId: "caption",//当没有数据时显示的容器id
    CountNumber: 0,//与DomId 一起用 列表的总列数  方便在没有数据时居中显示
    type: 0,
    CallBack: null, //回调函数
    GetPageData: function () {
        $thisOther = this;
        if ($thisOther.Dom) {
            $thisOther.Data = $.serializer.serialize($thisOther.Dom);
        }
        this.Count = parseInt($("#selelct_OtherPageCount").val());
        this.Data.PageSize = this.Count;
        this.Data.PageNum = this.Current;
        this.Data.type = this.type;
        this.Data._ = Math.random();
        $.ajax({
            url: $thisOther.Url,
            async: false,
            cache: false,
            dataType: "json",
            data: $thisOther.Data,
            success: function (result) {
                if (result.ReturnType) {
                    if (result.ReturnCount > 0) {
                        laypage({
                            cont: 'pagerOther', //容器。值支持id名、原生dom对象，jquery对象。
                            pages: result.ReturnData.TotalPageCount,  //通过后台拿到的总页数
                            curr: $thisOther.Current, //当前页
                            skin: '#3C93D6',//自定义皮肤
                            skip: true, //是否开启跳页
                            jump: function (obj, first) { //触发分页后的回调
                                if (!first) { //点击跳页触发函数自身，并传递当前页：obj.curr
                                    $thisOther.Current = obj.curr;
                                    $thisOther.GetPageData();
                                }
                            }
                        });
                        if ($thisOther.CallBack) {
                            if ($thisOther.Container) {
                                $thisOther.Container.empty();
                            }
                            $thisOther.CallBack(result.ReturnData.CurrentPageItems);
                            $thisOther.Total = result.ReturnData.TotalItemCount;
                        }
                        result.ReturnData.TotalPageCount == 1 ? $("#selectOtherCount").hide() : $("#selectOtherCount").show();
                    }
                    else {
                        if ($thisOther.Container) {
                            $thisOther.Container.empty();
                        }
                        $("#" + $thisOther.DomId + "").attr("style", "color:red");
                        $("#" + $thisOther.DomId + "").html("<td colspan=" + $thisOther.CountNumber + " style='text-align:center'>暂无数据</td>");
                    }
                }
                else {
                    if ($thisOther.Container) {
                        $thisOther.Container.empty();
                    }
                    $("#" + $thisOther.DomId + "").html("<td colspan=" + $thisOther.CountNumber + " style='text-align:center;color:red'>" + result.ReturnMsg + "</td>");
                }
                $("#selelct_OtherPageCount").unbind("change").change(function () {
                    var page = new OtherPage();
                    page.Pchange();
                });
            }
        });
    },
    Pchange: function () {
        $thisOther.Count = parseInt($("#selelct_OtherPageCount").val());
        $thisOther.Current = 1;
        $thisOther.GetPageData();
    }

}

