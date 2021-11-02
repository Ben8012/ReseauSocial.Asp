var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();
var compteurArrive = 0;

connection.start()
    .then(() => {
        console.log("Connection tunnel OK : " + articleId);
        console.log("Connexion OK : appel par " + curentUserId + " receveur est " + articleId);
        connection.invoke("GetComments", articleId)
            .catch((error) => {
                console.log(error);
            });
    })
    .catch((error) => {
        console.log(error);
        document.getElementById("submitButton").disabled = true;
    });

document.getElementById("submitButton").addEventListener("click", (event) => {
    event.preventDefault();
  
    // Récupération du commentaire écrit par l'utilisateur courant
    var comment = document.getElementById("comment").value;
    console.log(curentUserId + " : " + comment);
    connection.invoke("SendComment", comment, articleId, curentUserId)
        .then(() => {
            document.getElementById("comment").value = "";
        })
        .catch((error) => {
            console.log(error);
        });
});

connection.on("ReceiveComments", (comments) => {
    console.log(comments);
    var listComments = JSON.parse(comments);
    var ul = document.getElementById("listMessages");
    for (var i = 0; i < listComments.length; i++) {
        var li = document.createElement("li");
        li.setAttribute("class", "list-group-item m-2");
        var a = document.createElement("a");
        a.setAttribute("href", `/User/GetUser/${listComments[i].UserId}`);
        a.textContent = `${listComments[i].AuthorName}`;
        li.appendChild(a);
        li.appendChild(document.createTextNode(` : ${listComments[i].Message} le ${listComments[i].Date}`));
        ul.appendChild(li);
    }
});

connection.on("ReceiveComment", (comment, UserId, name) => {
    var ul = document.getElementById("listMessages");
    var li = document.createElement("li");
    li.setAttribute("class", "list-group-item m-2");
    var a = document.createElement("a");
    a.setAttribute("href", `/User/GetUser/${UserId}`);
    a.textContent = `${name}`;
    li.appendChild(a);
    li.appendChild(document.createTextNode(` : ${comment} `));
    ul.insertBefore(li, ul.firstChild);
});

connection.on("ReceiveOthersMessage", (conversation) => {
    var li = document.createElement("li");
    li.setAttribute("class", "list-group-item m-2");
    li.textContent = `${conversation}`;
    document.getElementById("listMessages").appendChild(li);
});