document.addEventListener("DOMContentLoaded", function () {
    var nameInput = document.getElementById("Name");
    var emailInput = document.getElementById("Email");
    var messageInput = document.getElementById("MessageText");

    var emailError = document.getElementById("EmailError");
    var nameError = document.getElementById("NameError");     
    var messageError = document.getElementById("MessageError");    

    nameInput.addEventListener("input", validateName);
    emailInput.addEventListener("input", validateEmail);
    messageInput.addEventListener("input", validateMessage);

    function validateName() {
        var nameValue = nameInput.value.trim();
        if (nameValue.length < 2) {
            nameInput.classList.add("invalid");
            nameError.textContent = "Please enter at least two letters";
        } else {
            nameInput.classList.remove("invalid");
            nameError.textContent = "";
        }
    }

    function validateEmail() {
        var emailValue = emailInput.value.trim();
        var emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (emailValue === "") {
            emailInput.classList.add("invalid");
            emailError.textContent = "";
        } else if (!emailPattern.test(emailValue)) {
            emailInput.classList.add("invalid");
            emailError.textContent = "Please enter a valid email address";
        } else {
            emailInput.classList.remove("invalid");
            emailError.textContent = "";
        }
    }

    function validateMessage() {
        var messageValue = messageInput.value.trim();
        if (messageValue.length < 5) {
            messageInput.classList.add("invalid");
            messageError.textContent = "Please enter at least five letters";
        } else {
            messageInput.classList.remove("invalid");
            messageError.textContent = "";
        }
    }
});