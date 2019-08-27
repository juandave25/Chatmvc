$(function () {

    var chatHub = $.connection.chatHub;

    var userName;
    do {
        userName = prompt("Insert your nickname: ");
    } while (userName == null || userName == "");



    chatHub.client.updateUsers = function (userCount, userList) {
        $("#onlineUsersCount").text('Online users:' + userCount);
        $("#userList").empty();
        userList.forEach(function (userName) {
            $("#userList").append('<li>' + userName + '</li>');
        });
    };

    chatHub.client.updateRooms = function (roomCount, roomList) {
        $("#RoomCount").text('Chat rooms: ' + roomCount);
        $("#RoomList").empty();
        roomList.forEach(function (groupName) {
            $("#RoomList").append('<li><input type="button" class="btn btn-info" id="' + groupName + '" value="' + groupName + '" /></li>');
        });
    };


    chatHub.client.showConnected = function (users) {
        $('#usersList').empty();
        users.forEach(function (value) {
            $('#usersList').append('<li>' + value.nickname + '</li>');
        });
    };

    chatHub.client.broadcastMessage = function (userName, message) {
        $('#messagesArea').append('<li><strong>' + userName + '</strong>: ' + message);
    };

    chatHub.client.alertify = function (userName) {
        alert("the nickname " + userName + " already exists, try with another please");
        do {
            userName = prompt("Insert your nickname: ");
        } while (userName == null || userName == "");
    };


    $.connection.hub.start().done(function () {
        chatHub.server.connect(userName);
    });


    $('#btnSendMessage').click(function () {
        var message = $('#userMessage').val();
        chatHub.server.send(message);
        $('#userMessage').val("");
    });

    $(document).on('click', '#Room1', function () {
        chatHub.server.listUserRoom('Grupo1');
    });

});