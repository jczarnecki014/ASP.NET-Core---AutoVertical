
class FormHandler{
    constructor([...selectList]){
        this.specificSelectList = selectList.filter(element=>element.classList.contains("specific"));
        this.commonSelectList = selectList.filter((element)=>{
            return !this.specificSelectList.includes(element);
        })
        this.activeInputsOfVehicle = document.querySelectorAll(".car");
    }
    static FileInputIsEmpty(){
        if(document.querySelector("#filesInput").value == ""){
            Swal.fire({
                icon: 'error',
                title: 'Files ERROR',
                text: `The minimum number of images is 3 !`,
                footer: '<a href="">Why do I have this issue?</a>'
              })
              return false;
        }
        else{
            return true;
        }
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
    SetImgPiority(e){
        e.target.style.opacity = 0.5;
    }

    ShowUserIMG(e){

        if (window.File && window.FileReader && window.FileList && window.Blob) {
            let fileInputError = this.CheckFileValidation(e); 
            if(fileInputError == "" )
            {
                const files = e.target.files;
                const output = document.querySelector("#output");
                const imgSRC = [];
                const imgDiv = [];
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
                        div.classList.add('user-img-div');
                        // imgDiv.push(div);
                        const img = document.createElement("img");
                        img.classList.add("img-thumbnail");
                        img.src = imgFile.result;
                        imgSRC.push(img.src);
                        div.appendChild(img);
                        output.appendChild(div);
                        if(i == files.length-1){
                            new MiniPreview().setGallery('userVehicle',imgSRC)
                            // new ImgSequence(imgDiv).SetEventListener();
                        }
                    })
                    imgReader.readAsDataURL(files[i]);
                }
            }
            else{
                e.target.value = "";
                output.innerHTML = "";
                let activeVehicle = this.commonSelectList[0].value; // recive value from first input ( type of vehicle ) to change slider in minipreview
                new MiniPreview().setGallery(activeVehicle)
                Swal.fire({
                    icon: 'error',
                    title: 'Files ERROR',
                    text: `${fileInputError}`,
                    footer: '<a href="">Why do I have this issue?</a>'
                  })
            }
          } else {
            alert("Your browser does not support File API");
          }
    }
    CheckFileValidation(e){
            let Error = "";
            if(e.target.files.length > 12)
            {
                Error = "The maxium number of images is 12 !";
            }
            else if(e.target.files.length < 3)
            {
                Error = "The minimum number of images is 3 !";
            }
            var files = [...e.target.files]
            files.forEach(file => {
                if(!file.name.includes(".png") && !file.name.includes(".jpg") && !file.name.includes(".jpeg") )
                {
                    Error = "AutoVertical allow only images. Please select only (.png .jpg .jpeg) files";
                    
                }
                else if(file.size > 1572864)
                {
                    Error = "File size is greater than 1.5MB please reduce size of the images by decrease resolution";
                }
            });
            return Error
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
            defaultOption.disabled = true;
            defaultOption.selected = true;

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

// class ImgSequence{
//     constructor(imgDivs){
//         this.imgDivs = imgDivs;
//     }
//     SetEventListener(){
//         this.imgDivs.forEach(element=>
//             element.addEventListener('mousedown',e=>this.OnDivMouseDown(e))
//             )
//         this.imgDivs.forEach(element=>
//             element.addEventListener('mouseup',e=>this.OnDivMouseUp(e))
//             )
//     }
//     OnDivMouseDown(e){
//         e.target.style.opacity = 0.5;
//     }
//     OnDivMouseUp(e){
//         e.target.style.opacity = 1;
//     }
// }


//Main
selectList = document.querySelectorAll("select");
formHandler = new FormHandler(selectList);
formHandler.SetEventListener();
formHandler.SetVehicle("car"); // set first vehicle


