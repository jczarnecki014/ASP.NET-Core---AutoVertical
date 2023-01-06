
function SetBackgroundHover(elements,imageVerticallySrc,imageHorizontallySrc,imageSquareSrc){
    let pictureSrc;
    elements.forEach(element=>{

        element.addEventListener("mouseover",e=>{
            pictureSrc = e.target.src;
            if(e.target.width < e.target.height && imageVerticallySrc != null)
            {
                e.target.src = imageVerticallySrc;
            }
            else if(e.target.width == e.target.height && imageSquareSrc != null){
                e.target.src = imageSquareSrc;
            }
            else if(imageHorizontallySrc !=null)
            {
                e.target.src = imageHorizontallySrc;
            }
        });
        element.addEventListener("mouseleave",e=>{
            e.target.src = pictureSrc;
        });
    })
}
