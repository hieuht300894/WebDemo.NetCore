var click_Color = '#34acf3';
var odd_Color = '#f5f5f5';
var even_Color = '#fff';
var text_Color = '#fff';

function customTable() {
    contructerJQuery();

    var oTable = $('#datatable');

    oTable.dataTable({
        processing: true,
        paging: true,
        lengthChange: true,
        searching: true,
        ordering: true,
        info: true,
        autoWidth: true,
        language: {
            emptyTable: "Không có dữ liệu",
            info: "Tìm thấy từ _START_ đến _END_ trong _TOTAL_ trang",
            infoEmpty: "Tìm thấy từ 0 đến 0 trong 0 trang",
            infoFiltered: "(Tìm thấy _MAX_ kết quả)",
            infoPostFix: "",
            lengthMenu: "Hiển thị _MENU_ kết quả",
            loadingRecords: "Đang tải...",
            processing: "Đang xử lý...",
            search: "Tìm kiếm",
            zeroRecords: "Không tìm thấy kết quả",
            paginate: {
                first: "Đầu",
                previous: "Trước",
                next: "Tiếp theo",
                last: "Cuối"
            },
            aria: {
                sortAscending: ": Sắp xếp tăng dần",
                sortDescending: ": Sắp xếp giảm dần"
            },
            decimal: "",
            thousands: ","
        }
    });
    //visibleColumn(colIndexs, colLength);
    formatRow();
}

function visibleColumn(colIndexs, length) {
    contructerJQuery();

    var oTable = $('#datatable').dataTable();
    for (var i = length - 1; i >= 0; i--) {
        oTable.fnSetColumnVis(colIndexs[i], false);
    }
}

function formatRow() {
    contructerJQuery();
    var row = $('#datatable tbody').find('tr');
    if ($(row).filter('.selected').index() == -1) {
        $(row[0]).addClass('selected');
        $(row[0]).attr('style', 'background-color:' + click_Color + ";color:" + text_Color);
    }

    $('#datatable tbody').on('click', 'tr', function () {
        $('#datatable tbody').find('tr').removeAttr('style');
        $('#datatable tbody').find('tr.selected').removeClass('selected');
        $(this).addClass('selected');
        $(this).attr('style', 'background-color:' + click_Color + ";color:" + text_Color);
    });
}