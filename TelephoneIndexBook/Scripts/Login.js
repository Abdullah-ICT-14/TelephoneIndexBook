// Show/hide password onClick of button using Javascript only

// https://stackoverflow.com/questions/31224651/show-hide-password-onclick-of-button-using-javascript-only

//function show() {
//    var p = document.getElementById('pwd');
//    p.setAttribute('type', 'text');
//}

//function hide() {
//    var p = document.getElementById('pwd');
//    p.setAttribute('type', 'password');
//}

//var pwShown = 0;

//document.getElementById("eye").addEventListener("click", function () {
//    if (pwShown == 0) {
//        pwShown = 1;
//        show();
//    } else {
//        pwShown = 0;
//        hide();
//    }
//}, false);



//function show() {
//    var p = document.getElementById('cpwd');
//    p.setAttribute('type', 'text');
//}

//function hide() {
//    var p = document.getElementById('cpwd');
//    p.setAttribute('type', 'password');
//}

//var cpwShown = 0;

//document.getElementById("eye1").addEventListener("click", function () {
//    if (cpwShown == 0) {
//        cpwShown = 1;
//        show();
//    } else {
//        cpwShown = 0;
//        hide();
//    }
//}, false);


document.getElementById('eye1').addEventListener('click', function () {
    var passwordField = document.getElementById('cpwd');
    if (passwordField.type === "password") {
        passwordField.type = "text";
    } else {
        passwordField.type = "password";
    }
});
//for Eye Sign Toggle Password
document.getElementById('eye').addEventListener('click', function () {
    var passwordField = document.getElementById('pwd');
    if (passwordField.type === "password") {
        passwordField.type = "text";
    } else {
        passwordField.type = "password";
    }
});

document.getElementById('signupForm').addEventListener('submit', function (event) {
    var password = document.getElementById('pwd').value;
    var confirmPassword = document.getElementById('cpwd').value;

    if (password !== confirmPassword) {
        alert('Passwords do not match.');
        event.preventDefault();  // Prevent form submission
    }
});

document.getElementById('signupForm').addEventListener('submit', function (event) {
    var mobile = document.getElementById('mobile').value;
    var email = document.getElementById('email').value;

    // Validate mobile number
    var mobilePattern = /^0[0-9]{10}$/;
    if (!mobilePattern.test(mobile)) {
        alert('Please enter a valid 11-digit mobile number.');
        event.preventDefault();  // Prevent form submission
        return;
    }

    // Validate email
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    if (!emailPattern.test(email)) {
        alert('Please enter a valid email.');
        event.preventDefault();  // Prevent form submission
        return;
    }
});

