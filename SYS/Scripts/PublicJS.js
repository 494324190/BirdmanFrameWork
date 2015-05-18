var next_Page = 1;
//n_Or_u:是下一页还是上一页
//n:下一页   u：上一页
//columnsJson:表格配置json
//url刷新数据的地址
//下一页或者上一页页码
function nextPage(n_Or_u, columnsJson, url, nPage) {
    
    next_Page = nPage;
    //上一页下一页
    if (n_Or_u == "n") {
        next_Page++;
    } else if (n_Or_u == "u" && next_Page != 1) {
        next_Page--;
    }
    var pageCount = columnsJson.pageCount;
    var page=columnsJson.page;
    columnsJson = JSON.stringify(columnsJson);
    //如果是第一页的话“上一页”不可用
    if (next_Page == 1) {
        $('span[data-name="' + page + 'Page_u"]').addClass('disable');
        $('span[data-name="' + page + 'Page_u"]>a').attr('onclick', '');
    } else {
        $('span[data-name="' + page + 'Page_u"]>a').attr('onclick', 'nextPage("u", ' + columnsJson + ',"' + url + '",' + next_Page + ')');
        $('span[data-name="' + page + 'Page_u"]').removeClass('disable');
    }
    //判断是否是最后一页
    if (pageCount == next_Page) {
        $('span[data-name="' + page + 'Page_n"]').addClass('disable');
        $('span[data-name="' + page + 'Page_n"]>a').attr('onclick', '');
    } else {
        $('span[data-name="' + page + 'Page_n"]>a').attr('onclick', 'nextPage("n", ' + columnsJson + ',"' + url + '",' + next_Page + ')');
        $('span[data-name="' + page + 'Page_n"]').removeClass('disable');
    }



    refurbish(columnsJson, url);
}
//刷新数据
//columnsJson:表格配置json
//url提交/请求数据的地址
function refurbish(columnsJson, url) {
    columnsJson = eval('(' + columnsJson + ')');
    $.ajax({
        type: "get",
        data: { nextPage: next_Page, pageRowCount: columnsJson.pageRowCount },
        cache: false,
        url: url,
        success: function (data) {
            var page=columnsJson.page;
            var json = eval('(' + data + ')');
            var ele = "";
            var num = json.page;
            var rowCount = json.rowCount;
            //创建表头

            $.each(columnsJson.columns, function (i, n) {
                if (i == 0) {
                    ele = ele + "<thead><tr><th style='width:" + columnsJson.columns[i].width + "'>#</th>";
                }
                if (columnsJson.columns[i].columnSYS != 'true') {
                    ele = ele + "<th style='width:" + columnsJson.columns[i].width + "'>" + columnsJson.columns[i].columnsName + "</th>";
                }
                if (i == columnsJson.columns.length - 1) {
                    ele = ele + "<th style='width:" + columnsJson.columns[i].width + "'>操作</th>";
                }

            });
            ele = ele + "</tr></thead><tbody>";
            //创建表格内容
            if (json.data != "") {
                $.each(json.data, function (i, item) {

                    ele = ele + "<tr><td>" + ((rowCount * (num - 1)) + i + 1) + "</td>";

                    $.each(columnsJson.columns, function (j, n) {
                        if (columnsJson.columns[j].columnSYS != 'true') {

                            ele = ele + "<td>" + json.data[i][columnsJson.columns[j].field] + "</td>";
                        }
                    });
                    ele = ele + "<td><a data-name='delete' href='javascript:void(0)' data-value='" + item.ID + "'>" +
                     "<i class='fa fa-minus' style='color:rgba(254, 108, 96, 1);' title='删除'></i>" +
                      "</a>" +
                      "&nbsp;/&nbsp;" +
                      "<a data-name='edit' href='javascript:void(0)' data-value='" + item.ID + "'>" +
                      "<i class='fa fa-pencil-square-o' style='color:rgba(66, 139, 202, 1);' title='修改'></i>" +
                      "</a>" +
                       "</td></tr>";
                });
            }
            else {
                ele = ele + '<tr>' +
                            '<td colspan="4" class="text-center">' +
                                '<lable>暂无数据</lable>' +
                            '</td>' +
                        '</tr>';
            }
            ele = ele + "</tbody></table>";
            $('#' + columnsJson.table).html(ele);
            $("[data-name='delete']").bind('click', function () {
                del(this, columnsJson)
            });
            $("[data-name='edit']").bind('click', function () {
                edit(this, columnsJson);
            });
        },
        error: function (data) {
            alert(data.error)
        }
    });
}
//增加一行填写数据
//columnsJson:表格配置json
function addInput(columnsJson) {
    var ele = "<tr>";
    var promptBox = columnsJson.promptBox;
    $.each(columnsJson.columns, function (i, n) {
        var operate = columnsJson.columns[i].operate == undefined ? "" : columnsJson.columns[i].operate;
        var field = columnsJson.columns[i].field;
        var inputType = columnsJson.columns[i].inputType;
        var columnsName = columnsJson.columns[i].columnsName;
        var SaveID = columnsJson.Btn;
        //是否是系统自动生成列
        if (columnsJson.columns[i].columnSYS == 'true' && operate != "") {
            ele = ele + sysColumn(columnsJson.columns[i].columnType, "", operate, SaveID);
        } else if (inputType != undefined && inputType != "") {
            ele = ele + "<td><input data-name='input' name='" + field + "' type='" + inputType + "' placeholder='" + columnsName + "' class='form-control'/></td>";
        }
        else {
            ele = ele + "<td></td>"
        }
    });
    ele = ele + "</tr>";
    if ($("[data-name='input']").length <= 0) {
        if ($('#' + columnsJson.table + ' > tbody > tr > td').attr('colspan') == undefined) {
            $(ele).insertAfter('#' + columnsJson.table + ' > tbody > tr:last');
        } else {
            $('#' + columnsJson.table + ' > tbody > tr').remove();
            $('#' + columnsJson.table + ' > tbody ').html(ele);
        }
        save(columnsJson.SaveUrl, columnsJson.refurbishUrl, columnsJson.PostForm, columnsJson)
    } else {
        $('#' + promptBox).show("slow", function () {
            window.setTimeout(function () { $('#' + promptBox).hide("slow"); }, 5000);
        });
    }
}

