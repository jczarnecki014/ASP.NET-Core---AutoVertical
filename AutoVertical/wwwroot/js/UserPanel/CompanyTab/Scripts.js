//Company list
let companysList;
//Get CompanyContainer
const companysContainer = document.querySelector("#companysContainer") //If url doesn't contain "OptionalArg=Search" companyContainer = null

//Get searchCompany button = 

//Only if url contain "OptionalArg=Search" dispaly company filter 
if(companysContainer != null){
    //Prepare company card

    function prepareCompanyDiv(logoSrc,CompanyName,CompanyDesc){
        const divTemplate = `
            <div class="card mb-5" style="width: 18rem;">
                <img src="${logoSrc}" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title">${CompanyName}</h5>
                    <p class="card-text">${CompanyDesc.length > 200 ? CompanyDesc.substring(0, 200) + "...":"false"}</p>
                    <a href="#" class="btn btn-primary">Ask to join</a>
            </div>
                    `
            return divTemplate;
    }

    //Load companys on the document

    function DisplayCompanys(data){
            companysContainer.innerHTML = "";
            data.forEach(element => {
                const div = document.createElement("div");
                div.className="col-lg-3";
                div.innerHTML = prepareCompanyDiv(element.logoSrc,element.name,element.description)
                companysContainer.appendChild(div)
            });
    }


    //Get every companys from db

    $.getJSON("/Customer/Company/GetCompanyList",function(companys){
        DisplayCompanys(companys)
        companysList = companys;
    })

    //Company search input
    const searchInput = document.querySelector("#companySearch");

    searchInput.addEventListener("input",function(e){
        let CompanyFilter = companysList.filter(function(el){
            return el.name.includes(e.target.value)
        })
        DisplayCompanys(CompanyFilter)
    })
}

//If url doesn't contain OptionalArg and user click on the "search company" reload page and add optionalArg = "search"
function SetOptionalArg(){
    let url = `/Customer/UserProfile?tab=CompanyTab&OptionalArg=Search`
    window.location=url;
}

