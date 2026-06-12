var totalEvents = 3;

function showEventCount() {
    var banner = document.getElementById("event-count-banner");
    banner.textContent = "We currently have " + totalEvents + " exciting events available for you!";
    banner.style.display = "block";

    var eventsSection = document.getElementById("events");
    eventsSection.scrollIntoView({ behavior: "smooth" });
}

function selectEvent(eventName) {
    var eventDropdown = document.getElementById("event");

    for (var i = 0; i < eventDropdown.options.length; i++) {
        if (eventDropdown.options[i].value === eventName) {
            eventDropdown.selectedIndex = i;
            break;
        }
    }

    var registerSection = document.getElementById("register");
    registerSection.scrollIntoView({ behavior: "smooth" });

    alert("You selected: " + eventName + "\nPlease fill in your details and submit.");
}

function validateName() {
    var name = document.getElementById("name").value.trim();
    var nameError = document.getElementById("name-error");

    if (name === "") {
        nameError.textContent = "Full name is required.";
        return false;
    }

    if (name.length < 3) {
        nameError.textContent = "Name must be at least 3 characters.";
        return false;
    }

    nameError.textContent = "";
    return true;
}

function validateEmail() {
    var email = document.getElementById("email").value.trim();
    var emailError = document.getElementById("email-error");

    if (email === "") {
        emailError.textContent = "Email address is required.";
        return false;
    }

    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(email)) {
        emailError.textContent = "Please enter a valid email address.";
        return false;
    }

    emailError.textContent = "";
    return true;
}

function validatePhone() {
    var phone = document.getElementById("phone").value.trim();
    var phoneError = document.getElementById("phone-error");

    if (phone === "") {
        phoneError.textContent = "Phone number is required.";
        return false;
    }

    if (phone.length !== 10 || isNaN(phone)) {
        phoneError.textContent = "Enter a valid 10-digit phone number.";
        return false;
    }

    phoneError.textContent = "";
    return true;
}

function validateEvent() {
    var eventValue = document.getElementById("event").value;
    var eventError = document.getElementById("event-error");

    if (eventValue === "") {
        eventError.textContent = "Please select an event.";
        return false;
    }

    eventError.textContent = "";
    return true;
}

function submitRegistration() {
    var isNameValid = validateName();
    var isEmailValid = validateEmail();
    var isPhoneValid = validatePhone();
    var isEventValid = validateEvent();

    if (isNameValid && isEmailValid && isPhoneValid && isEventValid) {
        var successMessage = document.getElementById("success-message");
        successMessage.style.display = "block";

        document.getElementById("name").value = "";
        document.getElementById("email").value = "";
        document.getElementById("phone").value = "";
        document.getElementById("event").selectedIndex = 0;

        setTimeout(function () {
            successMessage.style.display = "none";
        }, 4000);
    }
}
