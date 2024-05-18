
    document.addEventListener("DOMContentLoaded", function () {
        let circularProgressList = document.querySelectorAll(".circular-progress");

        circularProgressList.forEach(circularProgress => {
        let progressValue = circularProgress.querySelector(".progress-value");
    let dataPercent = parseInt(progressValue.getAttribute('data-percent'));
    let progressStartValue = 0;
    let progressEndValue = dataPercent; // Nếu dataPercent không phải là 0 thì sử dụng giá trị dataPercent, ngược lại gán 0 cho progressEndValue
    let speed = 8;

            if (progressEndValue > 0) { // Thêm điều kiện để chỉ hiển thị khi progressEndValue lớn hơn 0
        let progress = setInterval(() => {
        progressStartValue++;
    progressValue.textContent = `${progressStartValue}%`;
    circularProgress.style.background = `conic-gradient(#38c9d6, ${progressStartValue * 3.6}deg, #808080 0deg)`;

    if (progressStartValue == progressEndValue) {
        clearInterval(progress);
                    }
                }, speed);
            } else {
        progressValue.textContent = "0%";
            }
        });
    });
