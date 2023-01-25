
const vehicle = document.querySelector("#VehicleTypeInput");

const filters = document.querySelectorAll(".filters");
//Set filter values for specify vehicle
function SetFiltersInputs(advanced_seearch_expanded){
    //get every filter inputs
    const ModelFilter = document.querySelector("#FilterModel");
    const BodyTypeFilter = document.querySelector("#FilterBodyType");
    const BrandFilter = document.querySelector("#FilterBrand");
    const ProductionYearFromFilter = document.querySelector("#FilterYearFrom");
    const ProductionYearToFilter = document.querySelector("#FilterYearTo");
    const FuelTypeFilter = document.querySelector("#FilterFuelType");
    const CountryOfOrigin = document.querySelector("#FilterCountryOfOrigin");
    const ColorTypeFilter = document.querySelector("#FilterColorType");
    console.log(ColorTypeFilter)
    const NumberOfDoorFilter = document.querySelector("#FilterNumberOfDoor");
    const NumberOfSeatsFilter = document.querySelector("#FilterNumberOfSeats");
    const GearBoxFilter = document.querySelector("#FilterGearBox");
    const filterBox = new FilterBox();
        //Set specific vehicle
        let veh;
    console.log(NumberOfDoorFilter)
        switch (vehicle.value){
            case 'car':
                veh = new Car();
                filterBox.SetInputsTagPlaceHolders(ModelFilter,"SERIES 5 / A4 B8 / COROLLA")
                if(advanced_seearch_expanded){
                    filterBox.SetSelectTagOptions(NumberOfDoorFilter,veh.numberOfDoors,"Number Of Doors")
                    filterBox.SetSelectTagOptions(NumberOfSeatsFilter,veh.numberOfSeats,"Number Of Seats")
                }
            break;
            case 'truck':
                veh = new Truck();
                filterBox.SetInputsTagPlaceHolders(ModelFilter,"TGX / R420 / R500")
            break;
            case 'motorcycle':
                veh = new Motorcycle();
                filterBox.SetInputsTagPlaceHolders(ModelFilter,"CBR600 / GSXR1000 / ZX10R")
            break;
        }
        filterBox.SetSelectTagOptions(BodyTypeFilter,veh.bodyType,"Body Type")
        filterBox.SetSelectTagOptions(BrandFilter,veh.brands,"Brand")
        filterBox.SetSelectTagOptions(ProductionYearFromFilter,veh.productionYears,"Production Year from")
        filterBox.SetSelectTagOptions(ProductionYearToFilter,veh.productionYearsDesc,"Production Year to")
        filterBox.SetSelectTagOptions(FuelTypeFilter,veh.fuel,"Fuel")
        filterBox.SetSelectTagOptions(CountryOfOrigin,veh.Countrys,"Country of Origin")
        filterBox.SetSelectTagOptions(ColorTypeFilter,veh.ColorTypes,"Color Type")
        filterBox.SetSelectTagOptions(GearBoxFilter,veh.gearBox,"Gear Box")
}

// Set additional filters

const FilterButtons = document.querySelectorAll(".FilterButtons")
const AdditionalFiltersDivs = document.querySelectorAll(".AdditionalFilters")
const additionalFilter = new AdditionalFilters(AdditionalFiltersDivs);
FilterButtons.forEach(button =>{
    button.addEventListener('click',e=>additionalFilter.ShowDiv(e))
})

//ChangingEvenetsOnVehicleSelector
let activeVehicle = vehicle.value;
vehicle.addEventListener("change",e=>{
    let disabled;
    if(e.target.value != activeVehicle){
        disabled = true;
        $("#test")
        .animate({opacity: "1"})
        .animate({width: "180px"})
    }
    else{
        disabled=false;
        $("#test")
        .animate({width: "40px"})
        .animate({opacity: "0"})
    }
    filters.forEach(element =>{
        element.disabled = disabled;
    })
})

//Load advertisement
const LargeAdverts = document.querySelectorAll(".largeAdvertisement")
const MediumAdvert = document.querySelectorAll(".mediumAdvertisement")

const SetAdvertaisments = new RandAdvertisement(LargeAdverts,MediumAdvert)

const GetLargeAdvertsUrl = "/Customer/Advertisement/GetAdvertisements?size=large"
const GetMediumAdvertsUrl = "/Customer/Advertisement/GetAdvertisements?size=medium"

$.getJSON(GetLargeAdvertsUrl,function(value){ 
    SetAdvertaisments.setAdverts(value,'large')
})

$.getJSON(GetMediumAdvertsUrl,function(value){ 
    SetAdvertaisments.setAdverts(value,'medium')
})