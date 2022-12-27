class AdditionalFilters{
    constructor(AdditionalFiltersDiv){
        this.AdditionalFiltersDiv = [...AdditionalFiltersDiv];
        this.CurrentlyActive;
    }
    ShowDiv(e){
        console.log(e)
        if(this.CurrentlyActive != null){
            this.CurrentlyActive.hidden = true;
        }
        var found = this.AdditionalFiltersDiv.find(function(element){
            return element.id == e.currentTarget.id;
        })
        if(this.CurrentlyActive != found){
            found.hidden = false;
            this.CurrentlyActive = found;
        }
        else{
            this.CurrentlyActive = null;
        }
        
    }
}

