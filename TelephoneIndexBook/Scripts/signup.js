document.getElementById('signupForm').addEventListener('submit', function(event) {
    var password = document.getElementById('password').value;
    var confirmPassword = document.getElementById('cpassword').value;

    if (password !== confirmPassword) {
        alert('Passwords do not match.');
    event.preventDefault();  // Prevent form submission
    }
});
document.getElementById('signupForm').addEventListener('submit', function (event) {
    var recaptchaResponse = grecaptcha.getResponse();

    if (recaptchaResponse.length == 0) {
        // The reCAPTCHA was not completed correctly
        alert('Please complete the reCAPTCHA.');
        event.preventDefault();  // Prevent form submission
    }
});

document.getElementById('toggle-password').addEventListener('click', function () {
    var passwordField = document.getElementById('password');
    var passwordFieldType = passwordField.getAttribute('type');

    if (passwordFieldType === 'password') {
        passwordField.setAttribute('type', 'text');
        this.classList.remove('fa-eye');
        this.classList.add('fa-eye-slash');
    } else {
        passwordField.setAttribute('type', 'password');
        this.classList.remove('fa-eye-slash');
        this.classList.add('fa-eye');
    }
});

document.getElementById('ctoggle-password').addEventListener('click', function () {
    var passwordField = document.getElementById('cpassword');
    var passwordFieldType = passwordField.getAttribute('type');

    if (passwordFieldType === 'password') {
        passwordField.setAttribute('type', 'text');
        this.classList.remove('fa-eye');
        this.classList.add('fa-eye-slash');
    } else {
        passwordField.setAttribute('type', 'password');
        this.classList.remove('fa-eye-slash');
        this.classList.add('fa-eye');
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