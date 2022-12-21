let observeBtnState = false;
const observeButton = document.querySelector("#observerBtn").addEventListener('click',(event)=>{
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

const showNumberButton = document.querySelector("#PhoneBtn")
let PhoneBtnState = false;
const userNumber = showNumberButton.textContent;
showNumberButton.textContent = `Click to show number`

showNumberButton.addEventListener('click',(event)=>{
    if(PhoneBtnState == false){
        event.target.textContent = userNumber
    }
})