document.getElementById('forgetForm').addEventListener('submit', function (event) {
    var mobile = document.getElementById('mobile').value;

    // Validate mobile number
    var mobilePattern = /^0[0-9]{10}$/;
    if (!mobilePattern.test(mobile)) {
        alert('Please enter a valid 11-digit mobile number.');
        event.preventDefault();  // Prevent form submission
        return;
    }
});