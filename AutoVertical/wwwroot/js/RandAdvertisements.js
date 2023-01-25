
class RandAdvertisement{
    constructor(largeAdvert,mediumAdvert,smallAdvert){
        this.largeAdvert = largeAdvert,
        this.mediumAdvert = mediumAdvert,
        this.smallAdvert = smallAdvert
    }
    setAdverts(advertaisments,size){

        let DivsArrayLength;
        let sizeAdverts;
        switch (size){
            case 'large':
                DivsArrayLength = this.largeAdvert.length
                sizeAdverts = this.largeAdvert;
            break;
            case 'medium':
                DivsArrayLength = this.mediumAdvert.length
                sizeAdverts = this.mediumAdvert;
            break;
            case 'small':
                DivsArrayLength = this.smallAdvert.length
                sizeAdverts = this.smallAdvert;
                console.log(sizeAdverts)
            break;
        }
        const advertisementsCount = advertaisments.length
        const randedIndexs = [];
        let randedIndex = null;
        if( DivsArrayLength > 0)
        {
            sizeAdverts.forEach(element => {
                if(advertisementsCount == 0){
                    element.src = `\\image\\advertisements\\${size}\\Default.png`
                    element.parentElement.href= "/Customer/Advertisement/Configurator"
                }
                else{
                    let condition = true;
                    while(condition){
                        randedIndex = Math.floor(Math.random() * advertisementsCount )
                        if(randedIndexs.includes(randedIndex)){
                            if(randedIndexs.length >= advertaisments.length){
                                element.src = `\\image\\advertisements\\${size}\\Default.png`
                                element.parentElement.href= "/Customer/Advertisement/Configurator"
                                break;
                            }
                        }
                        else{
                            randedIndexs.push(randedIndex);
                            let randedAdvertisement = advertaisments[randedIndex];
                            element.src = randedAdvertisement.imageSrc
                            element.parentElement.href= randedAdvertisement.url
                            condition = false;
                        }
                    }
                }
            });
        }
        else{
            console.error("Divs array is empty !")
        }

    }
}