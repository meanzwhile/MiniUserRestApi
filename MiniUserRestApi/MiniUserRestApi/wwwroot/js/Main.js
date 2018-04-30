$(document).ready(main);

function main() {
    registerButtonClickListener();
}

function registerButtonClickListener() {
    $("#registerButton").click(function () {
        console.log("clicked");
    });
}