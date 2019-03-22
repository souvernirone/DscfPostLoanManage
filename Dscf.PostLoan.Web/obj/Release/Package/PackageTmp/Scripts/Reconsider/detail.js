
var uploader;
var validator;
var $wrap = $('#uploader'),

    // 图片容器
    $queue = $('ul.filelist'),

     // 状态栏，包括进度和控制按钮
    $statusBar = $wrap.find('.statusBar'),

    // 文件总体选择信息。
    $info = $statusBar.find('.info'),

     // 添加的文件数量
    fileCount = 0,

    // 添加的文件总大小
    fileSize = 0,

    // 优化retina, 在retina下这个值是2
    ratio = window.devicePixelRatio || 1,

    // 缩略图大小
    thumbnailWidth = 110 * ratio,
    thumbnailHeight = 110 * ratio;

$(function () {

    initUploader();

    //添加表单验证
    validReconsiderForm();

    loadLayerPphotos();
});


function reconsiderAction(type) {

    if (validator && !(validator.form())) {
        return false;
    }

    //保存
    if (type == 1) {
        $("#form-reconsider").attr("action", "/Reconsider/Save");
    }
    else {
        $("#form-reconsider").attr("action", "/Reconsider/Submit");
    }

    new Alert().AlertInfo({
        content: "确认操作?",
        iClass: "yes",
        callBack: function () {
            layer.load();
            $("#form-reconsider").ajaxSubmit({
                success: postSuccess
            });
        }
    });
}

function postSuccess(response, status) {

    if (response.ReturnType) {
        var files = uploader.getFiles();
        if (files.length > 0) {
            $('input[name="ReconsiderId"]').val(response.ReturnData.Id);
            uploader.upload();
        } else {
            alertComplete(response);
        }
       // window.location = "/OverdueCustomer/CarOverdueList?css=1056"
    }
    else {
        alertComplete(response);
    }
}


//初始化WebUploader
function initUploader() {
    // 实例化
    uploader = WebUploader.create({
        pick: {
            id: '#filePicker',
        },
        swf: '../../Scripts/WebUploader/Uploader.swf',

        server: '../File/UpFile',

        accept: {
            title: 'Images',
            extensions: 'gif,jpg,jpeg,bmp,png',
            mimeTypes: 'image/jpg,image/jpeg,image/png,image/gif,image/bmp'
        },

        fileVal: 'File',//设置文件上传域的name

        // 禁掉全局的拖拽功能。这样不会出现图片拖进页面的时候，把图片打开。
        disableGlobalDnd: true,
        fileNumLimit: 300,
        fileSizeLimit: 200 * 1024 * 1024,    // 200 M
        fileSingleSizeLimit: 50 * 1024 * 1024    // 50 M
    });

    uploader.onFileQueued = function (file) {

        fileCount++;
        fileSize += file.size;

        if (fileCount === 1) {
            $statusBar.show();
        }
        addFile(file);
        updateStatus();
    };

    uploader.onFileDequeued = function (file) {
        fileCount--;
        fileSize -= file.size;
        removeFile(file);
        updateStatus();
    };

    uploader.on('uploadFinished', function () {
        new Alert().AlertInfo({
            title:"",
            iClass: 'yes' ,
            btnCount: 1,
            content: '编辑展期复议信息成功',
            callBack: function () {
                layer.closeAll();
                window.close();
                window.location = "/OverdueCustomer/CarOverdueList?css=1056";
            }
        });
    });

    uploader.on('uploadBeforeSend', function (obj, data, headers) {
        data.Key = $('input[name="ReconsiderId"]').val();
        data.PhotoType = 17;
    });
}

// 当有文件添加进来时执行，负责view的创建
function addFile(file) {
    var $li = $('<li id="' + file.id + '">' +
            '<p class="title">' + file.name + '</p>' +
            '<p class="imgWrap"></p>' +
            '<p class="progress"><span></span></p>' +
            '</li>'),
        $btns = $('<div class="file-panel">' +
                    '<span class="cancel">删除</span>'
                    + '</div>').appendTo($li),

        $prgress = $li.find('p.progress span'),
        $wrap = $li.find('p.imgWrap');
    var img = '<img alt="' + file.name + '" src="';
    uploader.makeThumb(file, function (error, src) {
        img += src;
        uploader.makeThumb(file, function (error, src) {
            img += '" layer-src="' + src + '"/> ';
            $wrap.empty().append($(img));
        }, 1, 1);
    }, thumbnailWidth, thumbnailHeight);

    var photo = {};


    $li.on('mouseenter', function () {
        $btns.stop().animate({ height: 30 });
    });

    $li.on('mouseleave', function () {
        $btns.stop().animate({ height: 0 });
    });

    $btns.on('click', 'span', function () {
        var index = $(this).index(),
            deg;

        switch (index) {
            case 0:
                uploader.removeFile(file);
                return;
        }
    });

    $li.insertBefore($('#filePicker'));

}

// 负责view的销毁
function removeFile(file) {
    var $li = $('#' + file.id);
    $li.off().find('.file-panel').off().end().remove();
}

//更新文本状态
function updateStatus() {
    var text = '';
    text = '选中' + fileCount + '张图片，共' +
            WebUploader.formatSize(fileSize) + '。';
    $info.html(text);
}

//载入LayerUI.Photos
function loadLayerPphotos() {
    layer.photos({
        photos: '.filelist',
        anim: 0
    });
}

//弹框提醒操作结果
function alertComplete(response) {
    new Alert().AlertInfo({
       // isIcon: false,
        title: "",
        iClass: response.ReturnType ? 'yes' : 'error',
        //iClass:'yes',
        btnCount: 1,
        content: response.ReturnMsg,
        callBack: function () {
            layer.closeAll();
            if (response.ReturnType) {
                window.close();
                window.location = "/OverdueCustomer/CarOverdueList?css=1056";

            }
        }
    });
}

//表单验证
function validReconsiderForm() {
    validator = $("#form-reconsider").validate({
        rules: {
            StoreOption: "required"
        },
        messages: {
            StoreOption: "请输入展期复议意见"
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.parent());
        },
        errorElement: 'span',
        errorClass: "bug"
    });
}


