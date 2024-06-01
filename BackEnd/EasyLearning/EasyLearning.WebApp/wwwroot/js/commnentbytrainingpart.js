



/*document.querySelectorAll('form[id^="commentForm_"]').forEach(form => {
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

                const newCommentSection = document.createElement('section');
                newCommentSection.id = `comment_${response.commentId}`;
                newCommentSection.className = 'comment mt-5'; // Đảm bảo class "comment" và "mt-5" cho phần tử section này

                // Tạo phần tử article mới
                const newCommentArticle = document.createElement('article');
                newCommentArticle.className = 'card bg-light'; // Đảm bảo class "card" và "bg-light" cho phần tử article này

                // Tạo phần tử header mới
                const newCommentHeader = document.createElement('header');
                newCommentHeader.className = 'card-header border-0 bg-transparent d-flex align-items-center'; // Đảm bảo class cho phần tử header này

                // Tạo phần tử div mới chứa thông tin người dùng và thời gian
                const newCommentUserInfo = document.createElement('div');
                const userImage = document.createElement('img');
                userImage.src = 'https://via.placeholder.com/40x40';
                userImage.className = 'rounded-circle me-2'; // Đảm bảo class cho ảnh người dùng
                const username = document.createElement('a');
                username.textContent = response.userId;
                username.className = 'fw-semibold text-decoration-none'; // Đảm bảo class cho tên người dùng
                const timestamp = document.createElement('span');
                timestamp.textContent = 'Just now';
                timestamp.className = 'ms-3 small text-muted'; // Đảm bảo class cho thời gian
                newCommentUserInfo.appendChild(userImage);
                newCommentUserInfo.appendChild(username);
                newCommentUserInfo.appendChild(timestamp);

                // Tạo phần tử dropdown mới
                const newCommentDropdown = document.createElement('div');
                newCommentDropdown.className = 'dropdown ms-auto'; // Đảm bảo class cho dropdown
                const dropdownButton = document.createElement('button');
                dropdownButton.className = 'btn btn-link text-decoration-none';
                dropdownButton.setAttribute('type', 'button');
                dropdownButton.setAttribute('data-bs-toggle', 'dropdown');
                dropdownButton.setAttribute('aria-expanded', 'false');
                const dropdownIcon = document.createElement('i');
                dropdownIcon.className = 'bi bi-three-dots-vertical';
                dropdownButton.appendChild(dropdownIcon);
                const dropdownMenu = document.createElement('ul');
                dropdownMenu.className = 'dropdown-menu';
                const dropdownItem = document.createElement('li');
                const dropdownLink = document.createElement('a');
                dropdownLink.className = 'dropdown-item';
                dropdownLink.href = '#';
                dropdownLink.textContent = 'Report';
                dropdownItem.appendChild(dropdownLink);
                dropdownMenu.appendChild(dropdownItem);
                newCommentDropdown.appendChild(dropdownButton);
                newCommentDropdown.appendChild(dropdownMenu);

                newCommentHeader.appendChild(newCommentUserInfo);
                newCommentHeader.appendChild(newCommentDropdown);

                // Tạo phần tử body mới
                const newCommentBody = document.createElement('div');
                newCommentBody.className = 'card-body py-2 px-3';
                newCommentBody.textContent = response.content; // Sử dụng nội dung comment từ phản hồi

                // Tạo phần tử footer mới
                const newCommentFooter = document.createElement('footer');
                newCommentFooter.className = 'card-footer bg-white border-0 py-1 px-3';

                // Tạo các nút và biểu tượng trong footer
                const likeButton = document.createElement('button');
                likeButton.type = 'button';
                likeButton.className = 'btn btn-link btn-sm text-decoration-none ps-0';
                likeButton.innerHTML = '<i class="bi bi-hand-thumbs-up me-1"></i>(3)';

                const replyButton = document.createElement('button');
                replyButton.type = 'button';
                replyButton.className = 'btn btn-link btn-sm text-decoration-none';
                replyButton.textContent = 'Reply';

                const markAsAnswerButton = document.createElement('button');
                markAsAnswerButton.type = 'button';
                markAsAnswerButton.className = 'btn btn-light btn-sm border rounded-4 ms-2';
                markAsAnswerButton.innerHTML = '<i class="bi bi-check-circle-fill text-secondary"></i> Mark as answer';

                const showRepliesButton = document.createElement('button');
                showRepliesButton.id = `toggle-replies-btn-${response.commentId}`;
                showRepliesButton.className = 'toggle-replies-btn btn btn-link btn-sm text-decoration-none ms-2 my-2';
                showRepliesButton.textContent = 'Show Replies (0)'; // Initially, there are no replies
                showRepliesButton.addEventListener('click', function () {
                    toggleReplies(this);
                });
           
                newCommentFooter.appendChild(likeButton);
                newCommentFooter.appendChild(replyButton);
                newCommentFooter.appendChild(markAsAnswerButton);

                // Gắn các phần tử con vào phần tử article
                newCommentArticle.appendChild(newCommentHeader);
                newCommentArticle.appendChild(newCommentBody);
                newCommentArticle.appendChild(newCommentFooter);

                // Gắn phần tử article vào phần tử section
                newCommentSection.appendChild(newCommentArticle);

                newCommentSection.appendChild(showRepliesButton);
                // Tìm phần tử cha để chèn phần tử section mới vào
                const commentContainer = document.getElementById(`commentContainer_${trainingPartId}`);
                commentContainer.appendChild(newCommentSection);

                // Xóa nội dung trong textarea sau khi thêm comment thành công
                const textarea = document.querySelector(`#commentContainer_${trainingPartId} textarea`);
                textarea.value = '';
            },
        });
    });
});*/


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