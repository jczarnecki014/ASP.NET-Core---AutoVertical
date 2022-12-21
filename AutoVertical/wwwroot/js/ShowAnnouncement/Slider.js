class Slider{
    constructor(imgSrcList){
        this.ImgList = imgSrcList;
        this.MainPictureDiv = document.querySelector("#MainPicture");
        this.LeftArrow = document.querySelector("#LeftArrow");
        this.RightArrow = document.querySelector("#RightArrow");
        this.ImgthumbnailsDivs = document.querySelectorAll(".veh-img-thumb");
        this.ActiveImgIndex = 0;
        this.LoadGallery(this.ActiveImgIndex);
        this.SetEventsListener()
    }
    transition(){
            this.MainPictureDiv.style.opacity = "1.0"
            this.MainPictureDiv.style.transition = "opacity 1500ms"
    }
    LoadGallery(indexStart){
        let imgIndex = indexStart;
        this.transition()
        this.MainPictureDiv.src = this.ImgList[imgIndex];
        for(let i=0; i<6; i++){
            if(imgIndex>=this.ImgList.length){
                imgIndex = 0;
            }
            this.ImgthumbnailsDivs[i].src= this.ImgList[imgIndex];
            imgIndex++;
        }
        this.ImgthumbnailsDivs[0].classList.add("active");
    }
    SetEventsListener(){
        this.LeftArrow.addEventListener('click',()=>this.changeImg("left"))
        this.RightArrow.addEventListener('click',()=>this.changeImg("right"))
        this.ImgthumbnailsDivs.forEach((element) =>{
            element.addEventListener('click',()=>this.changeImg(element))
        })
    }
    changeImg(change){
        if(change=="right"){
            if(this.ActiveImgIndex == this.ImgList.length-1){
                this.ActiveImgIndex = 0;
            }
            else{
                this.ActiveImgIndex++; 
            }
        }
        else if(change=="left"){
            if(this.ActiveImgIndex == 0){
                console.log(this.ImgList.length-1)
                this.ActiveImgIndex = (this.ImgList.length-1);
            }else{
                this.ActiveImgIndex--;
            }
        }
        else{
            this.ImgList.forEach(element=>{
                if(change.src.includes(element)){
                   this.ActiveImgIndex = this.ImgList.indexOf(element)
                }
            })
        }
        this.LoadGallery(this.ActiveImgIndex)
    }
}
let ImgArray = []
let tempIMGDirectory = "/image/tempAnnouncement/"
const vehicleId = window.location.search.substring(4)
$.getJSON(`/customer/Announcement/GetGallery?id=${vehicleId}`,function(values){
    values.data.forEach(element => {
        ImgArray.push(tempIMGDirectory+element.name);
    });
    let slider = new Slider(ImgArray);
});

