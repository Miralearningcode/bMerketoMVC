document.addEventListener("DOMContentLoaded", function () {
    var firstNameInput = document.getElementById("FirstName");
    var lastNameInput = document.getElementById("LastName");
    var streetNameInput = document.getElementById("StreetName");
    var postalCodeInput = document.getElementById("PostalCode");
    var cityInput = document.getElementById("City");
    var emailInput = document.getElementById("Email");
    var passwordInput = document.getElementById("Password");
    var confirmPasswordInput = document.getElementById("ConfirmPassword");

    var firstNameError = document.getElementById("FirstNameError");
    var lastNameError = document.getElementById("LastNameError");
    var streetNameError = document.getElementById("StreetNameError");
    var postalCodeError = document.getElementById("PostalCodeError");
    var cityError = document.getElementById("CityError");
    var emailError = document.getElementById("EmailError");
    var passwordError = document.getElementById("PasswordError");
    var confirmPasswordError = document.getElementById("ConfirmPasswordError");

    firstNameInput.addEventListener("input", validateFirstName);
    lastNameInput.addEventListener("input", validateLastName);
    streetNameInput.addEventListener("input", validateStreetName);
    postalCodeInput.addEventListener("input", validatePostalCode);
    cityInput.addEventListener("input", validateCity);
    emailInput.addEventListener("input", validateEmail);
    passwordInput.addEventListener("input", validatePassword);
    confirmPasswordInput.addEventListener("input", validateConfirmPassword);


    function validateFirstName() {
        var firstNameValue = firstNameInput.value.trim();
        if (firstNameValue.length < 2) {
            firstNameInput.classList.add("invalid");
            firstNameError.textContent = "Please enter at least two letters";
        } else {
            firstNameInput.classList.remove("invalid");
            firstNameError.textContent = "";
        }
    }

    function validateLastName() {
        var lastNameValue = lastNameInput.value.trim();
        if (lastNameValue.length < 2) {
            lastNameInput.classList.add("invalid");
            lastNameError.textContent = "Please enter at least two letters";
        } else {
            lastNameInput.classList.remove("invalid");
            lastNameError.textContent = "";
        }
    }

    function validateStreetName() {
        var streetNameValue = streetNameInput.value.trim();
        if (streetNameValue.length < 5) {
            streetNameInput.classList.add("invalid");
            streetNameError.textContent = "Please enter at least five letters";
        } else {
            streetNameInput.classList.remove("invalid");
            streetNameError.textContent = "";
        }
    }

    function validatePostalCode() {
        var postalCodeValue = postalCodeInput.value.trim();
        if (postalCodeValue.length < 5) {
            postalCodeInput.classList.add("invalid");
            postalCodeError.textContent = "Please enter at least five numbers";
        } else {
            postalCodeInput.classList.remove("invalid");
            postalCodeError.textContent = "";
        }
    }

    function validateCity() {
        var cityValue = cityInput.value.trim();
        if (cityValue.length < 2) {
            cityInput.classList.add("invalid");
            cityError.textContent = "Please enter at least two letters";
        } else {
            cityInput.classList.remove("invalid");
            cityError.textContent = "";
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

function validateConfirmPassword() {
    var confirmPasswordValue = confirmPasswordInput.value;
    var passwordValue = passwordInput.value;

    if (confirmPasswordValue === "") {
        confirmPasswordInput.classList.add("invalid");
        confirmPasswordError.textContent = "";
    } else if (confirmPasswordValue !== passwordValue) {
        confirmPasswordInput.classList.add("invalid");
        confirmPasswordError.textContent = "Passwords do not match.";
    } else {
        confirmPasswordInput.classList.remove("invalid");
        confirmPasswordError.textContent = "";
    }
}

    
});