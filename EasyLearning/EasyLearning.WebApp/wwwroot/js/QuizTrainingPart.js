let nextBtn;
let isNextBtnHandlerAttached = false;
let nextButtonClickHandlerWrapper;
let isCompleted = false;
let isStart = true;
let correctQuestionIds = [];
let currentTrainingPartId = "initial value";
async function fetchQuizData(trainingPartId) {
    try {
        const response = await fetch(`/api/Quiz/GetQuizData?trainingPartId=${trainingPartId}`);
        if (response.ok) {
            const data = await response.json();
            return data;
        } else {
            console.error("Lấy dữ liệu bài kiểm tra thất bại");
        }
    } catch (error) {
        console.error("Lỗi khi lấy dữ liệu bài kiểm tra:", error);
    }
}

function sendDataToServer(trainingPartId, correctQuestionIds, isCompleted) {
    $.ajax({
        url: '/CustomerCourses/SubmitQuizResults',
        method: 'POST',
        data: {
         
            trainingPartId: trainingPartId,
            correctQuestionIds: correctQuestionIds,
            isCompleted: isCompleted,
        },
        success: function (response) {
            // Xử lý phản hồi từ server nếu cần
        },
        error: function (xhr, status, error) {
            console.error('Lỗi khi gửi phần trăm đã xem lên server:', error);
        }
    });
}
// Sự kiện click cho tất cả các nút "Bắt đầu"
document.querySelectorAll(".exercise-start-button").forEach(startButton => {
    startButton.addEventListener("click", async () => {
        console.log("Nút Bắt đầu đã được click!");

        const tabPane = startButton.closest(".tab-pane");
        const notification = tabPane.querySelector(".Notification");
        const quiz = tabPane.querySelector(".quiz");

        if (notification && quiz) {
            notification.classList.add("d-none");
            quiz.classList.remove("d-none");
        } else {
            console.error("Không tìm thấy phần tử trong tab-pane");
        }

        const trainingPartId = startButton.dataset.trainingpartId;
        currentTrainingPartId = trainingPartId;

        const quizArray = await fetchQuizData(trainingPartId);
        isCompleted = false;
        if (quizArray) {
            const exerciseContent = startButton.closest(".tab-pane");
            const startScreen = exerciseContent.querySelector(".exercise-start-screen");
            const displayContainer = exerciseContent.querySelector(".exercise-display-container");
            nextBtn = exerciseContent.querySelector(".next-button");
            startScreen.classList.add("hide");
            displayContainer.classList.remove("hide");
            initial(quizArray, exerciseContent);
        } else {
            console.error("Không nhận được dữ liệu câu hỏi từ cơ sở dữ liệu");
        }
    });
});

const quizDisplay = (questionCount, exerciseContent) => {
    console.log("Current questionCount:", questionCount);
    if (!exerciseContent) {
        console.error("exerciseContent is undefined");
        return;
    }

    const quizCards = exerciseContent.querySelectorAll(".exercise-container-mid");
    if (questionCount < quizCards.length) {
        quizCards.forEach((card) => {
            card.classList.add("hide");
        });
        quizCards[questionCount].classList.remove("hide");
    } else {
        console.error("Question count exceeds the number of quiz cards");
    }
};

function nextButtonClickHandler(quizArray, exerciseContent, countOfQuestion, countdown) {
    console.log("Current questionCount:", questionCount);
    console.log("Total number of questions:", quizArray.length);
    questionCount += 1;
    console.log("Next questionCount:", questionCount);

    
    if (questionCount === quizArray.length) {
        const displayContainer = exerciseContent.querySelector(".exercise-display-container");
        displayContainer.classList.add("hide");
        
        const notification = exerciseContent.querySelector(".Notification");
        const noticeOfRework = exerciseContent.querySelector(".NoticeOfRework");
        const quiz = exerciseContent.querySelector(".quiz");
        var iconContainer = $('#layoutSidenav').find('.icon-container-' + currentTrainingPartId);

        



        if (noticeOfRework)
        {
            if (iconContainer.length > 0) {
                var lockIcon = $(iconContainer).find('.fa-lock');
                var checkIcon = $(iconContainer).find('.fa-square-check');
                var squareIcon = $(iconContainer).find('.fa-square');
                $(lockIcon).hide();
                $(checkIcon).show();
                $(squareIcon).hide();
            }

            notification.classList.add("d-none");
            noticeOfRework.classList.remove("d-none");
            quiz.classList.add("d-none");
        } else {
            console.error("Không tìm thấy phần tử Notification hoặc NoticeOfRework");
        }
        console.log("manggg", correctQuestionIds);
        
       
        sendDataToServer(currentTrainingPartId, correctQuestionIds, isCompleted);
        if (isStart) {
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

                    var correctAnswersCount = correctQuestionIds.length;
                    var resultTextId = "resultText_" + currentTrainingPartId;
                    var resultText = document.getElementById(resultTextId);
                    resultText.textContent = correctAnswersCount + " / " + questionCount + " câu trả lời đúng";


                    var correctPercentage = Math.round((correctAnswersCount / questionCount)*100);
                    var resultProgressId = "resultProgress_" + currentTrainingPartId;
                    var progressElement = document.getElementById(resultProgressId);
                    progressElement.style.setProperty('--value', correctPercentage);


                    var currentDate = new Date();
                    console.log(currentDate);
                    var formattedDate = 'ngày ' + currentDate.getDate() + ' tháng ' + (currentDate.getMonth() + 1) + ' năm ' + currentDate.getFullYear();

                    var resultrecentAttemptDateId = "recentAttemptDate_" + currentTrainingPartId;
                    var resultrecentAttemptDate = document.getElementById(resultrecentAttemptDateId);

                    resultrecentAttemptDate.textContent = "Lần làm gần đây nhất vào ngày " + currentDate.getDate() + " tháng " + (currentDate.getMonth() + 1) + " năm " + currentDate.getFullYear();
                }
            }
            isStart = false; 
        }
    } else {
        countOfQuestion.textContent = `${questionCount + 1} of ${quizArray.length} Questions`;
        quizDisplay(questionCount, exerciseContent);
        count = 100;
        clearInterval(countdown);
        timerDisplay();
    }
}

