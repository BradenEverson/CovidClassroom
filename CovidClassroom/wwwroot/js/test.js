var connection = new signalR.HubConnectionBuilder().withUrl("/ClassHub").build();
connection.on("Correct", function (face1, ans1, ans2, ans3, ans4, correct, guid, email) {
    alert("Correct! You get 15 more minutes on your device");
    /*document.getElementById("title").innerHTML = face1;
    document.getElementById("ans1").innerHTML = ans1;
    document.getElementById("ans2").innerHTML = ans2;
    document.getElementById("ans3").innerHTML = ans3;
    document.getElementById("ans4").innerHTML = ans4;
    document.getElementById("ans1").addEventListener("click", sendAnswer(ans1, correct, guid, email));
    document.getElementById("ans1").addEventListener("click", sendAnswer(ans2, correct, guid, email));
    document.getElementById("ans1").addEventListener("click", sendAnswer(ans3, correct, guid, email));
    document.getElementById("ans1").addEventListener("click", sendAnswer(ans4, correct, guid, email));*/
});

connection.start().then(function () {

}).catch(function (err) {
    return console.error(err);
});

function sendAnswer(answer, correct, guid, email) {
    connection.invoke("Answer", answer, correct, guid, email).catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
}