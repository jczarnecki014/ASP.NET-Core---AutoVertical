//Get chart canvas
const advertViewsCanvas = document.querySelector("#advertViews");
const phoneNumberCanvas = document.querySelector('#phoneNumberShows');

//Active charts
let advertViewsChart = null;
let phoneDisplaysChart =null;

//Selected period
const PeriodSelect = document.querySelector("#PeriodSelect")
let period = PeriodSelect.value


//Set event on periodSelectChanges

PeriodSelect.addEventListener('change',function(e){
  period = e.target.value;
  RenderCharts();
})

//Load chart
function RenderCharts(){
  $.getJSON( `/Customer/Announcement/GetAdvertStats?UserAdverts=true&period=${period}`, function( data ) {
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



//User update div

const container =document.querySelector("#UserUpdateContainer");
const UpdateProfileButton = document.querySelector("#UpdateProfileButton");
const containerCloseButton = document.querySelector("#CloseProfileEdit");

// Show UserUpdateContainer function

UpdateProfileButton.addEventListener("click",function(){
  container.classList.remove('animate__animated', 'animate__slideOutUp' )
  container.style.display="block";
  container.classList.add('animate__animated', 'animate__slideInDown','animate__slower');
})

containerCloseButton.addEventListener("click",function(){
  container.classList.remove('animate__animated','animate__slideInDown','animate__slower' )
  container.classList.add('animate__animated', 'animate__slideOutUp');
})

// Change user avatar algin
const avatarImg = document.querySelectorAll(".avatarImg");
const VerticallySrc = "/image/helpfull/Avatar_hover_215x273.png"
const SquareSrc = "/image/helpfull/Avatar_hover_273x273.png"
const AvatarFileInput = document.querySelector("#AvatarFileInput");
SetBackgroundHover(avatarImg,imageVerticallySrc = VerticallySrc,imageSquareSrc = SquareSrc)


avatarImg.forEach(element => {
  element.style.cursor = "pointer";
  element.addEventListener('click',function(){
    if(AvatarFileInput.hidden == true){
      AvatarFileInput.hidden = false
    }
    else{
      AvatarFileInput.hidden = true
    }
  })
});




RenderCharts();