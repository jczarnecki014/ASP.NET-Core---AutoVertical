
//Update advertisement container elements

const container =document.querySelector("#Container");
const ShowContainerButtons = document.querySelectorAll(".ShowContainerButton");
const CloseContainerButton = document.querySelector("#CloseContainerButton");

//Fill container inputs
function UpdateContainerFill(AdvertUrlValue,AdvertActiveFromValue,AdvertActiveToValue,AdvertActiveId,AdvertImgSrc){
  const AdvertUrl = document.querySelector("#AdvertUrl")
  const AdvertActiveFrom = document.querySelector("#AdvertActiveFrom")
  const AdvertActiveTo = document.querySelector("#AdvertActiveTo")
  const AdvertisementId = document.querySelector("#AdvertisementId")
  const AdvertImg = document.querySelector("#AdvertImg")

  AdvertUrl.value = AdvertUrlValue;
  AdvertActiveFrom.value = AdvertActiveFromValue;
  AdvertActiveTo.value = AdvertActiveToValue;
  AdvertisementId.value = AdvertActiveId;
  AdvertImg.src = AdvertImgSrc;
}

//function get information to assistant if every displayed advertisement have a active status
function EveryAdvertisementActive(){
  const statuses =  document.querySelectorAll(".AdvertisementStatus");
  let condition = true;
  if(statuses.length == 0 ){
    return condition
  }
  statuses.forEach(status =>{
    console.log(status)
      if(status.dataset.expired == "true"){
        condition = false;
      }
  })
  return condition
}


// Show UserUpdateContainer function

ShowContainerButtons.forEach(element => {
    element.addEventListener("click",function(e){
        const advertisementId = e.currentTarget.dataset.id
        const GetAdvertisementJSONUrl = `http://localhost:25364/Customer/Advertisement/GetUserAdvertisement?id=${e.currentTarget.dataset.id}`

        $.getJSON(GetAdvertisementJSONUrl,function(advertisement){
          UpdateContainerFill(advertisement.url,advertisement.activeFrom,advertisement.activeTo,advertisement.id,advertisement.imageSrc)
        })
        container.classList.remove('animate__animated', 'animate__slideOutUp' )
        container.style.display="block";
        container.classList.add('animate__animated', 'animate__slideInDown','animate__slower');
      })
})


CloseContainerButton.addEventListener("click",function(){
  container.classList.remove('animate__animated','animate__slideInDown','animate__slower' )
  container.classList.add('animate__animated', 'animate__slideOutUp');
})