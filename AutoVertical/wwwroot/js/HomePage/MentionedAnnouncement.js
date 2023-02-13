class MentionedAnnouncement{
    constructor(ListOfAnnouncements,SmallAnnouncementTiles,MediumAnnouncementTiles){
        this.ListOfAnnouncements = ListOfAnnouncements;
        this.Index = 0;
        this.tempPath = "/image/tempAnnouncement/";   
    }
    RandAnnouncements(){
        let NumberOfAnnouncements = this.ListOfAnnouncements.length
        let RandedAnnouncements = [];
        for(let i=0; i<this.ListOfAnnouncements.length;){
            let RandedIndexIndex = Math.floor(Math.random() * NumberOfAnnouncements);
            if(!RandedAnnouncements.includes(this.ListOfAnnouncements[RandedIndexIndex])){
                RandedAnnouncements.push(this.ListOfAnnouncements[RandedIndexIndex])
                i++;
            }
        }
        return RandedAnnouncements
    }
    SetTiles(tiles,random=false){
        if(this.Index > this.ListOfAnnouncements.length-1){
            this.Index = 0;
        }
        let TileImg;
        let TileTitle;
        let TileYear;
        let TileMileage;
        let TileFuel;
        let TileCubicCapacity;
        let TilePrice;
        let VehicleDetails;
        let VehicleImages;
        let imgIndex = this.Index;
        let ListOfAnnouncements
        if(random){
            ListOfAnnouncements = this.RandAnnouncements()
        }
        else{
            ListOfAnnouncements = this.ListOfAnnouncements;
        }

        tiles.forEach(element=>{
            if(imgIndex>=ListOfAnnouncements.length){
                imgIndex = 0;
            }
            //Recive tile elements
            TileImg = element.querySelector(".tile-img");
            TileTitle = element.querySelector(".tile-title")
            TileYear = element.querySelector(".tile-year")
            TileMileage = element.querySelector(".tile-mileage")
            TileFuel = element.querySelector(".tile-fuel")
            TilePrice = element.querySelector(".tile-price")
            TileCubicCapacity = element.querySelector(".tile-capacity")
            VehicleDetails = ListOfAnnouncements[imgIndex].vehicle
            VehicleImages = ListOfAnnouncements[imgIndex].images[2]
            //Set IMG
            TileImg.src = VehicleImages.name
            //Set Title
            TileTitle.textContent = VehicleDetails.title
            //Set Details
            TileYear.textContent = VehicleDetails.productionYear;
            TileMileage.textContent = addSpace(VehicleDetails.milage);
            TileFuel.textContent = VehicleDetails.fuel;
            TileCubicCapacity.textContent = VehicleDetails.cubicCapacity + " cm";
            //Set Price
            TilePrice.innerHTML = VehicleDetails.priceBrutto + "<sub> PLN</sub>";
            element.href = `customer/Announcement/ShowAnnouncement?identifier=${VehicleDetails.id}`
            imgIndex++;
        })
        this.Index++;
    }
}