//保存
//postUrl:提交的URL路径
//refurbishUrl:提交成功后刷新的URL路径
//formID:提交的form ID
//columnsJsonType:column配置文件
function save(postUrl, refurbishUrl, formID, columnsJsonType) {
    $('#' + columnsJsonType.Btn).bind('click', function () {
        $.ajax({
            type: "post",
            data: $('#' + formID).serialize(),
            url: postUrl,
            success: function (data) {
                if (data == 1) {
                    nextPage("", columnsJsonType, refurbishUrl,1);
                } else if (data == 0) {
                    $('[data-name="input"]').addClass("input_error");
                } else {
                    $('[data-name="input"]').addClass("input_error");
                    $('[data-name="input"]').val("");
                    $('[data-name="input"]').attr("placeholder", "内容已存在");

                }
            },
            error: function (data) {
                alert(data.error)
            }
        })
    });
}

//删除
function del(obj, columnsJsonType) {
    var id = $(obj).attr("data-value");
    $.ajax({
        type: "post",
        data: { removeId: id },
        url: columnsJsonType.DeleteUrl,
        success: function (data) {
            if (data != 0) {
                nextPage("", columnsJsonType, columnsJsonType.refurbishUrl,1);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(XMLHttpRequest.status);
        }
    });
}

//修改
function edit(obj, columnsJson) {
    if ($("[data-name='input']").length > 0) {
        $('#' + columnsJson.promptBox).show("slow", function () {
            window.setTimeout(function () { $('#' + columnsJson.promptBox).hide("slow"); }, 5000);
        })
        return;
    }
    var ele = "";
    $.each(columnsJson.columns, function (i, n) {
        var operate = columnsJson.columns[i].operate == undefined ? "" : columnsJson.columns[i].operate;
        var field = columnsJson.columns[i].field;
        var inputType = columnsJson.columns[i].inputType;
        var columnsName = columnsJson.columns[i].columnsName;
        var SaveID = columnsJson.Btn;
        var valType = "";
        var id
        if (columnsJson.columns[i].update == 'true') {
            valType = $(obj).parent().parent().children(":eq(" + i + ")").html();
            id = $(obj).attr("data-value");
            ele = ele + "<td><input data-name='input' name='" + field + "' type='" + inputType + "' placeholder='" + columnsName + "' class='form-control' value='" + valType + "'/>";
            ele = ele + "<input name='ID' type='hidden' value='" + id + "'/></td>"
        } else if (columnsJson.columns[i].columnSYS == 'true' && operate != "") {
            ele = ele + sysColumn(columnsJson.columns[i].columnType, "", operate, SaveID);
        } else {
            ele = ele + "<td></td>"
        }
    });
    ele = ele + "";
    $(obj).parent().parent().html(ele);
    save(columnsJson.EditUrl, columnsJson.refurbishUrl, columnsJson.PostForm, columnsJson)

}
//系统列，返回生成好的系统列
//ColumnType:列类型
//Str:列内容（可为空）
//OperateType:操作类型（如果是“operate”类型的列可为空）
//BtnID:自定义Button ID
function sysColumn(ColumnType, Str, OperateType, BnID) {
    var ele = "";
    switch (ColumnType) {
        case "identifier"://如果是编号类型的列
            if (Str == "") {
                ele = "<td>#</td>";
            } else {
                ele = "<td>" + Str + "</td>";
            }
        case "operate"://如果是操作类型的列
            if (OperateType == "S") {//保存操作
                ele = "<td><button class='btn btn-info' type='button' id='" + BnID + "'>保存</button></td>";
            }
            else if (OperateType == "SD") {//删改操作

            }
        default:
            break;
    }
    return ele;
}