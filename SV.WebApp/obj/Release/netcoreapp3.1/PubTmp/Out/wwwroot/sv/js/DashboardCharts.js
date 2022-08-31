
$(function () {

	var newId = 'mychart-' + questionId;
	$('#chart').attr('id', newId);

	var ctx = document.getElementById(newId).getContext('2d');

	var labels = Object.getOwnPropertyNames(keyValuePair);
	var data = Object.values(keyValuePair);
	var typeOfChart = '';

    

	var dataSetObj = {
		label: questionType + ' chart',
		data: data,
		responsive: true,
		fill: false,
		borderColor: GetRandomColor(), // 'rgb(75, 192, 192)',
		tension: 0.1,
		backgroundColor: []
		
	};

	

	if (chartType == 1) {

		typeOfChart = 'bar';
	}
	else if (chartType == 2) {

		typeOfChart = 'pie';
	}
	else if (chartType == 3) {

		typeOfChart = 'line';
	}

    if (chartType == 1 || chartType == 2) {

		for (var i = 0; i < labels.length; i++) {
			dataSetObj.backgroundColor.push(GetRandomColor());
		}
    }

	//dataSetObj.backgroundColor = [
		//	'rgb(255, 99, 132)',
		//	'rgb(54, 162, 235)',
		//	'rgb(255, 200, 21)',
		//	'rgb(113, 46, 141)',
		//	'rgb(58, 135, 173)',
		//	'rgb(255, 0, 0)',
		//	'rgb(137, 99, 36)',
		//	'rgb(103, 76, 71)',
		//	'rgb(116, 40, 2)',
		//	'rgb(92, 83, 55)',
		//	'rgb(152, 85, 56)',
		//	'rgb(54, 55, 55)',
		//	'rgb(64, 72, 84)',
		//	'rgb(208, 255, 20)',
		//	'rgb(140, 255, 158)'
		//]

	var myBarChart = new Chart(ctx, {
		type: typeOfChart,
		data: {
			labels: labels,
			datasets: [dataSetObj]
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

function GetRandomColor() {
	var letters = '0123456789ABCDEF';
	var color = '#';
	for (var i = 0; i < 6; i++) {
		color += letters[Math.floor(Math.random() * 16)];
	}
	return color;
}

