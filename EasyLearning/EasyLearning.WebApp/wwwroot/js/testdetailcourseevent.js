function showEventDetail(itemCourseEvent, listTrainingPartByCourseEvent) {
    // Tạo một div container mới cho chi tiết sự kiện
    itemCourseEvent = JSON.parse(itemCourseEvent); // Chuyển đổi chuỗi JSON trở lại đối tượng JavaScript
    listTrainingPartByCourseEvent = JSON.parse(listTrainingPartByCourseEvent);
    var eventDetailContainer = document.createElement('div');
    eventDetailContainer.classList.add('col-lg-8', 'col-xl-6', 'event-details');

    // Tạo nội dung của chi tiết sự kiện
    var eventDetailContent = `
            <div class="card border-top border-bottom border-3" style="border-color: #06BBCC !important;">
                <div class="card-body p-5">
                    <p class="lead fw-bold mb-5" style="color: #06BBCC;">Chi tiết buổi học</p>
                    <div class="row">
                        <div class="col mb-3">
                            <p class="small text-muted mb-1">Ngày</p>
                            <p>${itemCourseEvent.Date}</p>
                        </div>
                        <div class="col mb-3">
                            <p class="small text-muted mb-1">Giảng viên</p>
                            <p>${listTrainingPartByCourseEvent.tr}</p>
                        </div>
                    </div>
                    <!-- Thêm các thông tin khác của sự kiện và training part vào đây -->
                    <div class="mx-n5 px-5 py-4" style="background-color: #f2f2f2;">
                        <!-- Các thông tin của training part -->
                    </div>
                    <p class="lead fw-bold mb-4 pb-2" style="color: #06BBCC;">Tracking Order</p>
                    <!-- Thêm tracking order tương ứng -->
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="horizontal-timeline">
                                <!-- Thêm horizontal timeline -->
                            </div>
                        </div>
                    </div>
                    <p class="mt-4 pt-2 mb-0">Want any help? <a href="#!" style="color: #f37a27;">Please contact us</a></p>
                </div>
            </div>
        `;

    // Thêm nội dung vào container
    eventDetailContainer.innerHTML = eventDetailContent;

    // Thêm container vào DOM
    var eventDetailWrapper = document.getElementById("event-detail-wrapper");
    eventDetailWrapper.innerHTML = ''; // Xóa nội dung cũ trước khi thêm mới
    eventDetailWrapper.appendChild(eventDetailContainer);
}
