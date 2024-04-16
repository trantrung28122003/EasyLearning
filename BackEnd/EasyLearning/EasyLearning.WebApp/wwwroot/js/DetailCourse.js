document.addEventListener("DOMContentLoaded", function () {
    const stars = document.querySelectorAll(".star");

    stars.forEach(function (star) {
        star.addEventListener("click", function () {
            const value = parseInt(this.getAttribute("data-value"));
            document.getElementById("rating").value = value;
            // Reset color for all stars
            stars.forEach(function (s) {
                s.style.color = "";
            });
            // Color stars up to the clicked one
            for (let i = 0; i < value; i++) {
                stars[i].style.color = "#06BBCC";
            }
        });
    });
});

document.getElementById("submitReviewBtn").addEventListener("click", function (event) {
    //event.preventDefault(); // Ngăn chặn hành động mặc định của nút submit

    // Lấy giá trị của trường content
    
    var content = document.getElementById("textContent").value
    console.log(">>>>>", content);
    // Lấy giá trị của trường rating
    var rating = document.getElementById("rating").value;

    // Đặt giá trị của thuộc tính asp-route-rating và asp-route-content
    document.getElementById("submitReviewBtn").setAttribute("asp-route-content", content);
    document.getElementById("submitReviewBtn").setAttribute("asp-route-rating", rating);


    // Sau khi thiết lập các giá trị, tiến hành submit form
    document.getElementById("submitReviewBtn").closest("form").submit();
});

document.getElementById("convertButton").addEventListener("click", function () {
    // Lấy giá trị điểm số từ ô nhập liệu
    var rating = parseFloat(document.getElementById("ratingInput").value);

    // Chuyển đổi điểm số thành số lượng sao
    var stars = '';
    for (var i = 1; i <= 5; i++) {
        if (i <= rating / 2) {
            stars += '<i class="fas fa-star fa-2x text-primary"></i>';
        } else {
            stars += '<i class="fas fa-star fa-2x text-muted"></i>';
        }
    }

    // Hiển thị số lượng sao tương ứng
    document.getElementById("starRating").innerHTML = stars;
});