function initial(quizArray, exerciseContent) {
    const quizContainer = exerciseContent.querySelector(".exercise-container");
    const countOfQuestion = exerciseContent.querySelector(".number-of-question");
    const scoreContainer = exerciseContent.querySelector(".score-container");
    const restart = exerciseContent.querySelector(".restart");
    const userScore = exerciseContent.querySelector(".user-score");

    let countdown;
    questionCount = 0;
    scoreCount = 0;
    count = 100;

    quizCreator(quizArray, quizContainer);
    quizDisplay(questionCount, exerciseContent);
    timerDisplay();

    nextButtonClickHandlerWrapper = () => {
        nextButtonClickHandler(quizArray, exerciseContent, countOfQuestion, countdown);
    };

    if (isNextBtnHandlerAttached) {
        nextBtn.removeEventListener("click", nextButtonClickHandlerWrapper);
    }

    nextBtn.addEventListener("click", nextButtonClickHandlerWrapper);
    isNextBtnHandlerAttached = true;

    function timerDisplay() {
        countdown = setInterval(() => {
            count--;
            const timeLeft = exerciseContent.querySelector(".time-left");
            timeLeft.textContent = `${count} seconds`;
            if (count === 0) {
                clearInterval(countdown);
                nextBtn.click();
            }
        }, 1000);
    }

    function quizCreator(quizArray, quizContainer) {
        if (!quizContainer) {
            console.error("Không tìm thấy phần tử quizContainer");
            return;
        }

        quizArray.forEach((i) => {
            const div = document.createElement("div");
            div.classList.add("exercise-container-mid", "hide");
            countOfQuestion.textContent = `1 of ${quizArray.length} Questions`;
            const question_DIV = document.createElement("p");
            question_DIV.classList.add("question");
            question_DIV.textContent = i.question;
            div.appendChild(question_DIV);
            i.options.forEach((option) => {
                const optionButton = document.createElement("button");
                optionButton.classList.add("option-div");
                optionButton.textContent = option;
                optionButton.addEventListener("click", () => checker(optionButton, quizArray[questionCount].correct));
                div.appendChild(optionButton);
            });
            quizContainer.appendChild(div);
        });
    }

    function checker(userOption, correctAnswer) {
        const userSolution = userOption.textContent;
        const question = exerciseContent.getElementsByClassName("exercise-container-mid")[questionCount];
        const options = question.querySelectorAll(".option-div");
        console.log("textttt manggg",quizArray);
        if (userSolution === correctAnswer) {
            userOption.classList.add("correct");
            scoreCount++;
           
            correctQuestionIds.push(quizArray[questionCount].quetionId);
        } else {
            userOption.classList.add("incorrect");
            options.forEach((element) => {
                if (element.textContent === correctAnswer) {
                    element.classList.add("correct");
                }
            });
        }
        clearInterval(countdown);
        options.forEach((element) => {
            element.disabled = true;
        });
    }
}

// Sự kiện click cho nút "Làm lại"
document.querySelectorAll(".exercise-restart-button").forEach(restartButton => {
    restartButton.addEventListener("click", async () => {
        console.log("Nút làm lại đã được click!");

        const tabPane = restartButton.closest(".tab-pane");
        const notification = tabPane.querySelector(".Notification");
        const noticeOfRework = tabPane.querySelector(".NoticeOfRework");
        const quiz = tabPane.querySelector(".quiz");

       

        if (notification && quiz && noticeOfRework) {
            quiz.classList.remove("d-none");
            noticeOfRework.classList.add("d-none");
            
        } else {
            console.error("Không tìm thấy phần tử trong tab-pane");
        }

        const trainingPartId = restartButton.dataset.trainingpartId;
        currentTrainingPartId = trainingPartId;
        const quizArray = await fetchQuizData(trainingPartId);
        

        if (quizArray) {
            const exerciseContent = restartButton.closest(".tab-pane");
            const startScreen = exerciseContent.querySelector(".exercise-start-screen");
            const displayContainer = exerciseContent.querySelector(".exercise-display-container");
            nextBtn = exerciseContent.querySelector(".next-button");
            startScreen.classList.add("hide");
            displayContainer.classList.remove("hide");

            const quizContainer = exerciseContent.querySelector(".exercise-container");
            quizContainer.innerHTML = '';

            questionCount = 0;
            scoreCount = 0;
            count = 100;

            if (isNextBtnHandlerAttached) {
                nextBtn.removeEventListener("click", nextButtonClickHandlerWrapper);
                isNextBtnHandlerAttached = false;
            }

            initial(quizArray, exerciseContent);

            const allOptionButtons = exerciseContent.querySelectorAll(".option-div");
            allOptionButtons.forEach((button) => {
                button.classList.remove("correct", "incorrect");
                button.disabled = false;
            });


            quizDisplay(questionCount, exerciseContent);

            isStart = true;
            isCompleted = true;
            console.log("Restart button clicked, questionCount:", questionCount);
        } else {
            console.error("Không nhận được dữ liệu câu hỏi từ cơ sở dữ liệu");
        }
    });
});



