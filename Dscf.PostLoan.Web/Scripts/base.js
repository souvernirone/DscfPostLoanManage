/**
 * 
 * @authors Your Name (you@example.org)
 * @date    2016-09-09 11:21:10
 * @version $Id$
 */
var CarInit = {};

CarInit.windowBasedLayout = function() {
    var width = window.innerWidth;
    if (width < 1025) {
        // small window
        $(".g-sd1").addClass("collapseit").removeClass("expandit");
        $("#main-content").addClass("sidebar_shift").removeClass("chat_shift");
        CarInit.mainmenuCollapsed();

    } else {

        // large window
        $(".g-sd1").removeClass("collapseit coll");
        $("#main-content").removeClass("sidebar_shift");
        CarInit.mainmenuScroll();
    }


}

/**
 * [mainmenuCollapsed  菜单折叠]
 * @Author
 * @DateTime 2016-09-09T15:15:38+0800
 */
CarInit.mainmenuCollapsed = function() {
    if ($("#main-menu-wrapper").length > 0) {
        var topbar = $(".g-hd").height();
        var windowheight = window.innerHeight;
        var minheight = windowheight - topbar;
        var fullheight = $("#main-content").height();

        var height = fullheight;

        if (fullheight < minheight) {
            height = minheight;
        }
        $('#main-menu-wrapper').perfectScrollbar('destroy');

        $('#main-menu-wrapper .m-sd').height(height);
        $(".m-sd li.open .sub-menu").attr("style", "");
        $(".m-sd li .sub-menu").attr("style", "");

        //总高度-topbar-滚动高度

        $(".sideDiv").height(document.documentElement.clientHeight - topbar);

    }

};

CarInit.mainMenu = function() {
    $('.m-sd li a').click(function(e) {
        if ($(this).next().hasClass('sub-menu') === false) {
            return;
        }
        var parent = $(this).parent().parent();
        var sub = $(this).next();
        parent.children('li.open').children('.sub-menu').slideUp(200);
        parent.children('li.open').children('a').children('.arrow').removeClass('open');
        parent.children('li').removeClass('open');
        if (sub.is(":visible")) {
            $(this).parent().removeClass("open");
            $(this).find(".arrow").removeClass("open");
            sub.slideUp(200);

        } else {
            $(this).parent().addClass("open");
            $(this).find(".arrow").addClass("open");
            sub.slideDown(200);

        }
        if(window.innerWidth<1025 && $(".g-sd1").hasClass("collapseit")){
             $(".m-sd li .sub-menu").attr("style", "");
        }

    });
};


/**
 * [mainmenuScroll 菜单滚动条]
 * @Author
 * @DateTime 2016-09-09T15:19:58+0800
 * @return   {[type]}                 [description]
 */
CarInit.mainmenuScroll = function() {
    var topbar = $(".g-hd").height();
    var height = window.innerHeight - topbar;
    $('#main-menu-wrapper').height(height).perfectScrollbar({
        suppressScrollX: true
    });
    $('#main-menu-wrapper .m-sd ').height('auto');
    $(".sideDiv").height(document.documentElement.clientHeight - topbar);

    // var getcookie = getCookieValue("menuid");        
    // if (getcookie != null && getcookie != "")//判断是否有缓存       
    // {        
    // $("." + getcookie).parent().show();      
    // $("." + getcookie).parent().parent().attr("class", "open");      
    // $("." + getcookie).find("a").addClass("active");     
    // $("li.open > .sub-menu").attr("style", "display:block");     
    // }
    $("li.open > .sub-menu").attr("style", "display:block;");


};

/**
 * [SystemApi 一些api的事件]
 * @Author
 * @DateTime 2016-09-12T11:06:10+0800
 */
