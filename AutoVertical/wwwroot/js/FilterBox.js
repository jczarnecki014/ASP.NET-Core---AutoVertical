class FilterBox{
    constructor(activeVehicle){
        this.ActiveVehicle = activeVehicle;
    }
    ChangeVehicle(event){
        //change vehicle and color of clicked tab
        let activeVehicleTab = document.querySelectorAll(`[data-value="${this.ActiveVehicle}"]`);
        activeVehicleTab[0].classList.add("tab")
        this.ActiveVehicle = event.currentTarget.dataset.value
        event.currentTarget.classList.remove("tab")
    }
    SetSelectTagOptions(filterTag,options,placeholder=""){
        filterTag.innerHTML="";
        ///First default option in select list
        let option = document.createElement("option");;
        if(placeholder !=""){
            option.textContent = placeholder;
        }
        else{
            option.textContent = "-- Select --";
        }
        option.selected = true;;
        option.disabled = true;
        filterTag.appendChild(option);
        options.forEach(element =>{
            option = document.createElement("option");
            option.value = element;
            option.textContent = element;
            filterTag.appendChild(option);
        })
        
    }
    SetInputsTagPlaceHolders(filterTag,value){
        filterTag.placeholder=value;
    }
}