var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Vendor/Project/GetAll"
        },
        "columns": [
            { "data": "projectName", "width": "14%" },
            { "data": "projectDesc", "width": "14%" },
            { "data": "projectStartDate", "width": "14%" },
            { "data": "projectEndDate", "width": "14%" },
            { "data": "customer.customerName", "width": "14%" },
            { "data": "pm.pmName", "width": "14%" },
            {
                "data": "projectId",
                "render": function (data) {
                    return `
                         <div class="w-100 btn-group" role="group">
                            
                            <a href="/Vendor/Project/Details/${data}"
                            class="btn btn-secondary mx-1"><i class="bi bi-info"></i>Details</a>

                    </div>
                    `
                },
                "width": "14%"
            }
            
        ]
    });
}
