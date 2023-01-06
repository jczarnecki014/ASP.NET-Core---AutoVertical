

const profileViewsCanvas = document.getElementById('profileViews');
let profileViewsChart = new PolarAreaChart({
    elementId: profileViewsCanvas,
    labels:["test1","test1","test1","test1","test1"],
    name: "Advert Views",
    data: [15,21,24,24,21],
    backgroundColor: [
        'rgb(255, 99, 132)',
        'rgb(75, 192, 192)',
        'rgb(255, 205, 86)',
        'rgb(201, 203, 207)',
        'rgb(54, 162, 235)'
      ]
});


profileViewsChart.Show();