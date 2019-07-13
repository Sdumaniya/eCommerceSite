if (!$ && jQuery) {
    $ = jQuery;
}

function loadProducts() {

    $(document).ready(function () {

        var table = $("#tblProducts").DataTable({
            ajax: {
                url: "http://localhost:59341/api/Product",
                dataSrc: "",
            },
            columns: [
                { data: "ProductId" },
                { data: "ProdName" },
                { data: "ProdDescription" },
                { data: "BtnUpdate" },
                { data: "BtnDelete" }
            ],
            columnDefs: [
                {
                    targets: 3,
                    data: "BtnUpdate",
                    defaultContent: "<button class='btn btn-info'>Update</button>"
                },
                {
                    targets: 4,
                    data: "BtnDelete",
                    defaultContent: "<button class='btn btn-danger'>Delete</button>"
                }],
            paging: true
        });

        $("#tblProducts tbody").on('click', 'button', function () {
            var row = table.row($(this).parents('tr')), data = row.data();

            if ($(this).text() == "Delete") {
                if (confirm("Do you want to delete this row?")) {
                    $.ajax({
                        method: "DELETE",
                        url: "http://localhost:59341/api/Product/" + data.ProductId,
                    }).then(function () {
                        row.remove().draw();
                    }, function () {
                        alert("something went wrong.");
                    });
                }
            } else {
                window.location = '/Product/UpdateProduct/' + data.ProductId;
            }
        });
    });

}

