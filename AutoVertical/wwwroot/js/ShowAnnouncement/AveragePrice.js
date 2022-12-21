const SetAveragePrice = (AveragePrice,vehiclePrice) =>{
    // console.log(vehiclePrice > AveragePrice && vehiclePrice < AveragePrice + (AveragePrice/4))
    const AveragePriceImg = document.querySelector("#AveragePriceImg");
    const AveragePriceStatus = document.querySelector("#AveragePriceStatus");
    const AveragePriceSpan = document.querySelector("#AveragePrice");
    if(vehiclePrice >= AveragePrice && vehiclePrice < AveragePrice + (AveragePrice/4) )
    {
        AveragePriceImg.src = `/image/PriceEstimateIcons/normalPrice.jpg`;
        AveragePriceStatus.textContent = "in the average:";
    }
    else if(vehiclePrice > AveragePrice + (AveragePrice/4))
    {
        AveragePriceImg.src = `/image/PriceEstimateIcons/badPrice.png`;
        AveragePriceStatus.textContent = "Above average:";
    }
    else if(vehiclePrice < AveragePrice)
    {
        AveragePriceImg.src = `/image/PriceEstimateIcons/goodPrice.png`;
        AveragePriceStatus.textContent = "Below average:";
    }
    AveragePriceSpan.textContent = `${AveragePrice-AveragePrice/4} - ${AveragePrice+AveragePrice/4}`;
}


const vehicleIds = window.location.search.substring(4)
$.getJSON(`/customer/Announcement/GetAveragePriceSimilarVehicle?id=${vehicleIds}`,function(values){
    SetAveragePrice(values.averagePrice,values.vehiclePrice);
});

