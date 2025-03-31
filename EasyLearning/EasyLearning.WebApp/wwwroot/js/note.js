

/*document.querySelectorAll('.get-note').forEach(button => {
    button.addEventListener('click', function () {
        document.getElementById('note-box').style.display = 'block';
    });
});*/



$(document).ready(function () {
    $('#getnote').on('click', function (event) {
        event.preventDefault(); 
        $('#note-box').show();
    });

    $('.close-notes').on('click', function () {
        $('#note-box').hide();
    });

    $(document).on('click', function (event) {
        var clickedElement = $(event.target);
        if (!clickedElement.closest('#note-box').length && !clickedElement.closest('#getnote').length && !clickedElement.hasClass('btn-cancel-edit')) {
            $('#note-box').hide();
        }
    });

    $('.add-note').on('click', function () {
 
        var trainingPartId = $(this).data('trainingpartid');
        var courseId = $(this).data('courseid')
        var video = $('.videoPlayer[data-trainingpart-id="' + trainingPartId + '"]')[0];
      
        if (!video.paused) {
            video.pause();
        }
        var currentTime = video.currentTime;
        $('#noteContainer').show();
        $('#noteContainer h3').text('Thêm ghi chú tại ' + formatTime(currentTime));
        $('#noteContainer').data('currentTime', currentTime);
        $('#noteContainer').data('trainingPartId', trainingPartId);
        $('#noteContainer').data('courseId', courseId);

    });
    $('#noteContainer button[type="submit"]').on('click', function (event) {
        event.preventDefault();

        var noteText = $('#your-message').val().trim();
        var currentTime = $('#noteContainer').data('currentTime');
        var trainingPartId = $('#noteContainer').data('trainingPartId');
        var courseId = $('#noteContainer').data('courseId');
        if (noteText !== '') {
           
            saveNoteToServer(noteText, currentTime, trainingPartId, courseId);
        }

      
        $('#noteContainer').hide();
        $('#your-message').val('');
        var video = $('.videoPlayer[data-trainingpart-id="' + trainingPartId + '"]')[0];
        video.play();
    });

    $('#noteContainer button[type="button"]').on('click', function () {
     
        $('#noteContainer').hide();
        $('#your-message').val('');

        var trainingPartId = $('#noteContainer').data('trainingPartId');
        var video = $('.videoPlayer[data-trainingpart-id="' + trainingPartId + '"]')[0];
        video.play();
    });

   
    function saveNoteToServer(noteText, currentTime, trainingPartId, courseId) {
        $.ajax({
            url: '/Note/Create',
            method: 'POST',
            data: {
                noteContent: noteText,
                currentTime: currentTime,
                trainingPartId: trainingPartId,
                courseId: courseId
            },
            success: function (response) {
                
                console.log('Ghi chú đã được lưu thành công!');
                console.log('>>>>', response.noteContent);
                console.log('>>>>', response.trainingPartId);
                console.log('>>>>', response.trainingPartName);
                console.log('>>>>', response.courseEventName);
            
                addNoteToList(response.noteId, response.currentTime, response.noteContent, response.trainingPartId, response.trainingPartName, response.courseEventName);

            },
            error: function (xhr, status, error) {
                console.error('Lỗi khi lưu ghi chú:', error);
            }
        });
    }
    function addNoteToList(noteId, currentTime, noteContent, trainingPartId, trainingPartName, courseEventName) {
        var formattedTime = formatTime(currentTime);
       
        var newNote = `
       <div class="p-3 m-0 border-0 bd-example" style="position: relative;">
            <article class="card bg-light">
                <header class="card-header border-0 bg-transparent d-flex align-items-center">
                    <div>
                        <button class="btn btn-primary note-button" style="padding:0 28px; border-radius:16px; margin-right:12px" data-currenttime="${currentTime}" data-trainingpartid="${trainingPartId}">${formattedTime}</button>
                        <a class="fw-semibold text-decoration-none note-link" style="cursor: pointer;" data-currenttime="${currentTime}" data-trainingpartid="${trainingPartId}">${trainingPartName} </a>
                    </div>
                    <div class="dropdown ms-auto">
                        <button class="btn btn-link text-decoration-none" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <i class="fas fa-ellipsis-v"></i>
                        </button>
                        <ul class="dropdown-menu" style="cursor: pointer;">
                            <li><a class="dropdown-item edit-note" data-noteid="${noteId}">Sửa lại ghi chú</a></li>
                            <li><a class="dropdown-item delete-note" >Xóa ghi chú</a></li>
                        </ul>
                    </div>
                </header>

                <header class="card-header border-0 bg-transparent d-flex align-items-center">
                    <span class="ms-3 small text-muted">${courseEventName} </span>
                </header>

                <footer class="card-footer bg-white border-0 py-1 px-3">
                    <div class="card-body py-2 px-3">
                        ${noteContent}
                    </div>
                </footer>
            </article>

            <div class="modal-delete">
                    <div class="modal-content delete-confirmation-form" style="display: none;">
                        <p>Xóa ghi chú này?</p>
                        <div class="button-container">
                            <button class="btn btn-primary confirm-delete" data-noteid="${noteId}">Xóa</button>
                            <button class="btn btn-secondary cancel-delete">Hủy</button>
                        </div>
                    </div>
                </div>
        </div>
    `;
        var $newNote = $(newNote);
        $('#note-box').append(newNote);
        applyEventDelegation();
    }

    function applyEventDelegation() {
        $('#note-box').off('click', '.note-button');
        $('#note-box').on('click', '.note-button', function () {
            var currentTime = $(this).data('currenttime');
            var trainingPartId = $(this).data('trainingpartid');
            navigateToTrainingPart(trainingPartId, currentTime);
        });

        $('#note-box').off('click', '.note-link'); 
        $('#note-box').on('click', '.note-link', function () {
            var currentTime = $(this).data('currenttime');
            var trainingPartId = $(this).data('trainingpartid');
            navigateToTrainingPart(trainingPartId, currentTime);
        });
    }
    applyEventDelegation();
    function navigateToTrainingPart(trainingPartId, currentTime) {
        // Simulate the action of switching to the training part tab/pane
        // This part might vary depending on your tab management logic
        $('.tab-pane').removeClass('show active');
        $('#' + trainingPartId).addClass('show active');

        // Find the video element and set the current time
        var video = $('.videoPlayer[data-trainingpart-id="' + trainingPartId + '"]')[0];
        if (video) {
            video.currentTime = parseFloat(currentTime);
            video.pause();
        }
    }

    $(document).ready(function () {
        $('.note-button').each(function () {
            var currentTime = $(this).data('currenttime');
            var formattedTime = formatTime(currentTime);
            $(this).text(formattedTime);
        });
    });

    function formatTime(seconds) {
        var hours = Math.floor(seconds / 3600);
        var minutes = Math.floor((seconds % 3600) / 60);
        var remainingSeconds = Math.floor(seconds % 60);

        var formattedTime = '';
        if (hours > 0) {
            formattedTime += pad(hours, 2) + ':';
        }
        formattedTime += pad(minutes, 2) + ':' + pad(remainingSeconds, 2);
        return formattedTime;
    }

    // Hàm bổ sung số 0 phía trước nếu cần
    function pad(number, length) {
        var str = '' + number;
        while (str.length < length) {
            str = '0' + str;
        }
        return str;
    }

    // Cập nhật văn bản của nút "Ghi chú" khi thời gian của video thay đổi
    $('.videoPlayer').on('timeupdate', function () {
        var currentTime = $(this)[0].currentTime;
        var tabPane = $(this).closest('.tab-pane');
        var addNoteButton = tabPane.find('.add-note');
        addNoteButton.html('<i class="fas fa-plus"></i> Thêm ghi chú tại: <strong>' + formatTime(currentTime) + '</strong>');
    });

});

