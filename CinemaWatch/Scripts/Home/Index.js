//JS to get Movies by genre on home/index

(function () {

    "use strict";
    function GetMoviesByGenre() {
        $.get("/api/Movies/MoviesByGenre", {}, function (data) {
            console.log(data);

            let categories = data.map(x => x.Name);
            let series = data.map(function (element) {
                return element.Count;
            });

            //let chartData = data.map(function (element) {
            //    return {
            //        data: [element.Count],
            //        name: element.Name
            //    };
            //});

            let chartData = { categories: categories, series: series };

            console.log(chartData);            

            buildMoviesGenreChart(chartData);
        });
    }

    function buildMoviesGenreChart(chartData) {
        // build the chart here

        const series = [
            {
                name: "Number of Movies",
                data: chartData.series
            }
        ];

        Highcharts.chart('container', {
            chart: {
                type: 'bar'
            },
            title: {
                text: 'Movies in Genre'
            },
            xAxis: {
                categories: chartData.categories,
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
                    '<td style="padding:0"><b>{point.y} movies</b></td></tr>',
                footerFormat: '</table>',
                shared: true,
                useHTML: true
            },
            plotOptions: {
                column: {
                    pointPadding: 0.2,
                    borderWidth: 0
                },
                bar: {
                    colorByPoint: true,
                    dataLabels: {
                        enabled: false,
                        style: {
                            width: "100px",
                            fontSize: "16px"
                        }
                    },
                    showInLegend: false
                }
            },

            series: series
        });
    }

    function GetMoviesByYear() {
        $.get("/api/Movies/MoviesByYear", {}, function (data) {
            console.log(data);

            //let categories = data.map(x => x.Name);
            //console.log(categories);
            //let series = data.map(function (element) {

            //    return element.ReleaseDate;
            //});
            //console.log(series);

            let chartData = {
                name: "Number of Movies Released",
                data: data.map(function (data) {
                    return [data.ReleaseDate, data.Count];
                })
            };

            console.log(chartData);

            buildMoviesByYearChart(chartData);

        });
    }

    function buildMoviesByYearChart(chartData) {

        const series = [
            {
                name: "Movies by Release Date",
                data: chartData.data
            }
        ];
        console.log(series);

        Highcharts.chart('line-container', {

            title: {
                text: 'Movies by Release Date'
            },

            yAxis: {
                title: {
                    text: 'Number of Movies'
                },

            },

            xAxis: {

                title: {
                    text: 'Years'
                },
                crosshair: true,
            },

            legend: {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle'
            },

            plotOptions: {
                series: {
                    label: {
                        connectorAllowed: false
                    },
                    pointStart: 1975
                }
            },

            series: series,

            responsive: {
                rules: [{
                    condition: {
                        maxWidth: 600
                    },
                    chartOptions: {
                        legend: {
                            layout: 'horizontal',
                            align: 'center',
                            verticalAlign: 'bottom'
                        }
                    }
                }]
            }

        });
    }

    $(document).ready(function () {
        GetMoviesByGenre();
        GetMoviesByYear()
    });

    //$('#liveSelect').click(function () {
    //    var chart = $('#live-container').highcharts();
    //    chart.yAxis[0].update({
    //        tickInterval: $('#liveSelect').val()
    //    });
    //});

    Highcharts.chart('live-container', {
        chart: {
            type: 'spline',
            animation: Highcharts.svg, // don't animate in old IE
            marginRight: 10,
            events: {
                load: function () {

                    // set up the updating of the chart each second
                    var series = this.series[0];
                    setInterval(function () {
                        var x = (new Date()).getTime(), // current time
                            y = Math.floor((Math.random() * 40) + 1);
                        series.addPoint([x, y], true, true);
                    }, 1000);
                }
            }
        },

        time: {
            useUTC: false
        },

        title: {
            text: 'Live Data'
        },

        accessibility: {
            announceNewData: {
                enabled: true,
                minAnnounceInterval: 15000,
                announcementFormatter: function (allSeries, newSeries, newPoint) {
                    if (newPoint) {
                        return 'New point added. Value: ' + newPoint.y;
                    }
                    return false;
                }
            }
        },

        xAxis: {
            type: 'datetime',
            tickPixelInterval: 150
        },

        yAxis: {
            min: 0,
            tickInterval: .5,
            title: {
                text: 'Value'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },

        tooltip: {
            headerFormat: '<b>{series.name}</b><br/>',
            pointFormat: '{point.x:%Y-%m-%d %H:%M:%S}<br/>{point.y:.2f}'
        },

        legend: {
            enabled: false
        },

        exporting: {
            enabled: false
        },

        series: [{
            name: 'Random data',
            data: (function () {
                // generate an array of random data
                var data = [],
                    time = (new Date()).getTime(),
                    i;

                for (i = -19; i <= 0; i += 1) {
                    data.push({
                        x: time + i * 1000,
                        y: Math.floor((Math.random() * 40) + 1)
                    });
                }
                return data;
            }())
        }]
    });

    $('#liveSelectBtn').click(function () {
        var chart = $('#live-container').highcharts();
        chart.yAxis[0].update({
            tickInterval: $('#liveSelect').val()
        });
    })

    // end playground.js
})();

