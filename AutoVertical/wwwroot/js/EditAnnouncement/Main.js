//Loadingbar
const Loading = document.querySelector("#Loading");
Loading.hidden = true;

// Upload photos form toggle
const PhotosFormContainer = document.querySelector("#PhotosFormContainer");
const AddPhotosButtons = document.querySelectorAll(".AddPhotosButton");

let hidden = true;
function PhotoFormContainerToggler()
{
    if(hidden)
    {
        hidden = false;
    }
    else
    {
        hidden = true;
    }
    PhotosFormContainer.hidden = hidden;
}

if(AddPhotosButtons != null)
{
    AddPhotosButtons.forEach(button=>{
        button.addEventListener('click',PhotoFormContainerToggler);
    })
}

//Set limit on image upload
const UploadedImageNumber = document.querySelector("#NumberOfImage").textContent;
const ImageMaximumConunt = document.querySelector("#ImageMaximumConunt").textContent;
const filesInput = document.querySelector("#filesInput");
filesInput.addEventListener('change', function(){
    let selectedFilesNumber = filesInput.files.length;
    let FreeImageSlot = ImageMaximumConunt - UploadedImageNumber
    console.log(FreeImageSlot)
    if(selectedFilesNumber > FreeImageSlot){
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `You are trying upload ${selectedFilesNumber} images but you can upload only ${FreeImageSlot} images`,
          })
          filesInput.value = "";
    }
})




//Picture hover
const vehicleImages = document.querySelectorAll(".vehicleImage");
let imageVerticallySrc = "/image/helpfull/trashHoverVertically.png"
let imageHorizontallySrc = "/image/helpfull/trashHoverHorizontally.png"
let imageSquareSrc = "/image/helpfull/trashHoverSquare.png"
SetBackgroundHover(vehicleImages,imageVerticallySrc,imageHorizontallySrc,imageSquareSrc)


//Delete picture

function DeletePicture(pictureId){
    Loading.hidden = false;
    $.post( `/Customer/Announcement/announcementImage/?imageId=${pictureId}`, function( data ) {
        Swal.fire({
            position: 'top-end',
            icon: data.resoult,
            title: data.message,
            showConfirmButton: true,
            timer: 10000
          })
          setTimeout(function() {
            location.reload();
        }, 2000);
    });
}

vehicleImages.forEach(image=>{
    image.addEventListener("click",e=>{
        DeletePicture(e.target.dataset.id)
    })
})


//Load options in select tag
const filterBox = new FilterBox();
    //Get vehicle type
    const vehicleType = document.querySelector("#vehicleType").value;
    //Get Select Tags
    const ProductionYear = document.querySelector("#ProductionYear");
    const Brand = document.querySelector("#Brand"); 
    const Fuel = document.querySelector("#Fuel");
    const NumberOfDoor = document.querySelector("#NumberOfDor");
    const GearBox = document.querySelector("#GearBox");
    const Drive = document.querySelector("#Drive");
    const BodyType = document.querySelector("#BodyType");
    const BodyColorType = document.querySelector("#BodyColorType");
    const NumberOfSeats = document.querySelector("#NumberOfSeats");
    const Country = document.querySelector("#Country");
    let veh;
    //Create vehicle
    switch (vehicleType){
        case 'car':
            veh = new Car();
            filterBox.SetSelectTagOptions(NumberOfDoor,veh.numberOfDoors,placeholder="noPlaceholder")
            filterBox.SetSelectTagOptions(NumberOfSeats,veh.numberOfSeats,placeholder="noPlaceholder")
        break;
        case 'truck':
            veh = new Truck();
        break;
        case 'motorcycle':
            veh = new Motorcycle();
        break;
    }
    //Load options
    filterBox.SetSelectTagOptions(Brand,veh.brands,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(ProductionYear,veh.productionYears,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(Fuel,veh.fuel,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(GearBox,veh.gearBox,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(Drive,veh.drive,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(BodyType,veh.bodyType,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(BodyColorType,veh.ColorTypes,placeholder="noPlaceholder")
    filterBox.SetSelectTagOptions(Country,veh.Countrys,placeholder="noPlaceholder")
    
