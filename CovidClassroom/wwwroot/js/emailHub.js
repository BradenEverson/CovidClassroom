document.getElementById("search").disabled = true;

var connection = new signalR.HubConnectionBuilder().withUrl("/ClassHub").build();
connection.on("StudentAdded", function (id) {

});

connection.start().then(function () {
    document.getElementById("search").disabled = false;
}).catch(function (err) {
    return console.error(err);
});

function SendCLientInfo(id, studentName) {
    connection.invoke("SendClassBoundStudent", id, studentName).catch(function (err) {
        return console.error(err);
    });
    event.preventDefault();
}