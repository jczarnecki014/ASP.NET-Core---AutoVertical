class PolarAreaChart{
    constructor(ChartDetails){
        this.canvasId = ChartDetails.elementId
        this.data = {
            labels: ChartDetails.labels,
            datasets: [{
              label: ChartDetails.name,
              data: ChartDetails.data,
              backgroundColor: ChartDetails.backgroundColor,
              tension: 0.1
            }]
          };
    }
    Show(){
        new Chart(this.canvasId, {
            type: 'polarArea',
            data: this.data,
            options: {}
          });
    }
}




