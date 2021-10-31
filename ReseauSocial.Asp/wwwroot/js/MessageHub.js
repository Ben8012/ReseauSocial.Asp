
var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();


connection.start()
    .then(() => {
        console.log("Connexion OK : appel par " + curentUserId + " receveur est " + otherUserId);
        connection.invoke("GetListContact", curentUserId)
            .then(() => { console.log("GetListContact OK") })
            .catch((error) => { console.log(error) })


        if (otherUserId > 0) {
            connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
                .then(() => { console.log("GetMessageBetweenToUsers OK") })
                .catch((error) => {
                    console.log(error)
                })
        }
        else {
            // Gestion des Click sur chaque Contact de la liste   
            $('#listContact > a').on('click', function (e) {
                // Empêcher l'action par défaut du lien qui devrait envoyer vers une adresse        
                e.preventDefault();
                // Récupération de l'ID de l'utilisateur sélectionné       
                otherUserId = parseInt($(this).data("id"));
                console.log(otherUserId);
                //Remplir les entêtes pour les messages        
                $('#messageTitle').html('Discussion avec ' + $(this).html());
                $('#messageTitle').data("id", otherUserId);
               
                console.log("Invoque GetMessageBetweenToUsers avec otherUserId = " + otherUserId + "et curentUserId = " + curentUserId);
                // Envoi de la requête de récupération des messages échangés avec ce contact au serveur        
                connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
                    .then(() => { console.log("GetMessageBetweenToUsers OK") })
                    .catch((error) => {
                        console.log(error)
                    })
            });
        }
       

    })
    .catch((error) => {
        console.log(error)
        document.getElementById("submitButton").disabled = true
    })

document.getElementById("submitButton").addEventListener("click", (event) => {
    event.preventDefault()

    var message = document.getElementById("message").value
    console.log(message)
    connection.invoke("SendMessage", curentUserId, otherUserId, message)
        .catch((error) => {
            console.log(error)
        })
})


connection.on("ReceiveMessage", (messageJson) => {
    console.log(messageJson)
    var message = JSON.parse(messageJson)
    var senderName = message.UserSend == curentUserId ? 'Vous' : `${message.Sender.LastName} ${message.Sender.FirstName}`;
    var li = document.createElement("li")
    li.setAttribute("class", "list-group-item")
    li.textContent = `${senderName} : ${message.Content} le ${message.SendDate }`

    document.getElementById("listMessage").appendChild(li)
})

connection.on("MessageBetweenToUsers", (listMessagesJson) => {
    console.log(listMessagesJson)
    var listMessages = JSON.parse(listMessagesJson)
    for (var i = 0; i < listMessages.length; i++) {
        var message = listMessages[i];
        var senderName = message.UserSend == curentUserId ? 'Vous' : `${message.Sender.LastName} ${message.Sender.FirstName}`;
        var li = document.createElement("li")
        li.setAttribute("class", "list-group-item")
        li.textContent = `${senderName} : ${message.Content} le ${message.SendDate}`

        document.getElementById("listMessage").appendChild(li)
    }

})

connection.on("ReceiveListContact", (listContactJson) => {
    console.log("ReceiveListContact OK");
    console.log(listContactJson);
    var listContact = JSON.parse(listContactJson);
    var divContact = document.getElementById("listContact");
    var htmlContact = "";
    for (var i = 0; i < listContact.length; i++) {
        var contact = listContact[i];
        htmlContact += '<a class="m-2 d-flex w-100 justify-content-between list-group-item list-group-item-action" data-toggle="list" data-id="' + contact.Id + '">  <p>' + contact.LastName + ' ' + contact.FirstName + '</p>' + (contact.CountMessageNotRead > 0 ?'<span class="badge badge-success ">' + contact.CountMessageNotRead + '</span>' : " " ) + ' </a>';
    }
    divContact.innerHTML = htmlContact

    // Gestion des Click sur chaque Contact de la liste   
    $('#listContact > a').on('click', function (e) {
        // Empêcher l'action par défaut du lien qui devrait envoyer vers une adresse        
        e.preventDefault();
        // Récupération de l'ID de l'utilisateur sélectionné       
        otherUserId = parseInt($(this).data("id"));
        console.log(otherUserId);
        //Remplir les entêtes pour les messages        
        $('#messageTitle').html('Discussion avec ' + $(this).html());
        $('#messageTitle').data("id", otherUserId);

        console.log("Invoque GetMessageBetweenToUsers avec otherUserId = " + otherUserId + "et curentUserId = " + curentUserId);
        // Envoi de la requête de récupération des messages échangés avec ce contact au serveur        
        connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
            .then(() => { console.log("GetMessageBetweenToUsers OK") })
            .catch((error) => {
                console.log(error)
            })

    });


})
    



/*
curentUserId
public int Id { get; set; }
        public string Content { get; set; }
        public int UserSend { get; set; }
        public int UserGet { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime? RecieveDate { get; set; }

        public UserBll Sender { get; set; }
        public UserBll Reciever { get; set; }
 a dit : ${listMessages[i].Content} le ${listMessages[i].SendDate}`
*/