$(document).on('click', '.edit-note', function (e) {
    e.preventDefault();
    var noteCard = $(this).closest('.bd-example');
    var noteContentElement = noteCard.find('.card-body');
    var noteContent = noteContentElement.text().trim();
    var noteId = $(this).data('noteid');

    // Store the original content and the note ID
    noteCard.data('original-content', noteContentElement.html());
    noteCard.data('noteid', noteId);

    // Replace the content with a textarea
    noteContentElement.html(`
        <textarea class="form-control edit-note-content">${noteContent}</textarea>
        <button class="btn btn-primary btn-save-note mt-2" style="font-size:14px;" data-note-id="${noteId}">Lưu</button>
        <button class="btn btn-secondary btn-cancel-edit mt-2" style="font-size:14px; margin-left: 12px">Hủy</button>
    `);
});

$(document).on('click', '.btn-save-note', function () {
    var noteCard = $(this).closest('.bd-example');
    var noteContentElement = noteCard.find('.card-body');
    var updatedContent = noteContentElement.find('.edit-note-content').val().trim();
    var noteId = $(this).data('note-id');

    if (updatedContent !== '') {
        saveNoteEdit(noteContentElement, updatedContent, noteId);
    }
});

$(document).on('click', '.btn-cancel-edit', function () {
    var noteCard = $(this).closest('.bd-example');
    var noteContentElement = noteCard.find('.card-body');
    var originalContent = noteCard.data('original-content'); 
    noteContentElement.html(originalContent);
});

function saveNoteEdit(noteContentElement, updatedContent, noteId) {
    $.ajax({
        url: '/Note/Update', 
        method: 'POST',
        data: {
            noteId: noteId,
            noteContent: updatedContent
        },
        success: function (response) {
            console.log('Ghi chú đã được cập nhật thành công!');
            
            noteContentElement.html(updatedContent);
        },
        error: function (xhr, status, error) {
            console.error('Lỗi khi cập nhật ghi chú:', error);
        }
    });
}

$(document).on('click', '.delete-note', function (e) {
    e.preventDefault();
    var noteCard = $(this).closest('.bd-example');
    var deleteForm = noteCard.find('.delete-confirmation-form');
    deleteForm.show();
});

$(document).on('click', '.confirm-delete', function () {
    var noteId = $(this).data('noteid');
    var noteCard = $(this).closest('.bd-example');
    deleteNoteFromServer(noteId, noteCard);
});

$(document).on('click', '.cancel-delete', function () {
    var deleteForm = $(this).closest('.delete-confirmation-form');
    deleteForm.hide();
});

function deleteNoteFromServer(noteId, noteCard) {
    $.ajax({
        url: '/Note/Delete', 
        method: 'POST',
        data: {
            noteId: noteId
        },
        success: function (response) {
            console.log('Ghi chú đã được xóa thành công!');
            noteCard.remove();
        },
        error: function (xhr, status, error) {
            console.error('Lỗi khi xóa ghi chú:', error);
        }
    });
}


