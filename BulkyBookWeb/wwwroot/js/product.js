let datatable;

$(document).ready(function () {
    loadDatatable();
});

function loadDatatable() {
    datatable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            {"data": "title", "width": "15%"},
            {"data": "isbn", "width": "15%"},
            {"data": "pricePerBook", "width": "15%"},
            {"data": "author", "width": "15%"},
            // {"data": "Title", "width": "15%"},
        ]
    });
}