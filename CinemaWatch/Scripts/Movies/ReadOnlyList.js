$(document).ready(function () {
    var table = $("#movies").DataTable({
        ajax: {
            url: "/api/movies",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
            },
            {
                data: "numberInStock"
            },
            {
                data: "genre.name"
            },
            {
                data: "releaseDate",
                render: function (data) {
                    var date = new Date(data).toLocaleDateString();
                    return date;
                }
            }
        ]
    });
});