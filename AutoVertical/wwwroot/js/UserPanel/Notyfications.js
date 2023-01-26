//Create notyfication HTML
function GetNotyficationToHTML(id,userAvatar,userName, userSurname,event){
    return HTML = 
    `   <div class="col-3">
            <img class="rounded-circle p-2 img-fluid position-relative" src="${userAvatar}" />
            ${event == "NewMessage" ? "<i class='bi bi-chat-dots position-absolute text-primary'></i>":"<i class='bi bi-chat-heart-fill position-absolute text-danger'></i>"}
        </div>

        <div class="col-7 px-3">
            <div class="row">
                <div class="col-12">
                    <span class="fw-bolder">${userName} ${userSurname} Woźniak</span>
                </div>
                <div class="col-12">
                    <small class="text-secondary">
                    ${event == "NewMessage" ? "Hi, I have started a new conversation with you !":"I start follow your advert !</i>"}
                    </small>
                </div>
            </div>
        </div>
        <div class="col-2">
            <i class="romoveNotyficationBtn bi bi-x" data-id=${id}></i>
        </div>`
    
}

//Disable auto hidden dropdown after click in element inside
const NotyficationDropDown = document.querySelector(".dropdown-menu");
NotyficationDropDown.addEventListener('click',function(e){
    e.stopPropagation()
})


//Max amount notyfication in container
let maxNumberOfNotyficationInDropDown = 5;
let notyficationIndex = 0;


//Load remove notyfication buttons witch event
function SetRemoveEventsButtons(){
    document.querySelectorAll(".romoveNotyficationBtn").forEach(button => {
        button.addEventListener('click',function(e){
            const removeNotyficationUrl = `/Customer/Notyfication/RemoveUserNotyfication?id=${e.target.dataset.id}`
            $.post(removeNotyficationUrl,function(){
                ShowNotyfications()
            });
        })
    })
}

//Set notyfication bell icon
function ShowNotyficationBell(aviableNotyfications)
{
    const notyficationBellIcon = document.querySelector("#notyficationBellIcon");
    if(aviableNotyfications){ // value grather than 0 = true   less than 0 = false
        notyficationBellIcon.style.color = "#1dd1a1"; 
    }
    else{
        notyficationBellIcon.style.color = "#fff";
    }
}

///////////////////////////// Load user notyfications
    const notyficationContainer = document.querySelector("#notyficationContainer");
    const UserNotyficationsURL = "/Customer/Notyfication/GetUserNotyfications"


    function ShowNotyfications(){
        notyficationContainer.innerHTML = "";
        $.getJSON(UserNotyficationsURL,function(data){
            data.forEach(element => {
                if(notyficationIndex <maxNumberOfNotyficationInDropDown){
                    const row = document.createElement("div")
                    row.className="row pt-1 mb-2";
                    row.innerHTML = GetNotyficationToHTML(element.id,element.userOfEvent.avatarSrc,element.userOfEvent.name,element.userOfEvent.surname,element.event);
                    notyficationContainer.appendChild(row);
                }
                notyficationIndex++;
            });
            ShowNotyficationBell(notyficationIndex)
            notyficationIndex = 0;
            SetRemoveEventsButtons();
        })
    }

///////////////////////

///Initial

ShowNotyfications();
