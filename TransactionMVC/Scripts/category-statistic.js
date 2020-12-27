$().ready(function () {
    initAutocomplete();
});

function renderChart() {
    var categoryId = document.querySelector('#autocomplete-report').getAttribute('category-id');
    var ctx = document.getElementById('chartReport').getContext('2d');
    var week = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];
    var response = $.getJSON(`/Statistic/GetNumberOfTransactionsByDay?categoryId=${(categoryId)}`, function (json) {
        return json
    }).done(function () {
        var data = response.responseJSON.result;
        var myChart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: week,
                datasets: [{
                    label: '# of Transactions',
                    data: data,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)',
                        'rgba(255, 54, 235, 0.2)',
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    });
}

function initAutocomplete() {
    $('#autocomplete-report').autocomplete({
        serviceUrl: `Statistic/AutoCompleteSuggestion`.replace("&", "?"),
        onSelect: function () {
            if (document.querySelector('#autocomplete-report').value.length != 0) {
                var response = $.getJSON(`/Statistic/AutoCompleteSuggestion?query=${document.querySelector('#autocomplete-report').value}`, function (json) {
                    return json
                }).done(function () {
                    response.responseJSON;
                    if (response.responseJSON.suggestions.length == 1) {
                        var id = response.responseJSON.suggestions[0].data;
                        document.querySelector('#autocomplete-report').setAttribute('category-id', id);
                    }
                });
            }
        }
    });
}