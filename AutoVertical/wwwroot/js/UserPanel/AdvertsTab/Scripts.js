
//Get every showing announcement inputs
const AnnouncementViewContainer = document.querySelector("#AnnouncementViewContainer");
const VehicleTitile = document.querySelector("#VehicleTitile");
const VehiclePrice = document.querySelector("#VehiclePrice");
const VehicleDescription = document.querySelector("#VehicleDescription");
const VehicleImages = document.querySelector("#VehicleImages");
const BigVehicleImage = document.querySelector("#BigVehicleImage");
const DeleteFormIdInput = document.querySelector("#DeleteFormIdInput");
const SoldVehicleFormIdInput = document.querySelector("#SoldVehicleFormIdInput");
const EditFormIdInput = document.querySelector("#EditFormIdInput");
const ActiveAgainBtn = document.querySelector("#ActiveAgainButton");
const EditBtn = document.querySelector("#EditButton");
const advertViewsCanvas = document.querySelector("#advertViews");
const phoneNumberCanvas = document.querySelector('#phoneNumberShows');

//Active displayed vehicle
let activeVehicle;

//Selected period
const PeriodSelect = document.querySelector("#PeriodSelect")
let period = PeriodSelect.value

//Set event on periodSelectChanges

PeriodSelect.addEventListener('change',function(e){
    period = e.target.value;
    if(activeVehicle != null){
        ShowAnnouncement(activeVehicle)
    }

})

//function get information to assistant if every displayed announcement have a active status
function EveryAnnouncementActive(){
  const statuses =  document.querySelectorAll(".AnnouncementStatus");
  let condition = true;
  if(statuses.length == 0 ){
    return condition
  }
  statuses.forEach(status =>{
      if(status.dataset.expired == "true"){
        condition = false;
      }
  })
  return condition
}
//SHOW ANNOUNCEMENET - GET VEHICLE BY ID
function ShowAnnouncement(id){
    VehicleImages.innerHTML = "";
    BigVehicleImage.innerHTML = "";
    DeleteFormIdInput.value = id;
    SoldVehicleFormIdInput.value = id;
    EditFormIdInput.value = id;
    activeVehicle = id;
    $.getJSON( `/Customer/Announcement/GetAnnouncement?VehicleId=${id}`, function( data ) {
        //Select period and GenerateAdvert views Chart
        GetCharts(period,activeVehicle);

        //Show announcement view container  (default = hiden)
        AnnouncementViewContainer.hidden = false;
        //Set announcement inputs
        VehicleTitile.value = data.announcement.vehicle.title;
        VehiclePrice.value = data.announcement.vehicle.priceBrutto;
        VehicleDescription.value = data.announcement.vehicle.description;
        if(data.state == "active"){
            EditBtn.hidden = false;
            ActiveAgainBtn.hidden = true;
        }
        else if (data.state == "expired"){
            EditBtn.hidden = true;
            ActiveAgainBtn.hidden = false;
        }
        //Render announcement images
        let imgNumber = 0;
        data.announcement.images.forEach(element=>{
            if(imgNumber==0){
                BigVehicleImage.src = element.name;
            }
            else{
                const div = document.createElement("div");
                div.className = "col-lg-3";
                const img = document.createElement("img");
                img.className = "img-thumbnail my-2";
                img.src = element.name;
                img.style.maxHeight = "120px"
                img.style.minHeight = "120px"
                div.appendChild(img);
                VehicleImages.appendChild(div);
            }
            imgNumber++;
        })
    })
        
}


//Hide announcement view button
const AnnouncementViewContainerClose = document.querySelector("#AnnouncementViewContainerClose");

AnnouncementViewContainerClose.addEventListener('click',function(){
    AnnouncementViewContainer.hidden = true;
})




//Delete announcement alert
document.querySelector("#deleteButton").addEventListener('click', function(){
     const form = document.querySelector(`[name="deleteForm"]`);
     Swal.fire({
            title: 'Are you sure?',
            text: "If you delete your announcement, you aren't able to restore it and you won't get back money alredy spent",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.isConfirmed) {
                    form.submit()
                    return false;
                }
            })
    })

document.querySelector("#SoldButton").addEventListener('click', function(){
        const form = document.querySelector(`[name="SoldVehicle"]`);
        Swal.fire({
               title: 'Are you sure?',
               text: "If you consider this vehicle as sold, this advert will be removed from system ",
               icon: 'warning',
               showCancelButton: true,
               confirmButtonColor: '#3085d6',
               cancelButtonColor: '#d33',
               confirmButtonText: 'Yes, delete it!'
               }).then((result) => {
                   if (result.isConfirmed) {
                    Swal.fire({
                        title: '<h2 class="animate__animated animate__slideInRight animate__slow"> <i class=" text-warning bi bi-trophy-fill"></i> CONGRATULATIONS <i class=" text-warning bi bi-trophy-fill"></i></h1>'+
                        '<p class="animate__animated animate__slideInLeft animate__slow small">We are realy proud and happy, the next user sucessfully sold his vehicle.. We hope you are satified our cooperation and next time you also choose</p>' + 
                        '<img class="img-fluid" src="/image/main/Logo.png">',
                        showClass: {
                          popup: 'animate__animated animate__fadeInBottomRight'
                        },
                        hideClass: {
                          popup: 'animate__animated animate__fadeOutUp'
                        }
                      }).then((result) => {
                        if (result.isConfirmed){
                          form.submit()
                        }
                      })
                   }
               })
       })

// Sold Announcement alert


    let advertViewsChart=null;
    let phoneDisplaysChart = null;

//Generate Labels to Chart
function GetCharts(period,vehicleId)
{
    $.getJSON( `/Customer/Announcement/GetAdvertStats?VehicleId=${vehicleId}&period=${period}`, function( data ) {
        let ViewStatsData = {
            labels: generateLabels(period),
            datasets: [{
              label: "views",
              data: PrepareData(data,period,"viewsStats"),
              fill: true,
              borderColor: "rgb(59, 197, 170)",
              tension: 0.1
            }]
          };

          let PhoneNumberDisplaysStatsData = {
            labels: generateLabels(period),
            datasets: [{
              label: "Phone number displays",
              data: PrepareData(data,period,"PhoneNumberDisplaysStatsData"),
              fill: true,
              borderColor: "rgb(68, 189, 50)",
              tension: 0.1
            }]
          };

        if(advertViewsChart !=null || phoneDisplaysChart !=null){
            advertViewsChart.destroy();
            phoneDisplaysChart.destroy();
        }

          advertViewsChart =  new Chart(advertViewsCanvas, {
            type: 'line',
            data: ViewStatsData,
          });
          phoneDisplaysChart = new Chart(phoneNumberCanvas, {
            type: 'line',
            data: PhoneNumberDisplaysStatsData,
          });
    })

}




//Get "Show announcement buttons"
const showAnnouncement = document.querySelectorAll(".showAnnouncement");

//Set event listener
showAnnouncement.forEach(element => {
    element.addEventListener('click',e=>ShowAnnouncement(e.currentTarget.dataset.vehicleid))
});
