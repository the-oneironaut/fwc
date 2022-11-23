var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Project/GetAll"
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
                            <a href="/Admin/Project/Upsert?id=${data}" 
                            class="btn btn-primary mx-1"><i class="bi bi-pencil"></i>Edit</a>
                            <a href="/Admin/Project/Details/${data}"
                            class="btn btn-secondary mx-1"><i class="bi bi-info"></i>Details</a>
                            <a onClick=Delete('/Admin/Project/Delete/${data}')
                            class="btn btn-danger mx-1"><i class="bi bi-x-lg"></i>Delete</a>

                    </div>
                    `
                },
                "width": "14%"
            }
            
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}