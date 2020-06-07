$(document).ready(function () {
    var table = $("#customers").DataTable({
        //processing: true,
        //serverSide: false,
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>"
                }
            },
            {
                data: "birthdate",
                render: function (data) {
                    var date = new Date(data).toLocaleDateString();
                    return date;
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class='btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }

        ]
    });

    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);

        bootbox.confirm("Are you sure you want to delete this customer?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        //need to redraw to update datatable
                        //table.ajax.reload();
                        //When using datatables with AJAX, you can just call <tableVar>.ajax.reload()
                        // to essentially re-initialize your dataset with the freshly changed data
                        //This might not be desireable for huge datasets but takes any complexity
                        // of tracking changes out of the equation

                        //CAVEAT: Be careful with this. If you add anything manually to the table,
                        //reload() will wipe out those changes. Will need to save and re-add those rows
                        //after refresh.
                        table.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });
});