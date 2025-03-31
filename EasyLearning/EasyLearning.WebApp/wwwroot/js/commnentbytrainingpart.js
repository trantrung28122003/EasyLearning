

function updateCommentCount() {
    const commentDivs = document.querySelectorAll('div.comments');
    const replyDivs = document.querySelectorAll('div.replies');
    const totalCommentsAndReplies = commentDivs.length + replyDivs.length;
    document.getElementById('commentCount').textContent = `${totalCommentsAndReplies} Comments`;
}

document.querySelectorAll('.get-comments').forEach(button => {
    button.addEventListener('click', function () {
        const trainingPartId = this.getAttribute('data-trainingpartid');
        document.getElementById('commentBox_' + trainingPartId).style.display = 'block';
    });
});

document.querySelectorAll('.close-comments').forEach(button => {
    button.addEventListener('click', function () {
        const trainingPartId = this.getAttribute('data-trainingpartid');
        document.getElementById('commentBox_' + trainingPartId).style.display = 'none';
    });
});

document.addEventListener('click', function (event) {
    const commentBoxes = document.querySelectorAll('.comment-box');
    const isGetCommentsButton = event.target.closest('.get-comments');
    const isCancelButton = event.target.classList.contains('cancel-reply-btn');

    if (!isGetCommentsButton && !isCancelButton) {
        commentBoxes.forEach(box => {
            if (!box.contains(event.target)) {
                box.style.display = 'none';
            }
        });
    }
});

document.querySelectorAll('form[id^="commentForm_"]').forEach(form => {
    form.addEventListener('submit', function (event) {
        event.preventDefault();

        const trainingPartId = this.id.split('_')[1];
        const textarea = document.getElementById(`exampleFormControlTextarea1_${trainingPartId}`);
        const content = textarea.value;

        if (content.length < 3 || content.length > 255) {
            alert('Comment must be between 3 and 255 characters.');
            return;
        }

        $.ajax({
            url: '/Comment/AddComment',
            method: 'POST',
            data: {
                content: content,
                trainingPartId: trainingPartId,
            },
            success: function (response) {
                if (response.success) {
                    const commentContainer = document.getElementById(`commentContainer_${trainingPartId}`);

                    const newCommentSection = document.createElement('div');
                
                    newCommentSection.className = 'comments';
                    
                    newCommentSection.innerHTML = `
                    <section id="comment_@itemTraingPart.Id" class="comment mt-3">
                        <article class="card bg-light">
                            <header class="card-header border-0 bg-transparent d-flex align-items-center">
                                <div>
                                    <img src="https://via.placeholder.com/40x40" class="rounded-circle me-2" />
                                    <a class="fw-semibold text-decoration-none">${response.user.fullName}</a>
                                    <span class="ms-3 small text-muted">Just now</span>
                                </div>
                            </header>
                            <div class="card-body py-2 px-3">${response.content}</div>
                            <footer class="card-footer bg-white border-0 py-1 px-3">
                                <button type="button" class="btn btn-link btn-sm text-decoration-none ps-0">
                                    <i class="bi bi-hand-thumbs-up me-1"></i> thích
                                </button>
                                <button type="button" class="btn btn-link btn-sm text-decoration-none reply-btn" data-commentid="${response.commentId}" data-userId="${response.user.id}">
                                    phản hồi
                                </button>
                                <button type="button" class="btn btn-light btn-sm border rounded-4 ms-2">
                                    <i class="fa-solid fa-ellipsis"></i>
                                </button>
                            </footer>
                        </article>
                        <div id="replyContainer_${response.commentId}"></div>
                        <aside>
                            <button id="toggle-replies-btn-${response.commentId}" class="toggle-replies-btn btn btn-link btn-sm text-decoration-none ms-2 my-2" style="display: none;">
                                    xem phản hồi
                            </button>
                            <section id="comment-replies_${response.commentId}" class="ms-5 ms-md-5" style="display: none;"> 
                            </section> 
                        </aside>
                     </section>
                    `;

                    commentContainer.appendChild(newCommentSection);
                    textarea.value = ''; 

                    addReplyButtonClickEvent();
                   
                    newCommentSection.querySelector('.toggle-replies-btn').addEventListener('click', function () {
                        const commentId = this.id.replace('toggle-replies-btn-', '');
                        const repliesSection = document.getElementById('comment-replies_' + commentId);

                        if (repliesSection.style.display === 'none') {
                            repliesSection.style.display = 'block';
                            this.textContent = 'Ẩn phản hồi';
                        } else {
                            if (repliesSection.children.length != 0) {
                                repliesSection.style.display = 'none';
                                this.textContent = `xem thêm ${repliesSection.children.length} phản hồi`;
                            }
                            else {
                                repliesSection.style.display = 'none';
                                this.textContent = ``;
                            }
                        }
                    });
                    updateCommentCount();
                    updateRelativeTime();
                }
            },
        });
    });
});

