
$(document).ready(function () {
    $('.collapse.collapseContainer .nav-link').each(function () {
        var lockIcon = $(this).find('.fa-lock');
        if (lockIcon.length > 0 && lockIcon.css('display') !== 'none') {
            var parentNavLink = $(this);
            parentNavLink.on('click', function (e) {
                e.preventDefault(); // Ngăn chặn hành động mặc định của sự kiện click
                e.stopPropagation(); // Ngăn chặn sự lan truyền của sự kiện click đến các phần tử cha
                return false;
            });
            parentNavLink.css('pointer-events', 'none'); // Ngăn chặn sự kiện click bằng cách vô hiệu hóa pointer-events
            console.log(">>>> Đã ngăn chặn");
        }
    });
    // Lặp qua mỗi video và thêm sự kiện cho từng video
    $('.videoPlayer').each(function () {
        var video = this;
        var duration = 0;
        //var parentDiv = $(this).closest('div');
        var parentDiv = $(this).closest('.tab-pane');
        //var iconContainer = $('#layoutSidenav').find('.icon-container');
        video.addEventListener('loadedmetadata', function () {
            duration = video.duration;
        });

        video.addEventListener('timeupdate', function () {
            var currentTime = video.currentTime;
            var percentageWatched = (currentTime / duration) * 100;
            var trainingPartId = $(video).data('trainingpart-id');

            var trainingPartIsComplete = $(video).data('trainingpart-iscomplete');

            var videoName = $(video).data('video-name');


            var iconContainer = $('#layoutSidenav').find('.icon-container-' + trainingPartId);

            var percentageDiv = $(parentDiv).find('.percentageWatched');
            $(percentageDiv).text('Percentage watched: ' + percentageWatched.toFixed(2) + '%');

            if (percentageWatched >= 95) {
                if (iconContainer.length > 0) {
                    var lockIcon = $(iconContainer).find('.fa-lock');
                    var checkIcon = $(iconContainer).find('.fa-square-check');
                    var squareIcon = $(iconContainer).find('.fa-square');
                    $(lockIcon).hide();
                    $(checkIcon).show();
                    $(squareIcon).hide();

                    console.log(">>>> đã hoàn thành video");
                } else {
                    console.error("Biểu tượng lock hoặc checkbox không tồn tại trong phần tử iconContainer");
                }

                var nextIconContainer = iconContainer.closest('.collapseContainer').nextAll('.collapseContainer').first().find('.nav-link');

                if (nextIconContainer.length > 0) {
                    var lockIcon = $(nextIconContainer).find('.fa-lock');
                    if (lockIcon.length > 0 && lockIcon.css('display') !== 'none') {
                        var nextlockIcon = $(nextIconContainer).find('.fa-lock');
                        var nextcheckIcon = $(nextIconContainer).find('.fa-square-check');
                        var nextsquareIcon = $(nextIconContainer).find('.fa-square');
                        $(nextlockIcon).hide();
                        $(nextcheckIcon).hide();
                        $(nextsquareIcon).show();

                        var squareParentLink = $(nextIconContainer).closest('.nav-link');
                        if (squareParentLink.length > 0) {
                            squareParentLink.css('pointer-events', 'auto');
                        }
                    }
                }
                return;
            }
            sendEventToServer(videoName, percentageWatched, trainingPartId, trainingPartIsComplete);

        });
    });

    function sendEventToServer(videoName, percentage, trainingPartId, trainingPartIsComplete) {
        $.ajax({
            url: '/CustomerCourses/TrackVideoEvent',
            method: 'POST',
            data: {
                videoName: videoName,
                percentageWatched: percentage,
                trainingPartId: trainingPartId,
                trainingPartIsComplete: trainingPartIsComplete
            },
            success: function (response) {
                // Xử lý phản hồi từ server nếu cần
            },
            error: function (xhr, status, error) {
                console.error('Lỗi khi gửi phần trăm đã xem lên server:', error);
            }
        });
    }
});