CarInit.SystemApi = function() {
    $('.sidebar_toggle').on('click', function() {
        var mainarea = $("#main-content");
        var menuarea = $(".g-sd1");

        if (menuarea.hasClass("collapseit") || menuarea.hasClass("chat_shift")) {
            menuarea.addClass("expandit").removeClass("collapseit").removeClass("chat_shift");
            mainarea.removeClass("sidebar_shift").removeClass("chat_shift");
            $(this).find(".sidebar").removeClass('z-sidebar');
            $("#main-menu-wrapper").parent().removeClass('coll');
           // CarInit.mainmenuScroll();
        } else {
            menuarea.addClass("collapseit").removeClass("expandit").removeClass("chat_shift");
            mainarea.addClass("sidebar_shift").removeClass("chat_shift");
            CarInit.mainmenuCollapsed();
            $(this).find(".sidebar").addClass('z-sidebar');
            $("#main-menu-wrapper").parent().addClass('coll');

        }
    });
    $('.m-tnav li').on('click', function() {
        var ids = $(this).children().attr("data-href");
        $(this).parent().siblings().find(">div").removeClass('active');
        $(this).parent().siblings().find("" + ids + "").addClass("active");
        $(this).siblings().removeClass("active");
        $(this).addClass("active");
    });


}


var Url = function() {};
Url.prototype = {
    type: function() {
        return GetQueryString("id")
    },
    GetQueryString: function(name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]);
        return null;
    }
}


/**
 * [shrink 收缩的div]
 * @Author
 * @DateTime 2016-09-13T10:10:31+0800
 * @return   {[type]}                 [description]
 */
shrink = function(num) {
    if ($(".m-shrink:eq(" + num + ") .title").find("i").hasClass('z-subtraction')) {
        $(".m-shrink:eq(" + num + ") .title").find("i").removeClass('z-subtraction').addClass('z-add');
        $(".m-shrink:eq(" + num + ") .cbody").slideUp();
    } else {
        $(".m-shrink:eq(" + num + ") .title").find("i").removeClass('z-add').addClass('z-subtraction');
        $(".m-shrink:eq(" + num + ") .cbody").slideDown();
    }
}



// datepicker
CarInit.datepicker = function() {
    if ($.isFunction($.fn.datepicker)) {
        $('.form_datetime').datepicker({
            format: 'yyyy-mm-dd',
            autoclose: 1,
            todayHighlight: 1,
            language: "zh-CN",
            todayBtn: "linked",
             orientation: "bottom auto"
        });
    }
}

function getValue($el, data_var, default_val) {
    if (typeof $el.data(data_var) != 'undefined') {
        return $el.data(data_var);
    }
    return default_val;
}

/**
 * [discard 弹框组件]
 * @Author
 * @DateTime 2016-09-19T11:38:37+0800
 */