function addReplyButtonClickEvent() {
   
    document.querySelectorAll('.reply-btn').forEach(button => {
        button.addEventListener('click', function () {
        
            const commentId = this.getAttribute('data-commentid');
            const replyId = this.getAttribute('data-replyid');
            const userId = this.getAttribute('data-userId');

            $.ajax({
                url: '/Comment/GetUserName',
                method: 'GET',
                data: {
                    userId: userId
                },
                success: function (response) {
                    const textareaContent = (userId === response.userId) ? "" : `@${response.userName}`; 
                    let replyContainer;

                    if (replyId) {
                        replyContainer = document.getElementById('replyContainer_' + replyId);
                    } else {
                        replyContainer = document.getElementById('replyContainer_' + commentId);
                    }
                  
                    if (!replyContainer.querySelector('.reply-form')) {
                        const replyForm = document.createElement('form');
                        replyForm.className = 'reply-form mt-2';
                        replyForm.innerHTML = `
                            <div class="mb-3">
                                <textarea class="form-control" rows="2">${textareaContent}</textarea>
                            </div>
                            <button type="submit" class="btn btn-primary btn-sm">Gửi</button>
                            <button type="button" class="btn btn-secondary btn-sm cancel-reply-btn">Hủy</button>
                        `;

                        replyForm.addEventListener('submit', function (event) {
                            event.preventDefault();

                            const textarea = replyForm.querySelector('textarea');
                            const content = textarea.value;

                            if (content.length < 3 || content.length > 255) {
                                alert('Reply must be between 3 and 255 characters.');
                                return;
                            }

                            $.ajax({
                                url: '/Comment/AddReply', // Ensure this URL is correct for your backend
                                method: 'POST',
                                data: {
                                    content: content,
                                    commentId: commentId,
                                },
                                success: function (response) {
                                    const newReplyArticle = document.createElement('div');
                                    newReplyArticle.className = 'replies';
                                    newReplyArticle.innerHTML = `
                                        <article class="card bg-light mb-3">
                                        <header class="card-header border-0 bg-transparent">
                                            <img src="https://via.placeholder.com/30x30" class="rounded-circle me-2" />
                                            <a class="fw-semibold text-decoration-none">${response.user.fullName}</a>
                                            <span class="ms-3 small text-muted">Just now</span>
                                        </header>
                                        <div class="card-body py-2 px-3">${response.content}</div>
                                        <footer class="card-footer bg-white border-0 py-1 px-3">
                                            <button type="button" class="btn btn-link btn-sm text-decoration-none ps-0">
                                                <i class="bi bi-hand-thumbs-up me-1"></i>(0)
                                            </button>
                                            <button type="button" class="btn btn-link btn-sm text-decoration-none reply-btn" data-commentid="${response.commentId}" data-replyid="${response.replyId}" data-username="${response.username}">
                                                Reply
                                            </button>
                                            <button type="button" class="btn btn-light btn-sm border rounded-4 ms-2">
                                                <i class="bi bi-check-circle-fill text-secondary"></i> Mark as answer
                                            </button>
                                        </footer>
                                        </article>
                                         <div id="replyContainer_${response.replyId}"></div>
                                    `;

                                  

                                    const repliesSection = document.getElementById(`comment-replies_${commentId}`);
                                    repliesSection.appendChild(newReplyArticle);           
                                    textarea.value = '';
                                    document.getElementById(`toggle-replies-btn-${commentId}`).style.display = 'block';
                                    replyContainer.innerHTML = '';
                                    const toggleButton = document.getElementById(`toggle-replies-btn-${commentId}`);
                                    toggleButton.textContent = `xem ${repliesSection.children.length} phản hồi`;
                                    addReplyButtonClickEvent();
                                    updateCommentCount();
                                    
                                }
                            });
                        });

                        replyContainer.appendChild(replyForm);
                        replyForm.querySelector('.cancel-reply-btn').addEventListener('click', function (event) {
                            event.preventDefault();
                            replyForm.remove();
                        });
                    }
                }
            });
        });
    });
}

function addToggleRepliesEvent() {
    document.querySelectorAll('.toggle-replies-btn').forEach(function (button) {
        button.addEventListener('click', function () {
            const commentId = this.id.replace('toggle-replies-btn-', '');
            const repliesSection = document.getElementById('comment-replies_' + commentId);

            if (repliesSection.style.display === 'none') {
                repliesSection.style.display = 'block';
                this.textContent = 'Ẩn phản hồi';
            } else {
                if (repliesSection.children.length != 0) {
                    repliesSection.style.display = 'none';
                    this.textContent = `xem thêm ${repliesSection.children.length} phản hồi`;
                }
                else
                {
                    repliesSection.style.display = 'none';
                    this.textContent = ``;
                }
            }
            updateCommentCount();
            updateRelativeTime();
        });
    });
}

dayjs.extend(window.dayjs_plugin_relativeTime);
dayjs.locale('vi');
function updateRelativeTime() {
    document.querySelectorAll('.comment-time').forEach(function (element) {
        const timeString = element.getAttribute('data-time');
        var dateObject = moment(timeString, 'DD/MM/YYYY h:mm:ss A');
        const time = dayjs(dateObject);
        const relativeTime = time.fromNow();
        element.textContent = relativeTime;
    });
}

addReplyButtonClickEvent();
addToggleRepliesEvent();
updateRelativeTime();
updateCommentCount();