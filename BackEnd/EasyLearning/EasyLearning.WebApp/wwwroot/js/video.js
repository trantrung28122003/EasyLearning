document.addEventListener('DOMContentLoaded', function () {
    var video = document.getElementById('videoPlayer');

    video.addEventListener('play', function () {
        // Gửi yêu cầu AJAX hoặc WebSocket đến máy chủ để ghi lại sự kiện play
        // Ví dụ sử dụng jQuery AJAX:
        $.ajax({
            url: '/CustomerCourses/TrackVideoEvent',
            method: 'POST',
            data: {
                eventName: 'play',
                videoName: 'video.mp4'
            }
        });
    });

    video.addEventListener('pause', function () {
        // Gửi yêu cầu AJAX hoặc WebSocket đến máy chủ để ghi lại sự kiện pause
        // Ví dụ sử dụng jQuery AJAX:
        $.ajax({
            url: '/CustomerCourses/TrackVideoEvent',
            method: 'POST',
            data: {
                eventName: 'pause',
                videoName: 'video.mp4'
            }
        });
    });

    video.addEventListener('ended', function () {
        // Gửi yêu cầu AJAX hoặc WebSocket đến máy chủ để ghi lại sự kiện video đã kết thúc
        // Ví dụ sử dụng jQuery AJAX:
        $.ajax({
            url: '/Home/TrackVideoEvent',
            method: 'POST',
            data: {
                eventName: 'ended',
                videoName: 'video.mp4'
            }
        });
    });
});