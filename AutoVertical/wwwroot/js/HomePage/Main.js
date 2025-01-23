
//VehicleChanger
const VehiclesSubmits = document.querySelectorAll(".vehicleSubmit")
VehiclesSubmits.forEach(vehicle =>{
    vehicle.addEventListener('click',e=>{
        filterBox.ChangeVehicle(e)
        SetMentionedAnnouncement(filterBox.ActiveVehicle);
        SetFilter(filterBox.ActiveVehicle)
        SetNumberOfAnnouncement("vehicleType",filterBox.ActiveVehicle);
    })
})

//Set filter for specify vehicle
function SetFilter(vehicle){
        //get every filter inputs
    const BodyTypeFilter = document.querySelector("#FilterBodyType");
    const BrandFilter = document.querySelector("#FilterBrand");
    const ProductionYearFromFilter = document.querySelector("#FilterYearFrom");
    const ProductionYearToFilter = document.querySelector("#FilterYearTo");
    const FuelTypeFilter = document.querySelector("#FilterFuelType");
    const MileageFromFilter = document.querySelector("#FilterMileageFrom");
    const MileageToFilter = document.querySelector("#FilterMileageTo");
    const ModelFilter = document.querySelector("#FilterModel");
    const VehicleTypeFilter = document.querySelector("#FilterVehicleType");
        //Set specific vehicle
        let veh;

        switch (vehicle){
            case 'car':
                veh = new Car();
                filterBox.SetInputsTagPlaceHolders(ModelFilter,"SERIES 5 / A4 B8 / COROLLA")
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
        
        filterBox.SetSelectTagOptions(BodyTypeFilter,veh.bodyType)
        filterBox.SetSelectTagOptions(BrandFilter,veh.brands)
        filterBox.SetSelectTagOptions(ProductionYearFromFilter,veh.productionYears,"From")
        filterBox.SetSelectTagOptions(ProductionYearToFilter,veh.productionYearsDesc,"To")
        filterBox.SetSelectTagOptions(FuelTypeFilter,veh.fuel)
        filterBox.SetInputsTagPlaceHolders(MileageFromFilter,"Mileage from")
        filterBox.SetInputsTagPlaceHolders(MileageToFilter,"Mileage to")
        VehicleTypeFilter.value = vehicle
        
}

// Mentioned announcements set
let interval;
function SetMentionedAnnouncement(vehicleType){
    clearInterval(interval)
    const SmallAnnouncementTiles = document.querySelectorAll(".small-tiles");
    const MediumAnnouncementTiles = document.querySelectorAll(".medium-tiles");
    const LargeAnnouncementTiles = document.querySelectorAll(".large-tiles");
    const SpecialsOffersSection = document.querySelector('[name="SpecialsOffers"]');
    const NoAnnouncementsAlert = document.querySelector('[name="NoAnnouncementsAlert"]');
    console.log(NoAnnouncementsAlert)
    $.getJSON(`/customer/Announcement/GetMentionedVehicle?VehicleType=${vehicleType}`,function(values){
        if(values.length == 0)
        {
            SpecialsOffersSection.style.display = 'none';
            NoAnnouncementsAlert.style.display = 'block';
        }
        else {
            SpecialsOffersSection.style.display = 'block';
            NoAnnouncementsAlert.style.display = 'none';
        }
        document.querySelector("#Loading").style.display="none";
        announcementCarousel = new MentionedAnnouncement(values);
        announcementCarousel.SetTiles(SmallAnnouncementTiles,random=true); // first set
        announcementCarousel.SetTiles(MediumAnnouncementTiles,random=true); // 
        announcementCarousel.SetTiles(LargeAnnouncementTiles,random=true); // first set
        interval = setInterval(announcementCarousel.SetTiles.bind(announcementCarousel),3500,SmallAnnouncementTiles)
    });   
}

//Announcement count show in red button
let parameterList = [
    {name:"vehicleType",value:""},
    {name:"bodyType",value:""},
    {name:"vehicleBrand",value:""},
    {name:"vehicleModel",value:""},
    {name:"productionYearsFrom",value:""},
    {name:"productionYearsTo",value:""},
    {name:"fuelType",value:""},
    {name:"mileageFrom",value:""},
    {name:"mileageTo",value:""},
];

function SetNumberOfAnnouncement(parametrName,data){
    let url = `/customer/Announcement/GetCountOfAnnouncement?`;
    let parametr = parametrName;
    let value = data;
    parameterList.forEach(element=>{
        if(element.name == parametr){
            element.value = value;
        }
    })
    parameterList.forEach(element=>{
        if(element.value != ""){
            url +=`${element.name}=${element.value}&`
        }
    })
    $.getJSON(url,function(value){ 
            AnnouncementCount.textContent = value;
    })
    
}
    
const AnnouncementCount = document.querySelector("#AnnouncementCount");
const FiltersList = document.querySelectorAll(".filter");
FiltersList.forEach(filter =>{
    filter.addEventListener("change", e=>SetNumberOfAnnouncement(e.target.dataset.type,e.target.value))
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

//Initial
const filterBox = new FilterBox('car');
SetMentionedAnnouncement(filterBox.ActiveVehicle);
SetFilter(filterBox.ActiveVehicle)
SetNumberOfAnnouncement("vehicleType",filterBox.ActiveVehicle);