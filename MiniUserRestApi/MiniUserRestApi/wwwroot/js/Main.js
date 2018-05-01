var apiKey = prompt("Enter Your Api Key Here", "Yes here");

$(document).ready(main);

function main() {
    getAllUser();
    homeButtonClickListener();
    registerButtonClickListener();
    registerUserClickListener();
}

function homeButtonClickListener() {
    $("#homeButton").click(function () {
        $("#registerPage").hide();
        $("#allUser").show();
        getAllUser();
    });
}

function registerButtonClickListener() {
    $("#registerButton").click(function () {
        $("#allUser").hide();
        $("#registerPage").show();
    });
}

function registerUserClickListener() {
    $("#register").click(function () {
        var username = $("#username").val();
        var email = $("#email").val();

        var data = {
            UserName: username,
            UserEmail: email
        }

        $.ajax({
            type: 'POST',
            url: '/api/User',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            headers: { 'x-api-key': apiKey },
            data: JSON.stringify(data),
            success: function () {
                var alertBox = $("#alertSuccess");
                alertBox.fadeIn();
                alertBox.text("Successfully registered the new user");
                closeAlertBox(alertBox);
                $("#allUser").show();
                $("#registerPage").hide();
                getAllUser();
            },
            error: function () {
                var alertBox = $("#alertFail");
                alertBox.fadeIn();
                alertBox.text("Something went wrong :(");
                closeAlertBox(alertBox);
            }
        })
    })
}

function closeAlertBox(alertBox) {
    window.setTimeout(function () {
        alertBox.fadeOut(300)
    }, 3000);
}

function getAllUser() {
    $.ajax({
        type: 'GET',
        url: '/api/User',
        dataType: 'json',
        headers: { 'x-api-key': apiKey },
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $("#userTable tbody tr").remove();
            for (i in result) {
                $("#userTable").append("<tr>" +
                "<td>" + result[i].id + "</td>" +
                "<td>" + result[i].userName + "</td>" +
                "<td>" + result[i].userEmail + "</td>" +
                "<td><button id='" + result[i].id + "' class='btn btn-danger deleteButton'>X</button></td>" +
                "</tr > ");

            }
            deleteUserButtonHandler();
        },
        error: function () {
            var alertBox = $("#alertFail");
            alertBox.fadeIn();
            alertBox.text("Something went terribly wrong :(");
            closeAlertBox(alertBox);
        }
    })
}
function deleteUserButtonHandler() {
    $(".deleteButton").click(function () {
        $.ajax({
            type: 'DELETE',
            url: '/api/User/' + this.id,
            headers: { 'x-api-key': apiKey },
            success: function (result) {
                var alertBox = $("#alertSuccess");
                alertBox.fadeIn();
                alertBox.text("Successfully deleted the user");
                closeAlertBox(alertBox);
                getAllUser();
            },
            error: function () {
                var alertBox = $("#alertFail");
                alertBox.fadeIn();
                alertBox.text("Something went wrong :(");
                closeAlertBox(alertBox);
            }
        })
        getAllUser();
    });
}