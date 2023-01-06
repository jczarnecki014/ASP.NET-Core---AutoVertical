//Advertisement size choose
//It's set value in "AdvertisementSize" input before send post request 

const options = document.querySelectorAll(".options")
const AdvertisementSize = document.querySelector("#AdvertisementSize")

let selectedElement = null;

options.forEach(option => {
    option.addEventListener('click',function(e) {
        if(selectedElement != e.currentTarget){
            if(selectedElement != null)
            {
                selectedElement.classList.remove("selected")
            }
            e.currentTarget.classList.add("selected")
            AdvertisementSize.value = e.currentTarget.dataset.size
            selectedElement = e.currentTarget;
        }
    })
});


const ActiveStartInput = document.querySelector("#ActiveFrom");
const ActiveExpiredInput = document.querySelector("#ActiveTo");

//Set minimum dates in form inputs
console.log(ActiveStartInput.min)
ActiveStartInput.min = new Date().toISOString().split("T")[0];
ActiveStartInput.min = new Date().toISOString().split("T")[0];

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


        const TodaysDate = new Date();
        const ActiveStartDate = new Date(ActiveStartValue);
        const ActiveExpiredDate = new Date(ActiveExpiredValue);

        if(Validate_AdvertSize() && Validate_DatesInput_IsNotNull(ActiveStartValue,ActiveExpiredValue) && Validate_DateInPast_Prevent(TodaysDate,ActiveStartDate,ActiveExpiredDate) && Validate_Difrence_Between_Two_Dates(ActiveStartDate,ActiveExpiredDate) && Validate_Image_Is_Not_Null() )
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
