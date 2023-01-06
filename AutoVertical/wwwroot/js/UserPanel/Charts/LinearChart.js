class LinearChart{
    constructor(ChartDetails){
        this.canvasId = ChartDetails.elementId
        this.data = {
            labels: ChartDetails.labels,
            datasets: [{
              label: ChartDetails.name,
              data: ChartDetails.data,
              fill: true,
              borderColor: ChartDetails.borderColor,
              tension: 0.1
            }]
          };
    }
    Show(){
        new Chart(this.canvasId, {
            type: 'line',
            data: this.data,
          });
    }
    Destroy()
    {
      console.log("test")
      this.Clear()
    }
}