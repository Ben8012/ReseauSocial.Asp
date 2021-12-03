//###############################################################################################
//######################## VARIABLES GLOBALES DE LA SESSION DE MESSAGERIE #######################
var LIST_USERS = []; // Liste de tous les utilisateurs (ojets User)
var LIST_CONTACTS = [];// Liste de tous les contacts (ceux qui ont de messages avec moi) (ojets Contact)
var LIST_MESSAGES = [];// Liste des messages avec le contact sélectionné (ojets Message)


//###############################################################################################
//######################## CREATION ET  DEMARRAGE DE LA CONNECTION ##############################
// 1 ==> Création de la connection
var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

// 2 ==> Démarrer la connection
connection.start()
    .then(() => {// Si la connection est établie avec succès
        console.log("Connexion OK : appel par " + curentUserId + " receveur est " + otherUserId);
        
        // 3 ==> Envoyer une requête de récupération des contacts au serveur
        connection.invoke("GetListContact", curentUserId)
            .then(() => {// Si l'envoi de la requête a réussi
                console.log("GetListContact OK")
                //  Envoyer une requête de récupération des utilisateurs au serveur
                connection.invoke("GetAllUsers", curentUserId)
                    .then(() => {// Si l'envoi de la requête a réussi
                        console.log("GetAllUsers OK")
                    })
            })
            .catch((error) => {// En cas d'échec du point 3
                console.log(error)
            })


        if (otherUserId > 0) {// Si un contact est sélectionné
            connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
                .then(() => {
                    console.log("GetMessageBetweenToUsers OK")
                })
                .catch((error) => {
                    console.log(error)
                })
        }
        else {// Si il n'y a pas de contact sélectionné
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
    .catch((error) => {// En cas d'échec de connection
        console.log(error)
        document.getElementById("submitButton").disabled = true
    })


//###############################################################################################
//######################## GESTION DES CLICK DE BOUTONS ##############################
// Le bouton d'envoi de nouveau message
document.getElementById("submitButton").addEventListener("click", (event) => {
    event.preventDefault()

    var message = document.getElementById("message").value
    console.log(message)
    connection.invoke("SendMessage", curentUserId, otherUserId, message)
        .catch((error) => {
            console.log(error)
        })
})
// click sur le boutton nouveau message vers utilisateur
document.getElementById("NewMessageButton")?.addEventListener("click", (event) => {
    event.preventDefault()

    //montrer le panneau d'affiches des utilisateurs
    //$('#listUsers').addClass("active");
    document.getElementById("listUsers").style.display = "block"
    document.getElementById("listContact").style.display = "none"
})

    

//###############################################################################################
//######################## OPERATION A FAIRE A LA RECEPTION D'UN MESSAGE
connection.on("ReceiveMessage", (messageJson) => {
    console.log(messageJson)
    var message = JSON.parse(messageJson)
    var senderName = message.UserSend == curentUserId ? 'Vous' : `${message.Sender.LastName} ${message.Sender.FirstName}`;
    var li = document.createElement("li")
    li.setAttribute("class", "list-group-item mt-2")
    li.textContent = `${senderName} : ${message.Content} le ${message.SendDate}`

    document.getElementById("listMessage").appendChild(li)
})



//###############################################################################################
//######################## OPERATION A FAIRE A LA RECEPTION DE TOUS LES MESSAGES AVEC UN CONTACT
connection.on("MessageBetweenToUsers", (listMessagesJson, userId1, userId2) => {
    if (curentUserId == userId1 || curentUserId == userId2  ) {
        console.log(listMessagesJson)
        LIST_MESSAGES = JSON.parse(listMessagesJson)
        // Vider d'abord la liste d'affichage des messages
        $('#listMessage').empty();
        for (var i = 0; i < LIST_MESSAGES.length; i++) {
            var message = LIST_MESSAGES[i];
            var senderName = message.UserSend == curentUserId ? 'Vous' : `${message.Sender.LastName} ${message.Sender.FirstName}`;
            var li = document.createElement("li")
            li.setAttribute("class", "list-group-item mt-2")
            li.innerHTML = `<strong>${senderName}</strong> : ${message.Content} le ${message.SendDate}`

            document.getElementById("listMessage").appendChild(li)
        }
    }
})



//###############################################################################################
//########################  OPERATION A FAIRE A LA RECEPTION DE LA LISTE DES CONTACTS ###########
connection.on("ReceiveListContact", (listContactJson, userId1) => {
    if (curentUserId == userId1) {
        console.log("ReceiveListContact OK");
        console.log(listContactJson);
        LIST_CONTACTS = JSON.parse(listContactJson);
        var htmlContact = "";
        // nombre de messages non lus
        var NewMessageCount = 0;
        for (var i = 0; i < LIST_CONTACTS.length; i++) {
            var contact = LIST_CONTACTS[i];
            // Incrémenter le nombre de messages non lus
            NewMessageCount += contact.CountMessageNotRead;
            // Ajouter l'élément d'affichage HTML du contact courant
            htmlContact += '<a class="m-2 d-flex w-100 justify-content-between list-group-item list-group-item-action" data-toggle="list" data-id="'
                + contact.Id + '">  <p>' + contact.LastName + ' ' + contact.FirstName + '</p>'
                + (contact.CountMessageNotRead > 0 ? '<span class="badge badge-success ">' + contact.CountMessageNotRead + '</span>' : " ") + ' </a>';
        }
        var divContact = document.getElementById("listContact");
        // Remplir le panneau d'Affichage des contacts
        divContact.innerHTML = htmlContact;
        // Remplir le compteur d'affichage des messages non lus
        document.getElementById("NewMessageCountMenu").innerHTML = NewMessageCount;

        // Gestion des Click sur chaque Contact de la liste   
        $('#listContact > a').on('click', function (e) {
            // Empêcher l'action par défaut du lien qui devrait envoyer vers une adresse        
            e.preventDefault();
            // Récupération de l'ID de l'utilisateur sélectionné       
            otherUserId = parseInt($(this).data("id"));
            console.log(otherUserId);
            //Remplir les entêtes pour les messages        
            $('#messageTitle').html('Discussion avec ' + $(this).find('>p').html());
            $('#messageTitle').data("id", otherUserId);

            console.log("Invoque GetMessageBetweenToUsers avec otherUserId = " + otherUserId + " et curentUserId = " + curentUserId);
            // Envoi de la requête de récupération des messages échangés avec ce contact au serveur        
            connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
                .then(() => {
                    console.log("GetMessageBetweenToUsers OK")
                })
                .catch((error) => {
                    console.log(error)
                })
        });
    }
})


  
//########################  OPERATION A FAIRE A LA RECEPTION DE LA LISTE dE TOUS LES UTILISATEURS ###########
connection.on("ReceiveListUsers", (listContactJson, userId1) => {
    if (curentUserId == userId1) {
        console.log("ReceiveListUsers OK");
        console.log(listContactJson);
        LIST_USERS = JSON.parse(listContactJson);
        var htmlContact = "";
       
       
        for (var i = 0; i < LIST_USERS.length; i++) {
            var contact = LIST_USERS[i];
           
            // Ajouter l'élément d'affichage HTML du contact courant
            htmlContact += '<a class="m-2 d-flex w-100 justify-content-between list-group-item list-group-item-action" data-toggle="list" data-id="'
                + contact.Id + '">  ' + contact.LastName + ' ' + contact.FirstName +  ' </a>';
        }
        var divContact = document.getElementById("listUsers");
        // Remplir le panneau d'Affichage des contacts
        divContact.innerHTML = htmlContact;

        // Gestion des Click sur chaque Contact de la liste   
        $('#listUsers > a').on('click', function (e) {
            // Empêcher l'action par défaut du lien qui devrait envoyer vers une adresse        
            e.preventDefault();
            // Récupération de l'ID de l'utilisateur sélectionné       
            otherUserId = parseInt($(this).data("id"));
            console.log(otherUserId);
            //Remplir les entêtes pour les messages        
            $('#messageTitle').html('Discussion avec ' + $(this).html());
            $('#messageTitle').data("id", otherUserId);
            //cacher le contact cliqué
           /* $('#listUsers').removeClass("active");*/
            document.getElementById("listUsers").style.display = "none"
            document.getElementById("listContact").style.display = "block"
            console.log("Invoque GetMessageBetweenToUsers avec otherUserId = " + otherUserId + " et curentUserId = " + curentUserId);
            // Envoi de la requête de récupération des messages échangés avec ce contact au serveur        
            connection.invoke("GetMessageBetweenToUsers", curentUserId, otherUserId)
                .then(() => {
                    console.log("GetMessageBetweenToUsers OK")
                })
                .catch((error) => {
                    console.log(error)
                })
        });
    }
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




