/*
鼠标滚动加载数据
url：数据请求地址
objId:输出的位置编号
otherJson:其他参数

Create User：ZG
Date：20150327
*/
var page = 2;
var c = 1;
jQuery.MouseRolling = function (url, objId, otherJson) {
    var p;
    var r;
    if (c != 1) {
        return false;
    }
    jQuery.each(otherJson, function (k, v) {
        switch (v.name) {
            case 'page':
                r = v.pageData.row
                break;
        }
    });
    LoadData(url, objId, r);
    c++;
};

function LoadData(url, objId, row) {
    var p = 0;
    var t = 0;
    jQuery(window).scroll(function () {
        var docHeight = jQuery(document).height();
        var winHeight = t = jQuery(window).height();
        if (p <= t) {
            var scTop = jQuery(document).scrollTop();
            if (scTop >= (docHeight - winHeight)) {
                jQuery.ajax({
                    type: "get",
                    data: { pageNum: page, pageRowCount: row },
                    url: url,
                    success: function (data) {
                        if (data != null) {
                            page++;
                        }
                        if (data != null) {
                            var json = eval('(' + data + ')');
                            var html = "";
                            jQuery.each(json.data, function (key, val) {
                                html += "<div style='margin-left:5px;'>";
                                html += '<div style="width:100%;display:inline-block"><div class="pull-left"> <img data-id="logo" src="' + val.Img + '" /></div>';
                                html += '<div class="pull-left"><div><div> <a href="#" class="MainContenLink">' + val.UserName + '</a><span style="color:#808080">ID：4943241920</span><span style="color:#808080">1小时</span>';
                                html += '</div><div> <span>' + val.C_Content + '</span></div></div></div>';
                                html += '<div><div name="comments"><textarea class="form-control" placeholder="写入你的评论"></textarea></div><div><a href="#"><span class="glyphicon glyphicon-camera Icon"></span></a><button class="btn btn-primary pull-right" style="margin-right:10px;">发布</button></div></div>';
                                html += "</div></div>";
                            });
                        }
                        jQuery('#' + objId).append(html);

                    },
                    error: function (data) {
                        alert(data.error)
                    }
                });
            }
        }
        p = t;
    });
};