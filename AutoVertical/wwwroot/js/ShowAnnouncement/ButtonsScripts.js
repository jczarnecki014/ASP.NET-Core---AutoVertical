let observeBtnState = false;
const observeButton = document.querySelector("#observerBtn")
if(observeButton != null){
    observeButton.addEventListener('click',(event)=>{
        if(observeBtnState == false){
            observeBtnState = true;
            event.target.innerHTML = "";
            event.target.innerHTML = `<i class="bi bi-heart-fill"></i> Observe`
        }
        else if (observeBtnState == true){
            observeBtnState = false;
            event.target.innerHTML = "";
            event.target.innerHTML = `<i class="bi bi-heart h5"></i> Observe`
        }
    })
}

const showNumberButton = document.querySelector("#PhoneBtn")
let PhoneBtnState = false;
const userNumber = showNumberButton.textContent;
showNumberButton.textContent = `Click to show number`

showNumberButton.addEventListener('click',(event)=>{
    let vehicleId = event.target.dataset.vehid
    if(PhoneBtnState == false){
        $.post(`/Customer/Announcement/IncreasePhoneDisplaysNumber?identifier=${vehicleId}`,function(data){
        });
        PhoneBtnState = true;
        event.target.textContent = userNumber
    }
})