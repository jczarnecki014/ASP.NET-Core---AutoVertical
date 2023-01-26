//Tab name
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
const PageName = urlParams.get('tab')



//Assistant tab tutorials

const AssistentDiv = document.querySelector("#AssistentDiv");
const AssistantNoOptions = document.querySelector("#assistantNoOption");
const AssistantYesOptions = document.querySelector("#assistantYesOption");

AssistantNoOptions.addEventListener("click",function(){
    AssistentDiv.classList.remove('animate__animated','animate__slideInRight','animate__slower' )
    AssistentDiv.classList.add('animate__animated', 'animate__slideOutRight');
  })

  AssistantYesOptions.addEventListener("click",function(){
    const SoundUrl = `\\sounds\\UserProfileAssistant\\${PageName}.mp3`
    let soundEffect = new Audio(SoundUrl);
    soundEffect.play()
    
    additionalInformation(PageName)
  })



//This function play additional information if main tab script return some isuess, unfortunately we have to pass time of main tutorial message because
//we need to delay seccondary information, otherwise two information will play in the same time
function additionalInformation(PageName){
    switch(PageName){
        case "AdvertsTab":
            if(EveryAnnouncementActive() == false){
                console.log("test")
                const SoundUrl = `\\sounds\\UserProfileAssistant\\ExpiredAnnouncements.mp3`
                setTimeout(()=>{
                    let soundEffect = new Audio(SoundUrl);
                    soundEffect.play()
                },9400)
            }
        break;
        case "AdvertisementTab":
            if(EveryAdvertisementActive() == false){
                console.log("test3")
                const SoundUrl = `\\sounds\\UserProfileAssistant\\AdvertisementExpired.mp3`
                setTimeout(()=>{
                    let soundEffect = new Audio(SoundUrl);
                    soundEffect.play()
                },7200)
            }
        break;
    }
}