
class FormHandler{
    constructor([...selectList]){
        this.specificSelectList = selectList.filter(element=>element.classList.contains("specific"));
        this.commonSelectList = selectList.filter((element)=>{
            return !this.specificSelectList.includes(element);
        })
        this.activeInputsOfVehicle = document.querySelectorAll(".car");
    }
    SetEventListener(){
        this.commonSelectList[0].addEventListener("change",(event)=>{this.SetVehicle(event.target.value)})
        document.querySelector("#filesInput").addEventListener("change",(e)=>this.ShowUserIMG(e));
        document.querySelector("textarea.miniPreviewInfo").addEventListener("input",(e)=>this.TextLengthControler(e));
    }
    TextLengthControler(e){
        const textLengthSpan = document.querySelector("#textLength");
        if(e.target.value.length > 4000){
            textLengthSpan.style.color="red";
            let cutedString = e.target.value.substring(0,4000)
            e.target.value = cutedString;
        }
        else if(e.target.value.length > 3000){
            textLengthSpan.style.color="orange";
        }
        else if(e.target.value.length > 2000){
            textLengthSpan.style.color="green";
        }
        else{
            textLengthSpan.style.color="black";
        }
        textLengthSpan.textContent = e.target.value.length;
    }
    ShowUserIMG(e){
        let test = "test";
        if (window.File && window.FileReader && window.FileList && window.Blob) {
            const files = e.target.files;
            const output = document.querySelector("#output");
            const imgSRC = [];
            output.innerHTML = "";
            
            for(let i=0; i < files.length; i++){
                if(!files[i].type.match("image")) continue;
                const imgReader = new FileReader();
                // imageGalery[i] = "tekst";
                imgReader.addEventListener("load",(event)=>{
                    const imgFile = event.target;
                    const div = document.createElement("div");
                    div.classList.add("col-lg-4");
                    div.classList.add("mb-3");
                    const img = document.createElement("img");
                    img.classList.add("img-thumbnail");
                    img.src = imgFile.result;
                    imgSRC.push(img.src);
                    div.appendChild(img);
                    output.appendChild(div);
                    if(i == files.length-1){
                        new MiniPreview().setGallery('userVehicle',imgSRC)
                    }
                })
                imgReader.readAsDataURL(files[i]);
            }
          } else {
            alert("Your browser does not support File API");
          }
    }
    SetVehicle(event){
        this.SwitchInputs(event)
        this.LoadVehicleOptions(event)
    }
    SwitchInputs(vehicleName){
        const InputToggler = (display) =>
        {
            this.activeInputsOfVehicle.forEach(element => {
                element.style.display = display;
            }); 
        }
        InputToggler('none')
        this.activeInputsOfVehicle = document.querySelectorAll("."+vehicleName)
        InputToggler('block')
    }
    LoadVehicleOptions(activeVehicle){
        //Internal functions
        const OptionsCreator= (values,selectTag) => {
            selectTag.innerHTML="";

            let defaultOption = document.createElement("option");
            defaultOption.innerHTML = "-- Select --"

            selectTag.appendChild(defaultOption);
            values.forEach(element => {
                let option = document.createElement("option");
                option.value = element;
                option.innerHTML = element;
                selectTag.appendChild(option);
            });
        }
        const ClearEverySelectTag = () => {
            this.specificSelectList.forEach(selectTag=>{
                selectTag.innerHTML='';
            })
        }

        //Main method functionality
        let vehicle;
        ClearEverySelectTag();

        switch (activeVehicle){
            case 'car':
                vehicle = new Car();
                break;
            case 'truck':
                vehicle = new Truck();
                break;
            case 'motorcycle':
                vehicle = new Motorcycle();
                break;
        }
        //Load options to specific select list
        OptionsCreator(vehicle.brands,this.specificSelectList[0])
        OptionsCreator(vehicle.fuel,this.specificSelectList[1])
        OptionsCreator(vehicle.gearBox,this.specificSelectList[3])
        OptionsCreator(vehicle.drive,this.specificSelectList[4])
        OptionsCreator(vehicle.bodyType,this.specificSelectList[5])
        OptionsCreator(vehicle.numberOfDoors,this.specificSelectList[2])
        OptionsCreator(vehicle.numberOfSeats,this.specificSelectList[6])
        //Load options to common select list
        OptionsCreator(vehicle.productionYears,this.commonSelectList[1])
        OptionsCreator(vehicle.ColorTypes,this.commonSelectList[2])
        OptionsCreator(vehicle.Countrys,this.commonSelectList[3])
    }
}



//Main
selectList = document.querySelectorAll("select");
formHandler = new FormHandler(selectList);
formHandler.SetEventListener();
formHandler.SetVehicle("car"); // set first vehicle


