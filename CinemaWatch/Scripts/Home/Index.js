//JS to get Movies by genre on home/index

(function () {
    //why use strict?
    "use strict";

    //console.log("Before the error");

    //console.log(undefThing);

    //important: using var here would cause undefThing to be defined first due to "hoisting"
    //var undefThing = {};
    //undefThing.msg = "wrong";

    //console.log(undefThing);
    //alert("Its working!");

    //playground.js

    $(document).ready(function GetMoviesByGenre () {
        $.get("/api/Movies/MoviesByGenre", {}, function (data) {
            console.log(data);

            let categories = data.map(x => x.Name);
            let series = data.map(function (element) {
                return element.Count;
            });

            console.log(categories);
            console.log(series);
        });
    });

    // end playground.js
})();

Highcharts.chart('container', {
    ajax: {
        url: "/api/movies",
        dataSrc: ""
    },
    chart: {
        type: 'column'
    },
    title: {
        text: 'Movies in Genre'
    },
    xAxis: {
        categories: [
            'Action',
            'Thriller',
            'Family',
            'Romance',
            'Comedy',
            'Sci-Fi',
        ],
        crosshair: true
    },

    yAxis: {
        min: 0,
        title: {
            text: 'Number of Movies'
        }
    },
    tooltip: {
        headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
        pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
            '<td style="padding:0"><b>{point.y:.1f} movies</b></td></tr>',
        footerFormat: '</table>',
        shared: true,
        useHTML: true
    },
    plotOptions: {
        column: {
            pointPadding: 0.2,
            borderWidth: 0
        }
    },
    series: [{
            name: 'Action',
            data: [6]
        },
        {
            name: 'Thriller',
            data: [2]

        },
        {
            name: 'Family',
            data: [3]

        },
        {
            name: 'Romance',
            data: [2]

        },
        {
            name: 'Comedy',
            data: [4]

        },
        {
            name: 'Sci-Fi',
            data: [9]

        },
    ]
});