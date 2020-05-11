

const FillChart = function () {
    var chart = new CanvasJS.Chart("chartContainer", {
	animationEnabled: true,
	theme: "light2", // "light1", "light2", "dark1", "dark2"
	title: {
		text: "Values for deposits in months"
	},
	axisY: {
		title: "Values"
	},
	data: [{
		type: "column",
		dataPoints: @Html.Raw(ViewBag.DataPoints)
	}]
});
chart.render();
}