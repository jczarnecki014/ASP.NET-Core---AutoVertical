class MiniPreview{
    static ActiveEquipmentArray = [];
    static EquipmentToggle = false;
    static DetailsTogglerFlag = false;
    constructor(){
        this.miniPreviewInputsList = document.querySelectorAll(".miniPreviewInputs");
        this.infoEquipmentList = document.querySelectorAll(".miniPreviewEquipment");
        this.infoList = document.querySelectorAll(".miniPreviewInfo");
        this.EquipmentListId = 0;
    }
    setEventListener(){
        document.querySelector("#VehicleSelector").addEventListener("change",(e)=>this.changeVehicle(e.target.value))
        this.infoList.forEach(element => {
            element.addEventListener('change',(e)=>this.updateSelectAndTextInputs(e))
        });
        this.infoEquipmentList.forEach(element => {
            element.addEventListener('change',(e)=>this.updateEquipment(e))
        });
    }
    changeVehicle(vehicleName){
        this.setGallery(vehicleName)
        this.setDefaultMiniPreview();
        this.ClearForm();
    }
    ClearForm(){
        const everyInputs = document.querySelectorAll("input")
        const textArea = document.querySelector("textarea.miniPreviewInfo");
        const imgOutput = document.querySelector("#output");
        const filesInput = document.querySelector("#filesInput");
        filesInput.value = null;
        imgOutput.innerHTML = "";
        textArea.value = "";
        this.EquipmentListId = 0; 
        MiniPreview.ActiveEquipmentArray = [];
        everyInputs.forEach(element=>{
            if(element.type == "text" || element.type == "number"){
                element.value = "";
            }
            else if(element.type == "checkbox"){
                element.checked = false;
                element.dataset.Id = "";     
            }
        })
    }
    static DetailsToggler(e){
        const element = document.querySelector(`#${e}`)
        const opacityDetails = document.querySelectorAll(".opacityDetail");
        if(element.style.display == ''){
            element.style.display = "none";
            MiniPreview.DetailsTogglerFlag = false;
            opacityDetails[0].style.opacity = 0.5;
            opacityDetails[1].style.opacity = 0.2;
        }
        else{
            element.style.display = '';
            MiniPreview.DetailsDetailsTogglerFlag = true;
            opacityDetails[0].style.opacity = 1;
            opacityDetails[1].style.opacity = 1;
        }
    }
    setDefaultMiniPreview(){
        this.miniPreviewInputsList[4].textContent = "Title";
        this.miniPreviewInputsList[5].textContent = "Year";
        this.miniPreviewInputsList[6].textContent = "Milage";
        this.miniPreviewInputsList[7].textContent = "Fuel";
        this.miniPreviewInputsList[8].textContent = "Body";
        this.miniPreviewInputsList[9].textContent = "Price";
        this.miniPreviewInputsList[10].textContent = "";
        this.miniPreviewInputsList[11].textContent = "";
        this.miniPreviewInputsList[12].textContent = "Private person";
        this.miniPreviewInputsList[13].textContent = "car";
        for(let i=14; i<=28; i++){
            this.miniPreviewInputsList[i].textContent = "";
        }
        this.miniPreviewInputsList[29].innerHTML = "";
        this.miniPreviewInputsList[30].textContent = "";
        this.miniPreviewInputsList[31].textContent = "Your Name";
        this.miniPreviewInputsList[32].textContent = "Your Phone number";
        this.miniPreviewInputsList[33].textContent = "Your Adress";
    }
    setGallery(vehicleName,VehicleImgSource){
        function setPathArray(path){
            VehicleImgSource = [`${path}exampleVehicle1.jpg`,`${path}exampleVehicle2.jpg`, `${path}exampleVehicle3.jpg`,`${path}exampleVehicle4.jpg`]
        }
        let path
        switch (vehicleName){
            case 'car':
                path = '/image/CreateAnnouncement/MiniPreview/Cars/';
                setPathArray(path)
                break;
            case 'motorcycle':
                path = '/image/CreateAnnouncement/MiniPreview/Motorcycle/';
                setPathArray(path)
                break;
            case 'truck':
                path = '/image/CreateAnnouncement/MiniPreview/Trucks/';
                setPathArray(path)
                break;
        }
            const imgContainer = document.querySelector(".carousel-inner");
            imgContainer.innerHTML = "";
            let firstChild = true;

            VehicleImgSource.forEach(element => {
                const div = document.createElement("div");
                if(firstChild == true){
                    div.className="carousel-item active";
                    firstChild = false;
                }
                else{
                    div.className="carousel-item";
                }
                const img = document.createElement("img");
                img.className = "miniPreviewInputs d-block w-100";
                img.src = element;
                img.style.maxHeight = 250 + "px"
                img.style.minHeight = 250 + "px"
                div.appendChild(img);
                imgContainer.appendChild(div);
            });
        }
 
    updateSelectAndTextInputs(event){
        if(event.target.id == "RegDay" || event.target.id == "RegMon" || event.target.id == "RegYear"){;
            if(this.infoList[4].value != "" && this.infoList[5].value != "" && this.infoList[6].value != ""){
                this.miniPreviewInputsList[23].textContent = this.infoList[4].value + "/" + this.infoList[5].value + "/" + this.infoList[6].value
                return;
            }
        }
        this.miniPreviewInputsList.forEach(element => {
            if(event.target.id == element.dataset.element){
                if(event.target.value == "-- Select --"){
                    element.textContent = "empty";
                }
                else if(event.target.id=="Price"){
                    element.textContent = event.target.value + " PLN";
                }
                else if(event.target.id == "Milage"){
                    element.textContent = event.target.value + " KM";
                }
                else if(event.target.id == "Power"){
                    element.textContent = event.target.value + " KM";
                }
                else if(event.target.id == "Description"){
                    element.textContent = event.target.value.substring(0,4000);
                }
                else if(event.target.type == "checkbox"){
                    if(event.target.checked  == true){
                        element.textContent = event.target.dataset.value;
                    }
                    else{
                        element.textContent = "";
                    }
                }
                else{
                    element.textContent = event.target.value;
                }
            }
        });
    }
    updateEquipment(event){
        const i = `<i class="bi bi-check-circle"></i>`;
        if(event.target.checked == true){
            event.target.dataset.Id = this.EquipmentListId;

            let div = document.createElement("div");
            div.classList.add("col-12");
            div.innerHTML = `${i} ${event.target.dataset.value}`
            div.dataset.Id = this.EquipmentListId;
            this.EquipmentListId++;
            MiniPreview.ActiveEquipmentArray.push(div);
        }
        else{
            MiniPreview.ActiveEquipmentArray.forEach(element=>{
                if(element.dataset.Id == event.target.dataset.Id){
                    event.target.dataset.Id = "";
                    let index = MiniPreview.ActiveEquipmentArray.indexOf(element);
                    MiniPreview.ActiveEquipmentArray.splice(index,1);
                }
            })
        }
        MiniPreview.refreshContainer(10);
    }
    static refreshContainer(number){
        if(number == "toggle"){
            if(MiniPreview.EquipmentToggle == false){
                number = 1000;
                MiniPreview.EquipmentToggle = true;
            }
            else{
                number = 10;
                MiniPreview.EquipmentToggle = false;
            }
        }
        let container = document.querySelector("#equipmentContainer");
        container.innerHTML = "";
        let NumberOfEquipments = 1;
        MiniPreview.ActiveEquipmentArray.forEach(element =>{
            element.style.opacity = 1;
            if(NumberOfEquipments <= number){
                if(NumberOfEquipments == 9 && MiniPreview.EquipmentToggle !=true ){
                    element.style.opacity = 0.5;
                }
                else if(NumberOfEquipments == 10 && MiniPreview.EquipmentToggle !=true){
                    element.style.opacity = 0.2;
                }
                NumberOfEquipments++;
                container.appendChild(element);
                }
            })
    }
}
//get form inputs and miniPreview inputs + Set events listener

//Create and inicialize mini preview
let miniPreview = new MiniPreview();
miniPreview.setEventListener();
miniPreview.changeVehicle('car');


