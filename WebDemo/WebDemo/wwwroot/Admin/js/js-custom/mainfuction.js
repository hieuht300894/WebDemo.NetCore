var url = '/admin';
var url_Insert = '/themmoi';
var url_Update = '/capnhat';
var url_Delete = '/xoa';
var url_Refresh = '';
var msg_Insert = 'Thêm mới';
var msg_Update = 'Cập nhật';

function contructerJQuery() {
    $.noConflict(false);
    if ($ != undefined)
        jq = $;
    else
        $ = jq;
}

function _insert(e) {
    e.preventDefault();
    contructerJQuery();

    $.ajax({
        url: url + controller + url_Insert,
        dataType: 'html',
        type: 'GET',
        ContentType: 'application/html;charset=utf-8',
        success: function (result) {
            $('#popupModal').empty();
            $('#popupModal').html(result);
            $('#popupModal').find('.modal-title').text(msg_Insert);
        },
        error: function () {
            $('#popupModal').empty();
        }
    });

}

function _update(element, e) {
    e.preventDefault();
    contructerJQuery();

    var id = undefined;

    var fcus = $(element).closest('tr');
    if (fcus.prop('tagName') == undefined) {
        var row = $('#datatable tbody tr').filter('.selected');
        if ($(row).index() != -1) {
            id = row.find('input[name=keyid]').val();
        }
    }
    else {
        id = fcus.find('input[name=keyid]').val();
    }

    if (id == undefined) {
        $('#popupModal').empty();
    }
    else {
        $.ajax({
            url: url + controller + url_Update,
            data: {
                id: id
            },
            dataType: 'html',
            type: 'GET',
            ContentType: 'application/html;charset=utf-8',
            success: function (result) {
                $('#popupModal').empty();
                $('#popupModal').html(result);
                $('#popupModal').find('.modal-title').text(msg_Update);
            },
            error: function () {
                $('#popupModal').empty();
            }
        });
    }
}

function _delete(element, e) {
    contructerJQuery();

    var id = undefined;

    var fcus = $(element).closest('tr');
    if (fcus.prop('tagName') == undefined) {
        var row = $('#datatable tbody tr').filter('.selected');
        if ($(row).index() != -1) {
            id = row.find('input[name=keyid]').val();
        }
    }
    else {
        id = fcus.find('input[name=keyid]').val();
    }

    if (id == undefined) {
        $.confirm({
            title: '',
            content: 'Không tìm thấy dữ liệu',
            buttons: {
                cancel: {
                    text: 'Hủy bỏ',
                    action: function () {
                    }
                }
            }
        });
    }
    else {
        $.confirm({
            title: '',
            content: 'Xác nhận xóa dữ liệu?',
            buttons: {
                cancel: {
                    text: 'Hủy bỏ',
                    action: function () {
                    }
                },
                confirm: {
                    text: 'Xác nhận',
                    action: function () {
                        $.ajax({
                            url: url + controller + url_Delete,
                            data: { id: id },
                            dataType: 'html',
                            type: 'DELETE',
                            ContentType: 'application/html;charset=utf-8',
                            success: function (result) {
                                _reload($('#table_content'));
                            }
                        });
                    }
                }
            }
        });
    }
}

function _reload(element) {
    contructerJQuery();

    $.ajax({
        ContentType: 'application/html;charset=utf-8',
        url: url + controller + '/danhsach',
        dataType: 'html',
        type: 'GET',
        success: function (result) {
            element.empty();
            element.html(result);
            customTable();
        }
    });
}

function _refresh(e) {
    e.preventDefault();
    location.reload();
}

function _save(element, e, id) {
    e.preventDefault();
    contructerJQuery();

    var datas = $('.form-horizontal').find('input');
    var result = [];
    for (var i = 0; i < datas.length; i++) {
        var obj = {
            name: $(datas[i]).attr('name'),
            value: $(datas[i]).attr('value')
        };
        result.push(obj);
    }
    var jResult = {};
    $.each(result, function () {
        jResult[this.name] = this.value;
    });

    $.ajax({
        url: url + controller,
        data: JSON.stringify(jResult),
        dataType: 'JSON',
        type: id == 0 ? 'POST' : 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8'
        },
        success: function (result) {
            _reload($('#table_content'));
        }
    });
}

function _saveAndAdd(element, e, id) {
    e.preventDefault();
    contructerJQuery();

    var result = [];

    var txts = $('#frmEditor').find('input');
    for (var i = 0; i < txts.length; i++) {
        var obj = {
            name: $(txts[i]).attr('name'),
            value: $(txts[i]).val()
        };
        result.push(obj);
    }

    var cbbs = $('#frmEditor').find('select');
    for (var i = 0; i < cbbs.length; i++) {
        var obj = {
            name: $(cbbs[i]).attr('name'),
            value: $(cbbs[i]).val()
        };
        result.push(obj);
    }

    var jResult = {};
    $.each(result, function () {
        if (this.name != undefined)
            jResult[this.name] = this.value;
    });

    $.ajax({
        url: url + controller + (id == 0 ? url_Insert : url_Update),
        data: JSON.stringify(jResult),
        dataType: 'JSON',
        type: id == 0 ? 'POST' : 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json;charset=utf-8'
        },
        success: function (result) {
            var isValid = validation(result);
            if (isValid) {
                _reload($('#table_content'));
                _insert(event);
            }
        }
    });
}

function validation(result) {
    var isValid = true;
    var status = result.status;
    var obj = result.msg;
    var arr_ele = ['input', 'select'];

    $.each(obj, function (key, value) {
        for (var i = 0; i < arr_ele.length; i++) {
            var ele = $('.form-horizontal').find(arr_ele[i] + '[name=' + key + ']');
            $(ele.closest('.form-group')).removeClass('has-error');
            var lb_error = $(ele.closest('div')).find('span');
            lb_error.text('');

            if (value != '') {
                isValid = false;
                $(ele.closest('.form-group')).addClass('has-error');
                var lb_error = $(ele.closest('div')).find('span');
                lb_error.addClass('help-block');
                lb_error.text(value);

                ele.on('click', function () {
                    $(this.closest('.form-group')).removeClass('has-error');
                    var lb_error = $(this.closest('div')).find('span');
                    lb_error.removeClass('help-block');
                    lb_error.text('');
                    ele.off();
                });
            }
        }
    });
    return isValid;
}