function Alert() {
    this.cfg = {
        width: 480,
        height: 365,
        title: false, //是否显示标题
        isIcon: true, //是否显示提示图标
        iClass: "error", //图标的class名称
        content: "", //弹框的内容 可以是html
        btnCount: 2, //按钮数量
        btn:false, //是否自定义按钮
        skin:"alert-class", //皮肤
        btnText1: "确定", //按钮1 文字说明
        btnText2: "取消", //按钮2 文字说明
        callBack: null, // alert回调函数 第一个按钮
        callBackOne: null, // alert回调函数 第二个按钮
        callBackTwo: null, // alert回调函数 第右上角关闭按钮
        confirmCallBack: null, //cnfirm 回调函数
        winType: 1 //弹框类型 1：alert 2:comfirm
    }

}
Alert.prototype = {
    AlertInfo: function(cfg) {
        $(".layui-layer-btn a").unbind('click');
        var CFG = $.extend(this.cfg, cfg);
        var content = "";
        var isID = false;
        if (/^[\.|#]+/.test(CFG.content)) { //页面里面的内容 如class、id
            content = $("" + CFG.content + "");
            isID = true;
        } else {
            if (CFG.isIcon) {
                content += "<p class='wrap'><span class='" + CFG.iClass + "'></span></p>";
            }
            content += "<p class='content'>" + CFG.content + "</p>";
        }
        if (CFG.winType == 1) {
            if (CFG.btnCount == 1 && CFG.btn==false) {
                isID == false ? content += '<p class="layui-layer-btn"><a class="layui-layer-btn0">' + CFG.btnText1 + '</a></p>' : ($("" + CFG.content + "").html().indexOf("layui-layer-btn") < 0 ? $("" + CFG.content + "").append("<p class=\"layui-layer-btn\"><a class=\"layui-layer-btn0\">" + CFG.btnText1 + "</a></p>") : "");
            } else if (CFG.btnCount == 2 && CFG.btn==false) {
                isID == false ? content += '<p class="layui-layer-btn"><a class="layui-layer-btn0">' + CFG.btnText1 + '</a><a class="layui-layer-btn1">' + CFG.btnText2 + '</a></p>' : ($("" + CFG.content + "").html().indexOf("layui-layer-btn") < 0 ? $("" + CFG.content + "").append("<p class=\"layui-layer-btn\"><a class=\"layui-layer-btn0\">" + CFG.btnText1 + "</a><a class=\"layui-layer-btn1\">" + CFG.btnText2 + "</a></p>") : "");
            }
        }
        switch (CFG.winType) {
            case 1:
                {
                    layer.open({
                        type: 1,
                        title: CFG.title == false ? false : '' + CFG.title + '',
                        closeBtn: CFG.title == false ? 0 : 1,
                        skin: CFG.skin,
                        area: ['' + CFG.width + 'px', '' + CFG.height + 'px'], //宽高
                        content: content,
                        btn:CFG.btn,
                        yes: function (index) { //第一个按钮回调
                            if (CFG.callBack) {
                                if (CFG.callBack() === false) {
                                    return;
                                }
                                layer.close(index);
                            } else {
                                layer.close(index);
                            }
                        },
                        btn2: function(index) { //第二个按钮回调
                            CFG.callBackOne && CFG.callBackOne();
                        },
                        cancel: function() { //右上角关闭回调
                            CFG.callBackTwo && CFG.callBackTwo();
                        }

                    });
                    console.log(isID);
                   // isID==false?$(".layui-layer-content").height("auto"):$(".layui-layer-btn").css("margin-top","0");
                   $(".layui-layer-content").height("100%");
                    break;
                }
            case 2:
                {
                    if (CFG.title != false) {
                        CFG.height += 40;
                    }
                    layer.confirm(content, {
                            title: CFG.title == false ? false : '' + CFG.title + '',
                            skin: 'alert-class',
                            closeBtn: CFG.title == false ? 0 : 1,
                            area: ['' + CFG.width + 'px', '' + CFG.height + 'px'], //宽高
                        },
                        function(index) {
                            layer.close(index);
                            CFG.confirmCallBack && CFG.confirmCallBack();
                        },
                        function(index) {
                            layer.close(index);
                        });
                        // isID==false?$(".layui-layer-content").height("auto"):$(".layui-layer-btn").css("margin-top","0");
                         $(".layui-layer-content").height("100%");
                    break;
                }
        }

    }

}


/**
 * [Page 分页]
 * @Author
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
                            curr:  $this.Current, //当前页
                            jump: function(obj, first) { //触发分页后的回调
                                if (!first) { //点击跳页触发函数自身，并传递当前页：obj.curr
                                    $this.Current=obj.curr;
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
                        result.ReturnData.TotalPageCount==1?$("#selelct_PageCount").hide():$("#selelct_PageCount").show();
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

                $("#selelct_PageCount").unbind("change").change(function() {
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
 * [closeWind 关闭当前窗口]
 * @Author
 * @DateTime 2016-10-13T18:09:35+0800
 * @return   {[type]}                 [description]
 */
function closeWind() {
    window.close();
}
/**
 * [closeWind 重置]
 * @Author
 * @DateTime 2016-10-13T18:09:35+0800
 * @return   {[type]}                 [description]
 */
function reset(obj){
    if(obj)
    {
        $("."+obj+"").find(':input').not(':button, :submit, :reset').val('').removeAttr('checked');
        $("."+obj+"").find("option[value='-1']").attr("selected",true);
    }
    else{
        $(".cbody").find(':input').not(':button, :submit, :reset').val('').removeAttr('checked');
        $(".cbody").find("option[value='-1']").attr("selected",true);
    }

}

/**
 * [iealert 判断IE是否在10以下]
 * @Author
 * @DateTime 2016-10-19T13:26:34+0800
 * @return   {[type]}                 [description]
 */
$.fn.iealert=function(){
    this.defaults = { 
            support: "ie7",  // ie8 (ie6,ie7,ie8), ie7 (ie6,ie7), ie6 (ie6)
            title: "\u4F60\u77E5\u9053\u4F60\u7684Internet Explorer\u662F\u8FC7\u65F6\u4E86\u5417?", // title text
            text: "\u4E3A\u4E86\u5F97\u5230\u6211\u4EEC\u7F51\u7AD9\u6700\u597D\u7684\u4F53\u9A8C\u6548\u679C,\u6211\u4EEC\u5EFA\u8BAE\u60A8\u5347\u7EA7\u5230\u6700\u65B0\u7248\u672C\u7684Internet Explorer\u6216\u9009\u62E9\u53E6\u4E00\u4E2Aweb\u6D4F\u89C8\u5668.\u4E00\u4E2A\u5217\u8868\u6700\u6D41\u884C\u7684web\u6D4F\u89C8\u5668\u5728\u4E0B\u9762\u53EF\u4EE5\u627E\u5230.<br /><br /><h1 id='goon' onclick='javascript:$(\".layui-layer,.layui-layer-shade\").remove()' style='font-size:20px;cursor:pointer;'>>>>\u7EE7\u7EED\u8BBF\u95EE</h1>"
        };
    var option = $.extend(this.defaults, option);
    return this.each(function(){
                if (parseInt(IETester())<10) {
                    var $this = $(this);  
                    initialize($this, option);
                } 
            }); 
}
initialize=function($obj,option){
   var panel = "<div id='ie-alert-panel'><h1>"+ option.title +"</h1>"
                  + "<p>"+ option.text +"</p>"
                  + "<div class='browser'>"
                  + "<ul>"
                  + "<li><a class='chrome' href='https://www.google.com/chrome/' target='_blank'></a></li>"
                  + "<li><a class='firefox' href='http://www.mozilla.org/en-US/firefox/new/' target='_blank'></a></li>"
                  + "<li><a class='ie9' href='http://windows.microsoft.com/en-US/internet-explorer/downloads/ie/' target='_blank'></a></li>"
                  + "<li><a class='safari' href='http://www.apple.com/safari/download/' target='_blank'></a></li>"
                  + "<li><a class='opera' href='http://www.opera.com/download/' target='_blank'></a></li>"
                  + "<ul>"
                  + "</div></div>"; 
       layer.alert(panel,{title:false,closeBtn:true,btn:false, area:["500px","280px"]});
}
function IETester(userAgent){
    var UA =  userAgent || navigator.userAgent;
    if(/msie/i.test(UA)){
        return UA.match(/msie (\d+\.\d+)/i)[1];
    }else if(~UA.toLowerCase().indexOf('trident') && ~UA.indexOf('rv')){
        return UA.match(/rv:(\d+\.\d+)/)[1];
    }
    return false;
}

$(function() {
    CarInit.mainmenuScroll();
   // CarInit.windowBasedLayout();
    CarInit.mainMenu();
    CarInit.SystemApi();
    CarInit.datepicker();

    $("body").iealert();

    /*默认打开选中菜单*/
    var openMenu = $.url.getQueryString('css');
    if (openMenu) {
        $('a[data-id="' + openMenu + '"]').addClass("active");
        $('a[data-id="' + openMenu + '"]').parents("ul.sub-menu").show();
        $('a[data-id="' + openMenu + '"]').parent().parent().parent().parent().addClass("open").find("span.arrow").addClass("open");
    }

    //设置cookie  判断是否是本页
    //if (lasturl !== document.location.href) {
    //    document.cookie = "lasturl=" + escape(lasturl);
    //    $("#lasturl").attr("href", getCookie("lasturl"));
    //}


})
$(window).resize(function() {
    //CarInit.windowBasedLayout();
    $(".sideDiv").height(document.documentElement.clientHeight - $(".g-hd").height());
});
