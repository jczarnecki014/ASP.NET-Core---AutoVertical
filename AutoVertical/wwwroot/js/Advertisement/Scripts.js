

//Advertisement size choose
//It's set value in "AdvertisementSize" input before send post request 

//total cost tavle inputs
const OptionName = document.querySelector("#OptionName");
const PricePerDay = document.querySelector("#PricePerDay");
const NumberOfDays = document.querySelector("#NumberOfDays");
const TotalCost = document.querySelector("#TotalCost");

let currentPrice;
let selectedNumberOFDays;
const options = document.querySelectorAll(".options")
const dateInputs = document.querySelectorAll(".dateInputs")
const AdvertisementSize = document.querySelector("#AdvertisementSize")

let selectedElement = null;

//Function calculate total cost
function GetTotalCost(){
    if(!isNaN(selectedNumberOFDays) && !isNaN(currentPrice)){
        TotalCost.textContent = `${currentPrice * selectedNumberOFDays} PLN`
    }
}

options.forEach(option => {
    option.addEventListener('click',function(e) {
        if(selectedElement != e.currentTarget){
            if(selectedElement != null)
            {
                selectedElement.classList.remove("selected")
            }
            e.currentTarget.classList.add("selected")
            AdvertisementSize.value = e.currentTarget.dataset.size
            OptionName.textContent = `${(e.currentTarget.dataset.size)} ADVERTISEMENT`.toUpperCase()
            PricePerDay.innerHTML = `${(e.currentTarget.dataset.price)} <sub>PLN/DAY</sub>`
            currentPrice = e.currentTarget.dataset.price;
            selectedElement = e.currentTarget;
            GetTotalCost();
        }
    })
});


const ActiveStartInput = document.querySelector("#ActiveFrom");
const ActiveExpiredInput = document.querySelector("#ActiveTo");

//Set minimum dates in form inputs
const currentDate = new Date();

ActiveStartInput.min = currentDate.toISOString().split("T")[0];
ActiveExpiredInput.min = currentDate.toISOString().split("T")[0];


//Form validation

const AdvertisementForm = document.querySelector("#AdvertisementForm");
let error;

//If user try to send form without selected advertisement option, return error popup
    function Validate_AdvertSize(){
        if(selectedElement != null){
            return true   
        }
        else{
            error = "Please select advertisement option"
            return false
        }
    }

    //If user didn't fill inputs
    function Validate_DatesInput_IsNotNull(ActiveFromInput,ActiveToInput){
        if(ActiveFromInput !="" && ActiveToInput !=""){
            return true   
        }
        else{
            error = "Please fill dates inputs"
            return false
        }
    }

    //If user choose date in past return error
    function Validate_DateInPast_Prevent(TodaysDate,ActiveFromDate,ActiveToDate){
        if(ActiveFromDate >= TodaysDate && ActiveToDate > TodaysDate){
            return true   
        }
        else{
            error = "This was stupid... but i don't let you use past dates "
            return false
        }
    }

    //If user choose "from date"  >= "To date"
    function Validate_Difrence_Between_Two_Dates(ActiveFromDate,ActiveToDate){
        if(ActiveToDate > ActiveFromDate){
            return true   
        }
        else{
            error = "Incorect differences between  dates"
            return false
        }
    }

    function Validate_Image_Is_Not_Null(){
        const imageInput = document.querySelector("#image")
        console.log(imageInput.files.length)
        if(imageInput.files.length > 0){
            return true   
        }
        else{
            error = "You have to choose some image"
            return false
        }
    }


    function ValidateForm(){
        const ActiveStartValue = ActiveStartInput.value;
        const ActiveExpiredValue = ActiveExpiredInput.value;
        const TodaysOnlyDate = new Date().toISOString().split("T")[0];

        if(Validate_AdvertSize() && Validate_DatesInput_IsNotNull(ActiveStartValue,ActiveExpiredValue) && Validate_DateInPast_Prevent(TodaysOnlyDate,ActiveStartValue,ActiveExpiredValue) && Validate_Difrence_Between_Two_Dates(ActiveStartValue,ActiveExpiredValue) && Validate_Image_Is_Not_Null() )
        {
            AdvertisementForm.submit()
        }
        else{
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: error,
                footer: '<a href="">Why do I have this issue?</a>'
              })
        }
    }


// Count numer of advertisement active days and calculate total cost

dateInputs.forEach(element=>{
    element.addEventListener("change", function(e){
        let ActiveFrom = new Date(dateInputs[0].value)
        let ActiveTo = new Date(dateInputs[1].value)
        let differences_in_time = ActiveTo.getTime() - ActiveFrom.getTime();
        let Difference_In_Days = differences_in_time / (1000 * 3600 * 24);
        if(!isNaN(Difference_In_Days)){
            selectedNumberOFDays = Difference_In_Days;
            NumberOfDays.textContent = `${Difference_In_Days} days`;
            GetTotalCost();
        }
    })
})

