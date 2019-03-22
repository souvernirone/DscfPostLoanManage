//为避免冲突，将我们的方法用一个匿名方法包裹起来
(function ($) {

    $.serializer = (function () {

        return {
            //序列化指定区域表单元素
            serialize: function (dom) {
                if (!dom)
                    return;
                var json = {};
                $(dom).find("[name]:not('.NonSerialized')").each(function () {
                    var txtVal = $(this).val();
                    json[$(this).attr("name")] = txtVal;
                });
                json._ = Math.random();
                return json;
            },
            //反序列化JSON对象至指定区域表单元素、不包括RadioButton
            deSerialize: function (dom, data) {
                if (!data || !dom)
                    return;
                $(dom).find("[name]:not('.NonSerialized,:radio')").each(function () {
                    var value = data[$(this).attr("name")];
                    if (value == null) {
                        value = data[$(this).attr("name").replace("txt", "")];
                    }
                    if (value != null) {
                        $(this).val(value);
                    }
                });
            },
            //序列化指定区域拥有data-name属性元素
            serializeDataName: function (dom) {
                if (!dom)
                    return;
                var json = {};
                $(dom).find("[data-name]:not('.NonSerialized')").each(function () {

                    json[$(this).attr("data-name")] = $(this).text();
                });
                json._ = Math.random();
                return json;
            },


        };

    }());

    $.url = (function () {
        return {
            //抓取查询字符串
            getQueryString: function (name) {
                var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
                var r = window.location.search.substr(1).match(reg);
                if (r != null) return unescape(r[2]); return null;
            }
        };
    }());


    //传递jQuery到方法中，这样我们可以使用任何javascript中的变量来代替"$"      
})(jQuery);

