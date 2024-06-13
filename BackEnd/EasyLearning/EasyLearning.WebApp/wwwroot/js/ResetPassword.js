document.getElementById('sendVerificationCode').addEventListener('click', function () {
    var email = document.getElementById('email').value;

    // Kiểm tra email có đúng định dạng hay không
    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailPattern.test(email)) {
        // Hiển thị thông báo lỗi dưới trường nhập email
        document.getElementById('email-validation-error').textContent = 'Vui lòng nhập địa chỉ email hợp lệ.';
        return; // Không làm gì nếu email không hợp lệ
    } else {
        // Xóa thông báo lỗi nếu email hợp lệ
        document.getElementById('email-validation-error').textContent = '';
    }

    this.disabled = true;

    // Function to generate a random 6-digit verification code
    function generateVerificationCode() {
        return Math.floor(100000 + Math.random() * 900000);
    }

    // Function to update the button text and countdown
    function updateButton() {
        var count = 100; // 2 minutes in seconds
        var interval = setInterval(function () {
            document.getElementById('sendVerificationCode').textContent = 'Gửi mã lại (' + count + ')';
            count--;
            if (count === 0) {
                clearInterval(interval);
                document.getElementById('sendVerificationCode').textContent = 'Gửi mã xác thực';
                document.getElementById('sendVerificationCode').disabled = false;
                document.getElementById('sendVerificationCode').textContent = '';
                document.getElementById('verificationCode').disabled = true;
                document.getElementById('hiddenSendVerificationCode').value = generateVerificationCode();
            }
        }, 1000);
    }
    updateButton();
    var verificationCode = generateVerificationCode();
    document.getElementById('hiddenSendVerificationCode').value = verificationCode;
    document.getElementById('verificationCode').disabled = false;
    var email = document.getElementById('email').value;
    SendVerificationCode(email, verificationCode)
});
function SendVerificationCode(email, verificationCode) {
    $.ajax({
        url: '/Account/SendVerificationCode',
        method: 'POST',
        data: {
            email: email,
            verificationCode: verificationCode,
        },
        success: function (response) {
            if (response.ok) {
                alert('Mã xác thực đã được gửi đến email của bạn.');
                updateButton();
            } else {

            }
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            alert('Đã xảy ra lỗi khi gửi mã xác thực.');
            this.disabled = false;
        }
    });
}

document.getElementById('resetPasswordButton').addEventListener('click', function (e) {
    var verificationCode = document.getElementById('verificationCode').value;
    var hiddenSendVerificationCode = document.getElementById('hiddenSendVerificationCode').value;

    if (verificationCode !== hiddenSendVerificationCode) {
        e.preventDefault(); // Ngăn chặn form submit
        document.getElementById('verificationCode-error').textContent = 'Mã xác thực không chính xác. Vui lòng kiểm tra lại.';
        document.getElementById('verificationCode').disabled = false;
    }
});