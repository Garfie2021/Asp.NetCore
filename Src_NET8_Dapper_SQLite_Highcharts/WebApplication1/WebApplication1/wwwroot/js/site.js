// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function renderChart(containerId, chartData, regimes) {
    Highcharts.chart(containerId, {
        chart: {
            type: 'line'
        },
        title: {
            text: '日経平均株価と内閣',
            align: 'left'
        },
        xAxis: {
            type: 'datetime',
            labels: {
                format: '{value:%Y}年' // x軸のラベルをyyyy/MM/dd形式に設定
            }
        },
        yAxis: {
            title: {
                text: ''
            },
            labels: {
                formatter: function () {
                    return this.value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '円'; // 3桁ごとにカンマを入れる
                }
            }
        },
        tooltip: {
            xDateFormat: '%Y/%m', // ツールチップの日付フォーマットをyyyy/MM形式に設定
            valueSuffix: ' 円' // 金額の後ろに「円」を追加
        },
        series: [{
            name: '日経平均株価',
            data: chartData // 渡されたデータを使用
        }],
        annotations: regimes.map(r => ({
            labels: [{
                point: {
                    x: r.x,
                    y: chartData.find(d => d.x >= r.x)?.y || chartData[0].y, // 発足日付付近のy値を取得
                    xAxis: 0,
                    yAxis: 0
                },
                text: r.text
            }],
            labelOptions: {
                backgroundColor: 'rgba(255,255,255,0.5)',
                borderColor: 'black'
            }
        }))
    });
}
