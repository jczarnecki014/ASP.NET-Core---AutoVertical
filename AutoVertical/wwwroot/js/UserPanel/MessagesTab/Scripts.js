//Active
let activeConversation;
let activeElement;

let LoadMessagesInterval;

//Conversations divs
const conversations = document.querySelectorAll(".conversationElements");

//Function to show user conversation

    //Get messages container
    const MessagesContainer = document.querySelector("#MessagesContainer");

function showUserCoversation(messages){
        //Clear MessagesContainer
        MessagesContainer.innerHTML = "";
        if(messages.length != 0)
        {
            messages.forEach(message => {
            //Take users id to differeentiate if user is sender ( Logged user messages should have a light blue backgorund and other align)
                const messageSenderUser = message.messageSenderUser.id;
                const LoggedUser = message.conversation.loggedUserId;

            //ROW
                const row = document.createElement("div")
                row.className = "row py-3"
            //IMG
                const imgDiv = document.createElement("div")
                imgDiv.className="col-1 d-flex align-items-center";

                const img = document.createElement("img")
                img.className = "rounded-circle p-2 img-fluid position-relative"
                img.src = message.messageSenderUser.avatarSrc;
            //MESSAGE
                const messageDiv = document.createElement("div")
                if(messageSenderUser == LoggedUser){
                    messageDiv.className = "col-10 p-3 rounded text-black"
                    messageDiv.style.backgroundColor = "#b7d1e9";
                }
                else{
                    messageDiv.className = "col-10 bg-white p-3 rounded text-secondary"
                }

                const messageText = document.createElement("p")
                messageText.className = "small"
                messageText.innerHTML = message.contents

                const messageDate = document.createElement("p")
                messageDate.className = "small text-end fw-bold"
                messageDate.textContent = new Date(message.date).toLocaleString()

            //JoinElements
            
            messageDiv.appendChild(messageText)
            messageDiv.appendChild(messageDate)
            imgDiv.appendChild(img);
            if(messageSenderUser == LoggedUser )
            {
                row.appendChild(messageDiv)
                row.appendChild(imgDiv); 
            }
            else{
                row.appendChild(imgDiv);
                row.appendChild(messageDiv)
            }
            MessagesContainer.appendChild(row)

            //Scroll Messages container on the bottom
                MessagesContainer.scrollTop = MessagesContainer.scrollHeight;

            });
        }
        else
        {
            ShowDefaultMessage();
            clearInterval(LoadMessagesInterval)
        }
}




//Load user conversation

    //Load conversations checked user

    function LoadUserConversation()
    {
        fetch(`/Customer/Messages/GetConversationMessages?ConversationId=${activeConversation}`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
            },
        })
        .then(response => response.json())
        .then(response => {
            showUserCoversation(response)
        })
    }



// TinyEditor init - third-party tool textArea
  tinymce.init({
    height: 200,
    placeholder: "Write your message",
    selector: "#messageTextArea",
    plugins: "emoticons",
    toolbar: "emoticons",
    toolbar_location: "bottom",
    menubar: false
  });




  //SendMessage after button "send" clickl
  const ConversationId = 3;
  const messageButton = document.querySelector("#messageButton");

  //Create message event
  messageButton.addEventListener("click", function(e){
        if(activeConversation != "noSelected"){
                const message = tinymce.get("messageTextArea").getContent();
                tinyMCE.activeEditor.setContent('');
                $.post( `/Customer/Messages/CreateMessage?ConversationId=${activeConversation}&content=${message}`, function( messages ) {
                    let soundEffect = new Audio(`/sounds/SendMessage.mp3`);
                    soundEffect.play()
                    showUserCoversation(messages)
                });
        }
        else{
            Swal.fire({
                icon: 'error',
                title: 'Firsytly you have to choose conversation',
                text: 'Before you send message, you should choose user from list or add him in advert section',
                footer: '<a href="">Why do I have this issue?</a>'
              })
        }
  } )
  
  function ShowDefaultMessage(){
    const rowDiv = document.createElement("div");
        rowDiv.className = "row d-flex justify-content-center align-items-center h-100";

    const colDiv = document.createElement("div");
        colDiv.className = "col-8";

    const h1Text = document.createElement("h1");
        h1Text.className = "text-center";
        h1Text.style.color = "#c6c6c6"
        h1Text.textContent = "We didn't found any message here.."

    const h4Text = document.createElement("h4");
        h4Text.className = "text-center";
        h4Text.style.color = "#c6c6c6"
        h4Text.textContent = "This user propably is waiting for your action"

    //Add headers to colum    
    colDiv.appendChild(h1Text);
    colDiv.appendChild(h4Text);
    //Add column to row
    rowDiv.appendChild(colDiv)
    MessagesContainer.appendChild(rowDiv)
  }

  //Choose specific conversation from list 

  conversations.forEach(conversation =>{
    conversation.addEventListener('click',function(e){
        if(e.currentTarget.dataset.convid != undefined){
            clearInterval(LoadMessagesInterval)

            activeUserConversationId = e.currentTarget.dataset.convid
            activeConversation = activeUserConversationId;

            LoadUserConversation()
            LoadMessagesInterval = setInterval(LoadUserConversation,4000)

            ChangeActive(e.currentTarget.dataset.convid)
        }
      })
  })

  //Change .active class function
  function ChangeActive(activeElementId){
    conversations.forEach(div =>{
        if(div.classList.contains("active")){
            div.classList.remove("active")
        }
        else if(div.dataset.convid == activeElementId){
            div.classList.add("active")
        }
    })
  }

  //Set first active conversation on page load
  activeElement = document.querySelector(".active");

  // 0 - aviable conversations
  if(activeElement == null){
    ShowDefaultMessage()
    activeConversation = "noSelected";
  }
  else{
    activeConversation = activeElement.dataset.convid
    LoadUserConversation()
    LoadMessagesInterval = setInterval(LoadUserConversation,6000)
  }



  //SetInterval to load latest messages





