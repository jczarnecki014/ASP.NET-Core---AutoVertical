
//Load advertisement
const smallAdvertisement = document.querySelectorAll(".smallAdvertisement")
const largeAdvertisement = document.querySelectorAll(".largeAdvertisement")

const SetAdvertaisments = new RandAdvertisement(largeAdvert = largeAdvertisement,mediumAdvert = null,smallAdvert = smallAdvertisement)

const GetSmallAdvertsUrl = "/Customer/Advertisement/GetAdvertisements?size=small"
const GetlargeAdvertsUrl = "/Customer/Advertisement/GetAdvertisements?size=large"

$.getJSON(GetSmallAdvertsUrl,function(value){ 
    SetAdvertaisments.setAdverts(value,'small')
})

$.getJSON(GetlargeAdvertsUrl,function(value){ 
    SetAdvertaisments.setAdverts(value,'large')
})
