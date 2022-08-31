				/************************
					Flot Charts
				*************************/

				$.plot($(".chart"), data1, {
					xaxis: {
						min: (new Date(2009, 11, 18)).getTime(),
						max: (new Date(2010, 11, 15)).getTime(),
						mode: "time",
						tickSize: [1, "month"],
						monthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
						// tickLength: 0, // to remove border
						axisLabelUseCanvas: true,
						axisLabelFontSizePixels: 11,
						axisLabelFontFamily: 'Verdana, Arial, Helvetica, Tahoma, sans-serif',
						axisLabelPadding: 5
					},
					yaxis: {
						axisLabelUseCanvas: true,
						axisLabelFontSizePixels: 11,
						axisLabelFontFamily: 'Verdana, Arial, Helvetica, Tahoma, sans-serif',
						axisLabelPadding: 5
					},
					series: {
						lines: { show: true },
						points: {
							radius: 3,
							show: true,
							fill: true
						},
					},
					grid: {
						hoverable: true,
						borderWidth: 1,
						borderColor: '#d5d5d5'
					},
					legend: {
						labelBoxBorderColor: "none",
						noColumns: 4,
						position: "left"
					}
				});
			 
				function showTooltip(x, y, contents, z) {
					$('<div id="tooltip">' + contents + '</div>').css({
						position: 'absolute',
						display: 'none',
						top: y + 5,
						left: x + 5,
						'z-index': '9999',
						'color': '#fff',
						'font-size': '11px',
						opacity: 0.8,
						'border-color': z,
					}).appendTo("body").fadeIn(200);
				}
			 
				function getMonthName(numericMonth) {
					var monthArray = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
					var alphaMonth = monthArray[numericMonth];
			 
					return alphaMonth;
				}
			 
				function convertToDate(timestamp) {
					var newDate = new Date(timestamp);
					var dateString = newDate.getMonth();
					var monthName = getMonthName(dateString);
			 
					return monthName;
				}
			 
				var previousPoint = null;
			 
				$(".chart").bind("plothover", function (event, pos, item) {
					if (item) {
						if ((previousPoint != item.dataIndex) || (previousLabel != item.series.label)) {
							previousPoint = item.dataIndex;
							previousLabel = item.series.label;
			 
							$("#tooltip").remove();
			 
							var x = convertToDate(item.datapoint[0]),
							y = item.datapoint[1];
							z = item.series.color;
			 
							showTooltip(item.pageX, item.pageY,
								"<b>" + item.series.label + "</b><br /> " + x + " = " + y + "",
								z);
						}
					} else {
						$("#tooltip").remove();
						previousPoint = null;
					}
				});
