document.addEventListener("DOMContentLoaded", function () {
    
    var emailInput = document.getElementById("Email");
    var passwordInput = document.getElementById("Password");

    var emailError = document.getElementById("EmailError");
    var passwordError = document.getElementById("PasswordError");

    
    emailInput.addEventListener("input", validateEmail);
    passwordInput.addEventListener("input", validatePassword);


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

    function validatePassword() {
        var passwordValue = passwordInput.value;
        var passwordPattern = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/;

        if (passwordValue === "") {
            passwordInput.classList.add("invalid");
            passwordError.textContent = "";
        } else if (!passwordPattern.test(passwordValue)) {
            passwordInput.classList.add("invalid");
            passwordError.textContent = "Your password should contain at least 8 characters, 1 uppercase, 1 lowercase, 1 number and 1 special character.";
        } else {
            passwordInput.classList.remove("invalid");
            passwordError.textContent = "";
        }
    }
});
    