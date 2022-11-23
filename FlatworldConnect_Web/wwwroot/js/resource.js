var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Resource/GetAll"
        },
        "columns": [
            { "data": "customer.customerName", "width": "14%" },
            { "data": "jobTitle", "width": "14%" },
            { "data": "skillSet", "width": "14%" },
            { "data": "experience", "width": "14%" },
            { "data": "noOfMonths", "width": "14%" },
            { "data": "startDate", "width": "14%" },
            { "data": "endDate", "width": "14%" },
            { "data": "noOfResources", "width": "14%" },
            {
                "data": "resourceId",
                "render": function (data) {
                    return `
                         <div class="w-75 btn-group" role="group">
                            <a href="/Admin/Resource/Upsert?id=${data}" 
                            class="btn btn-primary mx-2"><i class="bi bi-pencil"></i>Edit</a>
                            <a onClick=Delete('/Admin/Resource/Delete/${data}')
                            class="btn btn-danger mx-2"><i class="bi bi-x-lg"></i>Delete</a>
                            

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