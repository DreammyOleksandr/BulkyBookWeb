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
            {"data": "category.name", "width": "15%"},
            {
                "data": "id",
                "render": function (data){
                    return`
                    <div class="w-75 btn-group" role="group">
                    <a href="/Admin/Product/Upsert?id=${data}"
                     class="btn btn-primary mx-2 ">
                        <i class="bi bi-pencil"></i>EDIT</a>
                    <a class="btn btn-primary mx-2 ">
                        <i class="bi bi-trash"></i>DELETE</a>
                </div>
                    `  
                },
                "width": "15%"
            }, 
        ]
    });
}